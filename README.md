# 🤖 Mastodon RSS Bot
Mastodon RSS Bot is a customizable bot that reads news from an RSS feed and posts them automatically to a Mastodon account. Perfect for bloggers and content creators, the bot keeps your followers up-to-date with the latest news in your field.

# ⚙️ Configuration
To set up the bot, modify the `MastodonAPI.json` file in the `Configuration` folder and fill it with the following information:

<pre><code>
{
  "MastodonInstance": "mastodon.social", //Change this to your mastodon instance if necessary 
  "MastodonAppID": "PUT_HERE_YOUR_APP_ID",
  "MastodonAccessToken": "PUT_HERE_YOUR_ACCESS_TOKEN"
}
</code></pre>

Replace `PUT_HERE_YOUR_APP_ID` with your Mastodon app ID, and `PUT_HERE_YOUR_ACCESS_TOKEN` with your Mastodon access token. If necessary, change `mastodon.social` to your Mastodon instance.

You can also modify the `RssList.json` file in the `Configuration` folder to track the RSS feeds you want. Simply add the URL of the RSS feed to the list, and the bot will automatically start posting new articles to your Mastodon account.

# 🚀 Usage
To use the bot, simply run the MastodonRssBot executable. The bot will periodically check for new articles in the RSS feeds and post them to your Mastodon account.

1. Download the latest release from the releases page.
2. Extract the zip file to a directory of your choice.
3. Navigate to the `MastodonRssPoster` directory.
4. Open the `Configuration` directory and modify the `MastodonAPI.json` and `RssList.json` files to your liking.
5. Run the `MastodonRssPoster` executable. The bot will now start running.

## 📝 Note
- .NET 6 must be installed on the machine for the bot to work. Please make sure you have .NET 6 installed before running the bot.


# 🍓 Working on Raspberry Pi
To run the bot on a Raspberry Pi, follow these steps:

1. Install .NET on your Raspberry Pi by following the instructions on this [blog post](https://blog.behroozbc.ir/install-net-on-a-raspberry-pi).
2. Download the latest release for ARM from the releases page.
3. Extract the zip file to a directory of your choice.
4. Navigate to the `MastodonRssPoster` directory.
5. Open the Configuration directory and modify the `MastodonAPI.json` and `RssList.json` files to your liking.
6. Run the `MastodonRssPoster` executable. The bot will now start running.

![Bot working on a raspberry pi 3B+](https://i.ibb.co/YX4zFF4/image.png)



# 🧪 Testing
This project is pending testing.

# 📄 License
This project is licensed under the MIT License.

# 📧 Contact
If you have any questions or comments, you can contact me through my Mastodon account: `🐘 mastodon.social@NoticiasTecnologicasBot`.

Also, feel free to check out the bot in action from there!

# 🙏 Acknowledgements
This project was made with the help of ChatGPT, a language model developed by OpenAI. Thank you, ChatGPT! 🤖💙
