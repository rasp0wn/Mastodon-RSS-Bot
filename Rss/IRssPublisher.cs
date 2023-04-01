
namespace MastodonRssPoster.Rss
{
    public interface IRssPublisher
    {
        // This method is used to publish new articles from an RSS feed into a Mastodon account
        void PublishNewArticles();

        // This method is used to clean up the published RSS articles that are 2 days old or more
        public void CleanPublishedRssArticlesÎfTheAre2DaysOldOrMore();
    }
}
