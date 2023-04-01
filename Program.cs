using MastodonRssPoster.Mastodon;
using MastodonRssPoster.Rss;
using Serilog;
using Serilog.Events;
using System;

namespace MastodonRssPoster
{
    public class Program
    {
        private static int miliSecondsToWait = 30000;
        private static string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "MastodonRssPosterLog.txt");

        public static readonly ILogger _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

        static void Main(string[] args)
        {
            _logger.Information("Starting Bot......");

            IMastodonSlave mastodonClient = new MastodonSlave(_logger);
            IRssReader rssReader = new RssReader(_logger);
            IRssPublisher rssPublisher = new RssPublisher(rssReader, mastodonClient, _logger);

            while(true)
            {
                try
                {
                    rssPublisher.PublishNewArticles();
                    rssPublisher.CleanPublishedRssArticlesÎfTheAre2DaysOldOrMore();

                    _logger.Information("Batch completed......");
                    Thread.Sleep(miliSecondsToWait);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
            }
            
        }
    }
}