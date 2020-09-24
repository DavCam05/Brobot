using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Brobot.Commands
{
    public class ModerationCommands : ModuleBase
    {
        [Command("moderation.kick")]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage =  "Woah. You don't have permission to kick users from the server.")]
        [RequireBotPermission(GuildPermission.KickMembers, ErrorMessage = "You need to grant me permission to kick users from the server")]
        public async Task Kick(string reason = null, SocketGuildUser user = null)
        {
            if(user == null)
            {
                await Context.Channel.SendMessageAsync("You need to specify an user to kick from the server");
            }
            else if(reason == null)
            {
                await Context.Channel.SendMessageAsync($"User {user.Mention} has been kicked from the server. Reason: No reason specified");
            }else
            {
                await Context.Channel.SendMessageAsync($"USer {user.Mention} has been kicked from the server. Reason: {reason}");
            }
            
        }
    }
}
