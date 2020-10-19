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
    public class OwnerCommands : ModuleBase
    {
        public static DiscordSocketClient _discord;

        public OwnerCommands(DiscordSocketClient discord)
        {
            _discord = discord;
        }


        [Command("setgame")]
        [RequireOwner]
        public async Task ChangeGameStatus(string name)
        {
            try
            {
                await _discord.SetGameAsync($"{name}", null, ActivityType.Playing);
            }
            catch (Exception error)
            {
                await Context.Channel.SendMessageAsync("There has been an error \n" +
                    $"```{error}```");

            }

            await Context.Channel.SendMessageAsync("Status has been changed!!");
        }
    }
}
