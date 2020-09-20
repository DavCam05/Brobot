using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class SocialCommands : ModuleBase
    {
        [Command("social.github")]
        public async Task GitHub()
        {
            var builder = new EmbedBuilder()
                .WithTitle("GitHub Repository")
                .WithUrl("https://github.com/DavCam05/Brobot")
                .WithDescription("GitHub Repository for the bot. If you need to post feature requests or if you notice a bug just head over there and create an issue")
                .WithColor(250, 250, 250);

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            
        }
    }
}
