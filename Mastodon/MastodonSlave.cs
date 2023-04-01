using Mastonet;
using Serilog;

namespace MastodonRssPoster.Mastodon
{
    public class MastodonSlave : IMastodonSlave
    {
        private MastodonClient _mastodonClient;
        private ILogger _logger;

        private static readonly int _maxRequests = 1;
        private static readonly TimeSpan _interval = TimeSpan.FromSeconds(3);        
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(_maxRequests, _maxRequests);

        public MastodonSlave(ILogger logger)
        {
            _logger = logger;

            var mastodonConfig = ConfigurationReader.GetMastodonConfig();

            if (mastodonConfig.MastodonInstance == null || mastodonConfig.MastodonAccessToken == null)
            {
                _logger.Error("Bad Mastodon Configuration. Could not read the Mastodon config file with the API Key");
                throw new Exception("Bad Mastodon Configuration");
            }

            _mastodonClient = new MastodonClient(mastodonConfig.MastodonInstance, mastodonConfig.MastodonAccessToken);
        }

        public async Task PostMessageAsync(string message)
        {
            await _semaphore.WaitAsync();
            try
            {
                _logger.Information($"Publishing message async: {message.Replace("\n", " | ")}");
                await _mastodonClient.PublishStatus(message);
            }
            finally
            {
                await Task.Delay(_interval);
                _semaphore.Release();
            }            
        }

        public void PostMessage(string message)
        {
            _logger.Information($"Publishing message: {message.Replace("\n", " | ")}");
            PostMessageAsync(message).Wait();
        }
    }
}
