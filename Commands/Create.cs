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
    }
}
