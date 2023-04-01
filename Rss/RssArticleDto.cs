namespace MastodonRssPoster.Rss
{
    public class RssArticleDto
    {
        public string? ID;
        public string? Title;
        public string? Link;
        public DateTime? Date;

        public override string ToString()
        {
            return $"{Title}\n" +
                   $"{Link}";
        }
    }
}
