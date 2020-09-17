using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Brobot.Commands
{
    public class InfoCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Returns the bot responce time")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("pong").ConfigureAwait(false);
        }
    }
}
