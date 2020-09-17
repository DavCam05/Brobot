using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;

namespace Brobot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; } //Initialises the bot
        public CommandsNextExtension Commands { get; private set; } //initialises the commands
        
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

            //initialises the commands properties
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new String[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync(); //connects the bot to discord
            await Task.Delay(-1); //DO NOT REMOVE. This keeps the bot running
        }

        private Task OnClientReady(ReadyEventArgs e) //when the bot is ready this is executed
        {
            return Task.CompletedTask;            
        }

    }
}
