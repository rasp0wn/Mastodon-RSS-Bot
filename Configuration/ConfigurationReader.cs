using MastodonRssPoster.Configuration;
using Newtonsoft.Json;
using Serilog;

namespace MastodonRssPoster
{
    public static class ConfigurationReader
    {
        public static MastodonAPIDto GetMastodonConfig()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "MastodonAPI.json");
            string fileContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<MastodonAPIDto>(fileContent);
        }

        public static RssURLsDto GetRssURLs() 
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration", "RssList.json");
            string fileContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<RssURLsDto>(fileContent);
        }
    }
}