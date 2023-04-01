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

1. Clone the repository to your local machine.
2. Navigate to the `MastodonRssBot` folder.
3. Fill in the necessary details in the `MastodonAPI.json` file located in the `Configuration` folder. This includes your Mastodon instance, Mastodon app ID, and Mastodon access token.
4. Modify the `RssList.json` file in the `Configuration` folder to include the RSS feed URLs you want to track.
5. Compile the project using your preferred IDE or by running `dotnet build` in the command line.
6. Run the compiled executable in the `bin` folder.
7. Check the `Logs` folder for the daily rotated log file `MastodonRssPosterLog.txt`.

# 📄 License
This project is licensed under the MIT License.

# 📧 Contact
If you have any questions or comments, you can contact me through my Mastodon account: `🐘 mastodon.social@NoticiasTecnologicasBot.`

Also, feel free to check out the bot in action from there!

# 🙏 Acknowledgements
This project was made with the help of ChatGPT, a language model developed by OpenAI. Thank you, ChatGPT! 🤖💙
