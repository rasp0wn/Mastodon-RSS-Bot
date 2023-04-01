using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastodonRssPoster.Rss
{
    public interface IRssReader
    {
        // Get articles from the URLs configured in RssList.json 
        public List<RssArticleDto> GetArticlesFromConfiguredURLs();

        // Get articles from an specified URL
        public List<RssArticleDto> GetArticlesFromURL(string url);
    }
}
