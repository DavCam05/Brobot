using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brobot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;

namespace Brobot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; } //Initialises the bot
        public InteractivityExtension interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
         
        public async Task RunAsync() //Run method
        {
            //gets the config json file
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            //initialises the bot properties
            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,             
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            //initialises the commands properties
            var commandConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new String[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,

            };

            Commands = Client.UseCommandsNext(commandConfig);

            Commands.RegisterCommands<InfoCommands>();
           

            await Client.ConnectAsync(); //connects the bot to discord
            await Task.Delay(-1); //DO NOT REMOVE. This keeps the bot running
        }

        private Task OnClientReady(ReadyEventArgs e) //when the bot is ready this is executed
        {
            return Task.CompletedTask;            
        }

    }
}
