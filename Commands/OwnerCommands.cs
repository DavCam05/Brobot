using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using IMDbApiLib.Models;

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
        [RequireOwner(ErrorMessage = "Only the bot owner can use this")]
        public async Task ChangeGameStatus(string name, int type)
        {
            try
            {
                switch (type)
                {
                    case 1:
                        await _discord.SetGameAsync($"{name}", null, ActivityType.Playing);
                        break;

                    case 2:
                        await _discord.SetGameAsync($"{name}", null, ActivityType.Listening);
                        break;
                    case 3:
                        await _discord.SetGameAsync($"{name}", null, ActivityType.Watching);
                        break;
                   // case 4:
                     //   await _discord.SetGameAsync($"{name}", null, ActivityType.Streaming);
                       // break;
                }

                
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
