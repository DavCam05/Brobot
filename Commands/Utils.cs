using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

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

        [Command("afk")]
        public async Task Afk(SocketGuildUser user) //changes nickname of a user to [AFK] {username}
        {
            if (user.Id != Context.User.Id)
            {
                await Context.Channel.SendMessageAsync("You can only change your afk status, not somebody else's");
            }
            else
            {
                await user.ModifyAsync(x => x.Nickname = $"[AFK] {user.Username}");
                await Context.Channel.SendMessageAsync("Set AFK Status on your nickname");
            }
        }
        [Command("noafk")]
        public async Task NoAfk(SocketGuildUser user) //changes nickname of a user to [AFK] {username}
        {
            if (user.Id != Context.User.Id)
            {
                await Context.Channel.SendMessageAsync("You can only change your afk status, not somebody else's");
            }
            else
            {
                await user.ModifyAsync(x => x.Nickname = $"{user.Username}");
                await Context.Channel.SendMessageAsync("Removed AFK status on your nickname");
            }
        }
    }
}
