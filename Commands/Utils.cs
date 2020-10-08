using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class Utils : ModuleBase //command not ready DO NOT ADD TO HELP OR DOCS
    {
        [Command("poll")]
        public async Task SimplePoll(string question)
        {
            var builder = new EmbedBuilder()
                .WithTitle("Poll Time!")
                .WithDescription($"{Context.User.Username} asks {question}")
                .AddField("Reactions:", ":thumbsup:: Agree \n:thumbsdown:: Disagree")
                .WithColor(168, 168, 50);
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
