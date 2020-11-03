using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class Create : ModuleBase
    { 
        [Command("newtext")]
        [RequireUserPermission(ChannelPermission.ManageChannels)]
        public async Task CreateText(string channelname)
        {
            await Context.Guild.CreateTextChannelAsync(channelname);
            await Context.Channel.SendMessageAsync("Channel has been created. You can now add permissions and move it in your chosen category. The channel is at the top of the left sidebar");
        }

        [Command("newvoice")]
        [RequireUserPermission(ChannelPermission.ManageChannels)]
        public async Task CreateVoice(string channelname)
        {
            await Context.Guild.CreateVoiceChannelAsync(channelname);
            await Context.Channel.SendMessageAsync("Channel has been created. You can now add permissions and move it in your chosen category. The channel is at the top of the left sidebar");
        }

        [Command("newrole")]
        [RequireUserPermission(GuildPermission.ManageRoles)]
        public async Task CreateRole(string rolename)
        {
            await Context.Guild.CreateRoleAsync($"{rolename}", null, null, false, null);
            await Context.Channel.SendMessageAsync($"The `{rolename}` role has been created. You may now go and edit the permission for said role.");
        }
    }
}
