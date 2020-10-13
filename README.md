# Brobot
[![Discord](https://discordapp.com/api/guilds/733442807544545462/embed.png?style=shield)](https://discord.gg/XFs3HRU)

Brobot is a general purpose bot that does tasks for you. 
The bot is built in C# using the Discord.Net library. 
Mention him with @Brobot and he will execute your command. 

[Invite Link](https://discord.com/oauth2/authorize?client_id=755427910306889820&scope=bot&permissions=2146958847)

# Installation 
To install this project you need to have Microsoft .NET Core SDK Version 5.0

To register the bot you need to create an application on [Discord Developer Portal](https://discord.com/developers). Downolad the project from the repo and compile it using Visual Studio.
Create a `_config.yml` file and add the bot's token inside it following this layout:
```
prefix : 'prefix'
imdbkey: 'rapidapi key'
newskey: 'newsapi.org key'
deezerkey: 'rapidapi key'
jokekey: 'rapidapi key'
discord:
	token: 'Your token here'
```
Run the bot. The console should log `Connected as [Application Name]:[Discord Discriminator]`

## Contributing to the Project
Follow the Issue Layout if you want new features, otherwise you can fork the repo and add the features yourself. I will credit you in the project's wiki and in the bot's commands

## Supporting the Project
To support the project you can:
donate on Patreon 
or donate on [StreamElements Tip Page](https://streamelements.com/davcam0055/tip)

# License
The bot is under the MIT license. Check LICENSE
# Documentation
Check the [Project's Wiki](https://github.com/DavCam05/Brobot/wiki)

