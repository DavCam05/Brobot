using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Brobot.Models;
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
            var client = new RestClient($"http://192.168.0.65:5000/api/v1/economy/getbalance/{Context.User.Id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            EconomyModel result = JsonConvert.DeserializeObject<EconomyModel>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle($"Balance for {Context.User.Username}")
                .AddField("Balance", $"{result.balance}")
                .AddField("Last Updated", $"{result.lastUpdate}");

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        public async Task OnMessageRecieved(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            if (msg.Author.IsBot) return;

            var client = new RestClient($"http://192.168.0.65:5000/api​/v1​/economy​/depositcoins?{Context.User.Id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            await Task.CompletedTask;
        }

    }
}
