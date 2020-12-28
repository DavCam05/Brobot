using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Brobot.Models;
using Brobot.Models.Economy;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using RestSharp;

namespace Brobot.Commands
{
    public class Economy : ModuleBase
    {
        [Command("balance")]
        public async Task CheckBal()
        {
            var client = new RestClient($"http://192.168.0.65:5000/api/v1/economy/getbalance/");
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
                .AddField("Last Updated", $"{result.lastUpdate}")
                .WithColor(3, 115, 9);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);

            
        }

    }
}
