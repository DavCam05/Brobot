using System;
using System.Collections.Generic;
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

        [Command("lottery active")]
        public async Task ActiveDraws()
        {
            int status = 2;
            var client = new RestClient(_config["brobotapibaseurl"] + $"/api/v1/economy/lottery/getdrawbystatus/{status}");
            var request = new RestRequest(Method.GET);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            IRestResponse response = client.Execute(request);
            List<DrawResponse> result = null;
            ErrorResponse error = null;
            try
            {
                result = JsonConvert.DeserializeObject<List<DrawResponse>>(response.Content);
            } catch(Exception ex)
            {
                error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            }

            var builder = new EmbedBuilder()
                .WithTitle("Active Lotteries").WithColor(235, 168, 52);
            if (result !=null)
            {
                foreach (var draw in result)
                {
                    builder.AddField("Start Date", draw.startDate);
                    builder.AddField("Ticket Cost", draw.ticketCost);
                    builder.AddField("Draw Time", draw.drawDate);
                    builder.AddField("Prize", draw.prize);
                    builder.AddField("Draw Id", draw.drawId);
                    builder.AddField("------------------", "------------------");
                }
            } else
            {
                builder.WithDescription("No Lottery Availabe");
            }
           
            
            
            var embed = builder.Build();
                
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("lottery closed")]
        public async Task ClosedDraws()
        {
            int status = 4;
            var client = new RestClient(_config["brobotapibaseurl"] + $"/api/v1/economy/lottery/getdrawbystatus/{status}");
            var request = new RestRequest(Method.GET);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            IRestResponse response = client.Execute(request);
            List<DrawResponse> result = null;
            ErrorResponse error = null;
            try
            {
                result = JsonConvert.DeserializeObject<List<DrawResponse>>(response.Content);
            }
            catch (Exception ex)
            {
                error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            }

            var builder = new EmbedBuilder()
                .WithTitle("Closed Lotteries").WithColor(235, 168, 52);
            if (result != null)
            {
                foreach (var draw in result)
                {
                    
                    builder.AddField("Start Date", draw.startDate);
                    builder.AddField("Ticket Cost", draw.ticketCost);
                    builder.AddField("Draw Time", draw.drawDate);
                    builder.AddField("Prize", draw.prize);
                    builder.AddField("Draw Id", draw.drawId);
                    builder.AddField("------------------", "------------------");
                }
            }
            else
            {
                builder.WithDescription("No Lottery Availabe");
            }



            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("lottery buy")]
        public async Task BuyTicket(int id)
        {
            var client = new RestClient(_config["brobotapibaseurl"] + $"/api/v1/economy/lottery/buyticket");
            var request = new RestRequest(Method.POST);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            TicketRequest ticket = new TicketRequest();
            ticket.discordId = Context.User.Id;
            ticket.drawId = id;

            request.AddJsonBody(ticket);

            IRestResponse response = client.Post(request);

            await Context.Channel.SendMessageAsync("Successfully bought ticket! :ticket:");
        }

        [Command("lottery id")]
        public async Task GetDrawById(int drawId)
        {
            var client = new RestClient(_config["brobotapibaseurl"] + $"/api/v1/economy/lottery/getdrawbyid/{drawId}");
            var request = new RestRequest(Method.GET);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            IRestResponse response = client.Execute(request);
            DrawResponse result = null;
            ErrorResponse error = null;
            try
            {
                result = JsonConvert.DeserializeObject<DrawResponse>(response.Content);
            }
            catch (Exception ex)
            {
                error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            }

            var builder = new EmbedBuilder()
                .WithTitle("Closed Lotteries").WithColor(235, 168, 52);
            if (result != null)
            {
             
                builder.AddField("Start Date", result.startDate);
                builder.AddField("Ticket Cost", result.ticketCost);
                builder.AddField("Draw Time", result.drawDate);
                builder.AddField("Prize", result.prize);
                builder.AddField("Draw Id", result.drawId);
                
            }
            else
            {
                builder.WithDescription("No Lottery Availabe");
            }

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

    }
}
