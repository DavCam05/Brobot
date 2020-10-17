using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class HelpCommand : ModuleBase
    {
      [Command("help")]
      public async Task Help()
        {
            var builder = new EmbedBuilder() //update for report commands
                 .WithTitle("Help Menu")
                 .WithUrl("https://github.com/DavCam05/Brobot/wiki/Commands")
                 .WithDescription("Welcome to the Brobot help center. Type `help.[command]` to learn more about the available commands. Alternatively you can visit the GitHub Repository. Link is in the title. If the bot returns errrors that you cannot understand you can use the command `bro!errorcodess`")
                 .AddField("Commands", "`help` sends this embed " +
                 "\n`ping` pings the bot " +
                 "\n`infome` sends info about you" +
                 "\n`infoother` sends info about another user" +
                 "\n`infobot` sends information about the bot" +
                 "\n`serverinfo` sends the info about the server the bot is in" +
                 "\n`time` sends the server time where the bot is running" +
                 "\n`invite` Invite for the bot" +
                 "\n`anime` fetches anime info on MAL" +
                 "\n`manga` fetches manga info on MAL" +
                 "\n`malcharacter` fetches anime/manga character info on MAL" +
                 "\n`github` sends the github repo of the bot" +
                 "\n`twitch` sends the twitch page of the owner of the bot" +
                 "\n`donate` sends the donation page of the owner of the bot" +
                 "\n`newtext` creates a text channel" +
                 "\n`newvoice` creates a voice channel" +
                 "\n`8ball` predicts the future" +
                 "\n`memetemplates` fetches some meme templates for you" +
                 "\n`news` fetches the latest news on a topic specified" +
                 "\n`calculator` the help menu for the calculator" +
                 "\n`imdb` searches movies from IMDb, needs a movie title" +
                 "\n`music` searches music on Deezer" +
                 "\n`dadjoke` sends a random Dad Joke" +
                 "\n`coin` flips a coin" +
                 "\n`game` sends game information. Needs full game title with `-` instead of spaces")
                 .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.ping")]
        public async Task HelpPing()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `ping`")
                .AddField("Description", "This commad returns the ping time of the bot", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.dadjoke")]
        public async Task HelpDadjoke()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `dadjoke`")
                .AddField("Description", "This commad sends a random dad joke", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        public async Task HelpCoin()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `coin`")
                .AddField("Description", "This commad flips a coin", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.memetemplates")]
        public async Task HelpMeme()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `memetemplates`")
                .AddField("Description", "This commad returns random meme templates", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.time")]
        public async Task HelpTIme()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `time`")
                .AddField("Description", "This commad returns the time of the server of the bot", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.infome")]
        public async Task HelpMyInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `infome`")
                .AddField("Description", "This commad returns info about you", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.infobot")]
        public async Task HelpbotInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `infobot`")
                .AddField("Description", "This commad returns info about the bot", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.infoother")]
        public async Task HelpUserInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `infoother`")
                .AddField("Description", "This command returns info about a specified user", true)
                .AddField("Arguments", "`<User>` Mention the user that you need info from", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.serverinfo")]
        public async Task HelpServerInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `serverinfo`")
                .AddField("Description", "This command returns info about the server", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.anime")]
        public async Task HelpFetchAnime()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `anime`")
                .AddField("Description", "This command returns information about your searched anime. Uses the Jikan.Net Wrapper for MAL", true)
                .AddField("Arguments", "`<query` This is the search query. Make sure to place it between double inverted commas", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.manga")]
        public async Task HelpFetchManga()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `manga`")
                .AddField("Description", "This command returns information about your searched manga. Uses the Jikan.Net Wrapper for MAL", true)
                .AddField("Arguments", "`<query>` This is the search query. Make sure to place it between double inverted commas", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.malcharacter")]
        public async Task HelpFetchCharacter()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `malcharacter`")
                .AddField("Description", "This command returns information about your searched character. Uses the Jikan.Net Wrapper for MAL", true)
                .AddField("Arguments", "`<query>` This is the search query. Make sure to place it between double inverted commas", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.github")]
        public async Task HelpSocialGithub()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `github`")
                .AddField("Description", "This command returns the github page of the bot", true)
                .AddField("Arguments", "none", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.twitch")]
        public async Task HelpTwitch()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `twitch`")
                .AddField("Description", "This command returns the twitch page of the owner of the bot", true)
                .AddField("Arguments", "none", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.donate")]
        public async Task HelpDonate()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `donate`")
                .AddField("Description", "This command returns the donation page of the owner of the bot", true)
                .AddField("Arguments", "none", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.newtext")]
        public async Task HelpText()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `newtext`")
                .AddField("Description", "This command creates a text channel", true)
                .AddField("Arguments", "`<channelname>` The name of the channel. enclose the name in inverted commas", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.newvoice")]
        public async Task HelpVoice()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `newvoice`")
                .AddField("Description", "This command creates a voice channel", true)
                .AddField("Arguments", "`<channelname>` The name of the channel. enclose the name in inverted commas", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.8ball")]
        public async Task HelpEightBall()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `8ball`")
                .AddField("Description", "This command predicts the future", true)
                .AddField("Arguments", "`<question>` The question you want to the bot to predict", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.news")]
        public async Task HelpNews()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `news`")
                .AddField("Description", "This command fetches the lates news on `newsapi.org`", true)
                .AddField("Arguments", "`<query>` The search query. This wll be used to return the latest results that match the query", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.calculator")]
        public async Task HelpCalculator()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `calculator`")
                .AddField("Description", "This command is a help menu for the calculator", true)
                .AddField("Arguments", "none", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.invite")]
        public async Task HelpInvite()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `invite`")
                .AddField("Description", "This command sends the invite link for the bot", true)
                .AddField("Arguments", "none", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.imdb")]
        public async Task HelpIMDb()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `imdb`")
                .AddField("Description", "This command returns movie/tv show information", true)
                .AddField("Arguments", "`<movie>` The title of the movie \n OPTIONAL: `<id>` The IMDb Id of the movie", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.music")]
        public async Task HelpMusic()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `music`")
                .AddField("Description", "This command music information", true)
                .AddField("Arguments", "`<query>` Title of song ", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.gmae")]
        public async Task HelpGame()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `game`")
                .AddField("Description", "This command sends information about a game. NOTE: You need to search for the FULL game title and instead of spaces you put `-`", true)
                .AddField("Arguments", "`<name>` Full game title with `-` instead of spaces ", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

    }
}
