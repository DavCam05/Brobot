using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brobot.Models.Economy;
using Discord.WebSocket;
using RestSharp;

namespace Brobot.Helpers
{
    public class EconomyHelper
    {
        public static void DepositEconomy(ulong discordId, string discriminator, string username, ulong coins, string url)
        {
            try
            {
                var client = new RestClient(url+ "/api/v1/economy/createupdateuser");
                var request = new RestRequest(Method.POST);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                EconomyRequest economyRequest = new EconomyRequest();
                economyRequest.discordID = discordId;
                economyRequest.discriminator = discriminator;
                economyRequest.username = username;

                request.AddJsonBody(economyRequest);
                IRestResponse response = client.Post(request);
                Console.WriteLine(response.Content); //for logging purposes

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //deposit endpoint
                    var client2 = new RestClient(url+ "/api/v1/economy/depositcoins");
                    var request2 = new RestRequest(Method.POST);
                    ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                    DepositRequest deposit = new DepositRequest();
                    deposit.discordId = discordId;
                    deposit.coins = coins;

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
        }

    }
}
