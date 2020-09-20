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
                 .WithUrl("https://github.com/DavCam05/Brobot/wiki/Commands")
                 .WithDescription("Welcome to the Brobot help center. Type `help.[command]` to learn more about the available commands. Alternatively you can visit the GitHub Repository. Link is in the title")
                 .AddField("Commands", "`help` sends this embed " +
                 "\n`info.bot.ping` pings the bot " +
                 "\n`info.user.me` sends info about you" +
                 "\n`info.user.other` sends info about another user" +
                 "\n`info.server` sends the info about the server the bot is in")
                 .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.info.bot.ping")]
        public async Task HelpPing()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `info.bot.ping`")
                .AddField("Description", "This commad returns the ping time of the bot", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.info.user.me")]
        public async Task HelpMyInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `info.user.me`")
                .AddField("Description", "This commad returns info about you", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.info.user.other")]
        public async Task HelpUserInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `info.user.other`")
                .AddField("Description", "This command returns info about a specified user", true)
                .AddField("Arguments", "`<User>` Mention the user that you need info from", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("help.info.server")]
        public async Task HelpServerInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithDescription("Command: `info.server`")
                .AddField("Description", "This command returns info about the server", true)
                .AddField("Arguments", "None", true)
                .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

    }
}
