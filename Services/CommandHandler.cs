using System;
using System.Net;
using System.Threading.Tasks;
using Brobot.Models.Economy;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using RestSharp;

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

                    var builder = new EmbedBuilder()
                        .WithTitle("Error")
                        .WithDescription("There has been an error in executing your command. If you encounter further problems please run the command `bro!github`. Error definitions are here: `bro!errorcodes`")
                        .AddField("Error:", $"```{result}```")
                        .WithColor(252, 3, 3)
                        .WithCurrentTimestamp();

                    var embed = builder.Build();

                  await context.Channel.SendMessageAsync(null, false, embed);

                    
                }
            }
            else
            {
                Console.WriteLine("Recieved message");
                if (msg.Author.IsBot) return;

                try
                {
                    var client = new RestClient("http://192.168.0.65:5000/api/v1/economy/createupdateuser");
                    var request = new RestRequest(Method.POST);
                    ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                    EconomyRequest economyRequest = new EconomyRequest();
                    economyRequest.discordID = msg.Author.Id;
                    economyRequest.discriminator = msg.Author.Discriminator;
                    economyRequest.username = msg.Author.Username;

                    request.AddJsonBody(economyRequest);
                    IRestResponse response = client.Post(request);
                    Console.WriteLine(response.Content); //for logging purposes

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        //deposit endpoint
                        var client2 = new RestClient("http://192.168.0.65:5000/api/v1/economy/depositcoins");
                        var request2 = new RestRequest(Method.POST);
                        ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                        DepositRequest deposit = new DepositRequest();
                        deposit.discordId = msg.Author.Id;
                        deposit.coins = 5;

                        request2.AddJsonBody(deposit);
                        IRestResponse response2 = client2.Post(request2);
                        Console.WriteLine(response2.Content); //for logging purposes

                    }
                    else
                    {
                        Console.WriteLine("There has been an error in doing this. please check NOW");
                    }




                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }


                await Task.CompletedTask;
            }
        }

        public Task OnReady()
        {
            //_discord.SetGameAsync("Version 1.4.0");
            //Console.WriteLine("Brobot is up and running!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Connected as: {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");
            Console.ResetColor();
            return Task.CompletedTask;
        }
    }
}
