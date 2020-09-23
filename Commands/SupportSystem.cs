using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class SupportSystem : ModuleBase //needs development. Do NOT add to help
    {
        [Command("support.ticket")]
        public async Task CreateTicket(string ticketName, string voice)
        {
            
            if(voice == "true")
            {
                var newvoicechannel = Context.Guild.CreateVoiceChannelAsync("ticket" + "-" + ticketName + "-" + Context.User.Username);



                await newvoicechannel;
                await Context.Channel.SendMessageAsync("Text Channel Created");
                return;

            }else if(voice == "false")
            {
                var newchannel = Context.Guild.CreateTextChannelAsync("ticket" + "-" + ticketName + "-" + Context.User.Username);



                await newchannel;
                await Context.Channel.SendMessageAsync("Text Channel Created");
            }
        }
    }
}
