using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using JikanDotNet;

namespace Brobot.Commands
{
    public class ModCommands : ModuleBase
    {
        [Command("report")]
        public async Task ReportUser(SocketGuildUser user = null) //still needs fixing
        {
            if(user == null)
            {
                await Context.Channel.SendMessageAsync("You need to specify a user to report");
            }else
            {
                await Context.Channel.SendMessageAsync($":mega: {user.Mention} has been reported by {Context.User.Mention} for going against the rules of the server. Owner of the server: {Context.Guild.GetOwnerAsync().Result.Mention}");
            }

        }
    }
}
