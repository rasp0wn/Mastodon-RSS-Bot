namespace MastodonRssPoster.Mastodon
{
    public interface IMastodonSlave
    {
        /// <summary>
        /// Post a message to Mastodon in an async way
        /// <param name="message"> Message to post</param>
        /// </summary>
        Task PostMessageAsync(string message);

        /// <summary>
        /// Post a message to Mastodon
        /// <param name="message"> Message to post</param>
        /// </summary>
        public void PostMessage(string message);
    }
}
