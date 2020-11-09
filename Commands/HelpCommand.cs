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
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Here is a list of all commands that are available for use. To know more about the command requirements you can type `help.[command]`. This will send an embed with all the details for said command")
                .AddField("Calculator Related Commands", "`calculator` Sends the help menu for the calculator")
                .AddField("General Commands", "`ping` sends the ping time, shard and connection status" +
                "\n`infome` sends information about your profile (eg. avatar, discriminator, id, status...)" +
                "\n`infoother` sends information about another person's profile. You need to tag the user" +
                "\n`infobot` sends information about the bot" +
                "\n`serverinfo` sends information about the server" +
                "\n`invite` sends the invite for the bot. " +
                "\n`github` sends the github repo of the bot" +
                "\n`twitch` sends the twitch page of the owner of the bot" +
                "\n`donate` sends the donation page of the owner of the bot" +
                "\n`time` sends the time of the server where the bot is run on" +
                "\n`help` sends this embed" +
                "\n`vote` sends you a link for the bot's top.gg page")
                .AddField("Moderation Commands", "`kick` kicks a member from the server" +
                "\n`ban` bans a member from the server" +
                "\n`addrole` adds a role to a person" +
                "\n`remrole` removes a role from a person")
                .AddField("Server Commands","" +
                "\n`newrole` creates a new role with no permissions" +
                "\n`newtext` creates a new text channel" +
                "\n`newvoice` creates a new voice channel")
                .AddField("Web Search Commands", "`anime` searches anime on MAL" +
                "\n`manga` searches manga on MAL" +
                "\n`malcharacter` fetches an image for the requested MAL character" +
                "\n`memetemplates` fetches random meme templates" +
                "\n`news` fetches the latest news on the requested topic" +
                "\n`imdb` fetches movie information on IMDB" +
                "\n`music`fetches song information on Deezer" +
                "\n`dadjoke` fetches random dad jokes" +
                "\n`game` fetches game information on RAWG. WARNING: The api is a bit broken and it will require you to replace spaces with `-` or `_`")
                .AddField("Fun Commands", "`animu` gets random anime gifs, specify the category of the gif" +
                 "\n`8ball` predicts the future" +
                 "\n`gf` you'll see" +
                 "\n`bf` same thing as `gf`" +
                 "\n`gay` same thing as `gf` but different" +
                 "\n`lesbian` same thing as `gf` but different" +
                 "\n`dogfact` Gets random dog facts" +
                 "\n`catfact` same thing as `dogfact`" +
                 "\n`giraffefact` same thing as `dogfact`" +
                 "\n`racoonfact` same thing as `dogfact`" +
                 "\n`whalefact` same thing as `dogfact`" +
                 "\n`elephantfact` same thing as `dogfact`" +
                 "\n`kangaroofact` same thing as `dogfact`" +
                 "\n`pandafact` same thing as `dogfact`" +
                 "\n`foxfact` same thing as `dogfact`" +
                 "\n`birbfact`same thing as `dogfact`" +
                 "\n`koalafact` same thing as `dogfact`")
                 .AddField("Fun Commands Part 2",
                 "\n`dogimg` gets random images of dogs" +
                 "\n`catimg` same thing as `dogimg`" +
                 "\n`pandaimg` same thing as `dogimg`" +
                 "\n`foximg` same thing as `dogimg`" +
                 "\n`birbimg` same thing as `dogimg`" +
                 "\n`koalaimg` same thing as `dogimg`" +
                 "\n`kangarooimg` same thing as `dogimg`" +
                 "\n`racoonimg` same thing as `dogimg`" +
                 "\n`whaleimg` same thing as `dogimg`" +
                 "\n`pikachuimg` same thing as `dogimg`" +
                 "\n`ytcomment` Creates a fake youtube comment with custom avatar, name and content " +
                 "\n`filterimg` Adds filters to an image." +
                 "\n`viewcolor` Sends the color of the specified HEX code ")
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.vote")]
        public async Task HelpVote()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `vote`")
                .AddField("Description", "This commad sends the voting page for the bot on top.gg", true)
                .AddField("Arguments", "None", true)
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
        [Command("help.ban")]
        public async Task HelpBan()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `ban`")
                .AddField("Description", "This command bans people from the server", true)
                .AddField("Arguments", "`<user>` The user you want to ban. In the format of `<@![User ID]> or a ping. Bots aren't recognised", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.kick")]
        public async Task HelpKicks()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `kick`")
                .AddField("Description", "This command kicks people from the server", true)
                .AddField("Arguments", "`<user>` The user you want to kick. In the format of `<@![User ID]> or a ping. Bots aren't recognised", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.addrole")]
        public async Task HelpAddRole()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `addrole`")
                .AddField("Description", "This command adds role", true)
                .AddField("Arguments", "`<role>` the role. In the format of a ping" +
                "\n`<user>` The user you want to give the role to. In the format of `<@![User ID]> or a ping. Bots aren't recognised", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.remrole")]
        public async Task HelpremRole()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `remrole`")
                .AddField("Description", "This command removes role", true)
                .AddField("Arguments", "`<role>` the role. In the format of a ping" +
                "\n`<user>` The user you want to remove the role from. In the format of `<@![User ID]> or a ping. Bots aren't recognised", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.viewcolor")]
        public async Task Helpviewcolor()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `viewcolor`")
                .AddField("Description", "This command sends the specified Hexadecimal (HEX) color ", true)
                .AddField("Arguments", "`<hex>` the hex code of the color", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.filterimg")]
        public async Task HelpFilterImg()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `filterimg`")
                .AddField("Description", "This command sends an image with a custom filter", true)
                .AddField("Arguments", "`<avatar>` This is the link for the avatar. must not contain `&` symbol \n `<filter>` the filter of the image. Choose from: greyscale, invert, brightness, threshold, sepia, red, green, blue, blurple, pixelate, blur", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.ytcomment")]
        public async Task HelpYtComment()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `ytcomment`")
                .AddField("Description", "This command sends a custom yt comment", true)
                .AddField("Arguments", "`<avatar>` This is the link for the avatar. must not contain `&` symbol \n`<username>` the username \n`<comment>` the content of the comment", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.animu")]
        public async Task HelpAnimu()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `animu`")
                .AddField("Description", "This command sends random anime gifs. Gifs are sorted in categories.", true)
                .AddField("Arguments", "`<category>` This is the category for the gifs. Choose from: `face palm`, `wink`, `hug` and `pat`", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.dogfact")]
        public async Task HelpDogs()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `dogfact`. The command layout is identical for the commands that say `same thing as dogfact`")
                .AddField("Description", "This commad returns random dog facts ", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.dogimg")]
        public async Task HelpDogsImg()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `dogimg`. The command layout is identical for the commands that say `same thing as dogimg`")
                .AddField("Description", "This commad returns random dog images ", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("help.gf")]
        public async Task HelpGF()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `gf`")
                .AddField("Description", "This commad is fun", true)
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
