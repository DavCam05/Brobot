using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using IGDB;
using Microsoft.Extensions.Configuration;

namespace Brobot.Services
{
    public class CommandHandler
    {
        public static IServiceProvider _provider;
        public static DiscordSocketClient _discord;
        public static CommandService _commands;
        public static IConfigurationRoot _config;


        public CommandHandler(DiscordSocketClient discord, CommandService commands, IConfigurationRoot config, IServiceProvider provider)
        {
            _provider = provider;
            _discord = discord;
            _config = config;
            _commands = commands;

            _discord.Ready += OnReady;
            _discord.MessageReceived += OnMessageReceived;

        }

        private async Task OnMessageReceived(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            if (msg.Author.IsBot) return;

            var context = new SocketCommandContext(_discord, msg);

            int pos = 0;
            //msg.HasStringPrefix(_config["prefix"], ref pos) ||  just for the prefix
            if (msg.HasStringPrefix(_config["prefix"], ref pos) || msg.HasMentionPrefix(_discord.CurrentUser, ref pos))
            {
                var result = await _commands.ExecuteAsync(context, pos, _provider);
                
                if (!result.IsSuccess)
                {
                    var reason = result.Error;
                    Console.WriteLine("There has been an error!");
                    Console.WriteLine(reason);
                    Console.WriteLine(result);

                    var builder = new EmbedBuilder()
                        .WithTitle("Error")
                        .WithDescription("There has been an error in executing your command. If you encounter further problems please run the command `bro!github`. Error definitions are here: `bro!errorcodes`")
                        .AddField("Error:", $"```Error: {result}```")
                        .WithColor(252, 3, 3)
                        .WithCurrentTimestamp();

                    var embed = builder.Build();

                  await context.Channel.SendMessageAsync(null, false, embed);

                    
                }
            }
        }

        public Task OnReady()
        {
            //_discord.SetGameAsync("Version 1.4.0");
            Console.WriteLine("Brobot is up and running!");
            Console.WriteLine($"Connected as: {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");
            return Task.CompletedTask;
        }
    }
}
