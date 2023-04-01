using MastodonRssPoster.Mastodon;
using Newtonsoft.Json;
using Serilog;

namespace MastodonRssPoster.Rss
{
    public class RssPublisher : IRssPublisher
    {

        private readonly string _publishedArticlesFileName = "PublishedArticles.json";
        
        private readonly IRssReader _reader;
        private readonly ILogger _logger;
        private readonly IMastodonSlave _mastodonClient;

        public RssPublisher(IRssReader rssReader, IMastodonSlave mastodonSlave, ILogger logger)
        {
            _reader = rssReader;
            _mastodonClient = mastodonSlave;
            _logger = logger;
        }

        public void PublishNewArticles()
        {
            _logger.Information("Start of a new batch of publications....");

            var articlesToPublish = GetArticlesFromSepcifiedTime(_reader.GetArticlesFromConfiguredURLs(), DateTime.Today);

            foreach(var article in articlesToPublish)
            {
                if(!CheckAndAddArticleToPublishedListIfDoesntExist(article))
                {
                    _mastodonClient.PostMessageAsync(article.ToString());
                }
            }
        }

        private bool CheckAndAddArticleToPublishedListIfDoesntExist(RssArticleDto articleToPublish)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Rss", _publishedArticlesFileName);
            string fileContent = File.ReadAllText(filePath);

            List<RssArticleDto> publishedArticles = JsonConvert.DeserializeObject<List<RssArticleDto>>(fileContent);

            bool articleAlreadyPublished = publishedArticles.Any(article => article.ID == articleToPublish.ID);

            if (!articleAlreadyPublished)
            {
                _logger.Information($"New article found: {articleToPublish.Title}");

                publishedArticles.Add(articleToPublish);
                string serializedArticles = JsonConvert.SerializeObject(publishedArticles);
                File.WriteAllText(filePath, serializedArticles);
            }

            return articleAlreadyPublished;
        }

        private List<RssArticleDto> GetArticlesFromSepcifiedTime(List<RssArticleDto> articleList, DateTime trackingTime)
        {
            return articleList.Where(article => article.Date > trackingTime).ToList();
        }

        public void CleanPublishedRssArticlesÎfTheAre2DaysOldOrMore()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Rss", _publishedArticlesFileName);
            string fileContent = File.ReadAllText(filePath);

            List<RssArticleDto> publishedArticles = JsonConvert.DeserializeObject<List<RssArticleDto>>(fileContent);

            var filteredArticles = publishedArticles.Where(article => article.Date >= DateTime.Now.AddDays(-2)).ToList();

            string serializedArticles = JsonConvert.SerializeObject(filteredArticles);
            File.WriteAllText(filePath, serializedArticles);
        }
    }
}
