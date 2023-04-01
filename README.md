# 🤖 Mastodon RSS Bot
Mastodon RSS Bot is a customizable bot that reads news from an RSS feed and posts them automatically to a Mastodon account. Perfect for bloggers and content creators, the bot keeps your followers up-to-date with the latest news in your field.

# ⚙️ Configuration
To set up the bot, modify the MastodonAPI.json file in the Configuration folder and fill it with the following information:

<pre><code>
{
  "MastodonInstance": "mastodon.social", //Change this to your mastodon instance if necessary 
  "MastodonAppID": "PUT_HERE_YOUR_APP_ID",
  "MastodonAccessToken": "PUT_HERE_YOUR_ACCESS_TOKEN"
}
</code></pre>

Replace PUT_HERE_YOUR_APP_ID with your Mastodon app ID, and PUT_HERE_YOUR_ACCESS_TOKEN with your Mastodon access token. If necessary, change mastodon.social to your Mastodon instance.

You can also modify the RssList.json file in the Configuration folder to track the RSS feeds you want. Simply add the URL of the RSS feed to the list, and the bot will automatically start posting new articles to your Mastodon account.

# 🚀 Usage
To use the bot, simply run the MastodonRssBot executable. The bot will periodically check for new articles in the RSS feeds and post them to your Mastodon account.

# 📄 License
This project is licensed under the MIT License.
