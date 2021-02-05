using System;
using System.Net;
using System.Threading.Tasks;
using Brobot.Models.Economy;
using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Brobot.Commands
{
    public class Economy : ModuleBase
    {

        public static IConfigurationRoot _config;
        public Economy(IConfigurationRoot config)
        {
            _config = config;

        }
        [Command("balance")]
        public async Task CheckBal()
        {
            var client = new RestClient(_config["brobotapibaseurl"] +"/api/v1/economy/getbalance/");
            var request = new RestRequest(Method.POST); 
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            BalanceRequest balance = new BalanceRequest();
            balance.discordId = Context.User.Id;

            request.AddJsonBody(balance);
            IRestResponse response = client.Post(request);
            Console.WriteLine(response.Content); //for logging purposes
            BalanceResponse result = JsonConvert.DeserializeObject<BalanceResponse>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle($"Balance for {Context.User.Username}")
                .AddField("Current Balance:", $"{result.balance} coins")
                //.AddField("Last Updated", $"{result.lastUpdate}")
                .WithColor(3, 115, 9);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);

            
        }

    }
}
