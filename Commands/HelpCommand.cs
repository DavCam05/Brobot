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
                 .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                 .WithDescription("Welcome to the Brobot help center. Type `help.[command]` to learn more about the available commands")
                 .AddField("Commands", "`help` sends this embed " +
                 "\n`info.bot.ping` pings the bot " +
                 "\n`info.user.me` sends info about you" +
                 "\n`info.user.other` sends info about another user" +
                 "\n`info.server` sends the info about the server the bot is in")
                 .WithColor(33, 176, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
