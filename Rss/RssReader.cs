using MastodonRssPoster.Configuration;
using System.Xml;
using System.ServiceModel.Syndication;
using Newtonsoft.Json;
using Serilog;

namespace MastodonRssPoster.Rss
{
    public class RssReader : IRssReader
    {
        private readonly RssURLsDto _rssUrls;
        private readonly ILogger _logger;
        private readonly int _milisecondsDelayToReadRssFeeds = 1000;

        public RssReader(ILogger logger)
        {
            _logger= logger;
            _rssUrls = ConfigurationReader.GetRssURLs();

            if (_rssUrls == null)
            {
                throw new Exception("Non Rss URLs ");
            }
        }

        public List<RssArticleDto> GetArticlesFromConfiguredURLs()
        {
            return _rssUrls.URLS.SelectMany(url => GetArticlesFromURLWithDelay(url, _milisecondsDelayToReadRssFeeds)).ToList();
        }

        public List<RssArticleDto> GetArticlesFromURL(string url)
        {
            _logger.Information($"Getting articles from specified URL: {url}");

            using XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            List<RssArticleDto> rssArticleList = feed.Items
                .Select(item => new RssArticleDto()
                {
                    ID = item.Id,
                    Title = item.Title.Text,
                    Link = item.Links[0].Uri.ToString(),
                    Date = item.PublishDate.UtcDateTime
                })
                .ToList();

            return rssArticleList;
        }

        public List<RssArticleDto> GetArticlesFromURLWithDelay(string url, int delayMilliseconds)
        {
            Thread.Sleep(delayMilliseconds);
            return GetArticlesFromURL(url);
        }
    }
}
