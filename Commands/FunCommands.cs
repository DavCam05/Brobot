using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Brobot.Models;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using RestSharp;
using static Brobot.Models.AnimalFacts;
using static Brobot.Models.AnimalImages;
using static Brobot.Models.Animu;

namespace Brobot.Commands
{
    public class FunCommands : ModuleBase
    {
        private readonly Random random = new Random();
        public static DiscordSocketClient _discord;

        public FunCommands(DiscordSocketClient discord)
        {
            _discord = discord;
        }

        [Command("8ball")]
        public async Task EightBall(string question)
        {
            int randomNumber = random.Next(1, 20);

            switch (randomNumber)
            {
                case 1:
                    await Context.Channel.SendMessageAsync("It is certain.");
                    break;
                case 2:
                    await Context.Channel.SendMessageAsync("It is decidedly so.");
                    break;
                case 3:
                    await Context.Channel.SendMessageAsync("Without a doubt");
                    break;
                case 4:
                    await Context.Channel.SendMessageAsync("Yes - Definitely");
                    break;
                case 5:
                    await Context.Channel.SendMessageAsync("You may rely on it");
                    break;
                case 6:
                    await Context.Channel.SendMessageAsync("As I see it, yes");
                    break;
                case 7:
                    await Context.Channel.SendMessageAsync("Most Likely");
                    break;
                case 8:
                    await Context.Channel.SendMessageAsync("Outlook good");
                    break;
                case 9:
                    await Context.Channel.SendMessageAsync("Yes");
                    break;
                case 10:
                    await Context.Channel.SendMessageAsync("Signs point to yes");
                    break;
                case 11:
                    await Context.Channel.SendMessageAsync("Reply hazy, try again");
                    break;
                case 12:
                    await Context.Channel.SendMessageAsync("Ask Again Later");
                    break;
                case 13:
                    await Context.Channel.SendMessageAsync("Better not tell you now");
                    break;
                case 14:
                    await Context.Channel.SendMessageAsync("Cannot predict now");
                    break;
                case 15:
                    await Context.Channel.SendMessageAsync("Concentrate and ask again");
                    break;
                case 16:
                    await Context.Channel.SendMessageAsync("Don't count on it");
                    break;
                case 17:
                    await Context.Channel.SendMessageAsync("My reply is no");
                    break;
                case 18:
                    await Context.Channel.SendMessageAsync("My sources say no");
                    break;
                case 19:
                    await Context.Channel.SendMessageAsync("Outlook is not good");
                    break;
                case 20:
                    await Context.Channel.SendMessageAsync("Very Doubtful");
                    break;


            }
        }
        [Command("eval")]
        public async Task EvalEastereEgg()
        {
            await Context.Channel.SendMessageAsync("I have just `rm -rf /` your brain");
        }

        [Command("coin")]
        public async Task Coin()
        {
            int randomNumber = random.Next(1, 3);

            switch (randomNumber)
            {
                case 1:
                    await Context.Channel.SendMessageAsync("Heads!");
                    break;

                case 2:
                    await Context.Channel.SendMessageAsync("Tails!");
                    break;
            }

        }
        
        [Command("gf")]
        public async Task LookingForGf()
        {
            await Context.Channel.SendMessageAsync($"the lonely guy that run the command needs a girlfriend! Somebody make him happy");
            
        }
        [Command("bf")]
        public async Task LookingForbf()
        {
            await Context.Channel.SendMessageAsync($"the lonely girl that run the command needs a boyfriend! Somebody make her happy");

        }
        [Command("lesbian")]
        public async Task LookingForlesbian()
        {
            await Context.Channel.SendMessageAsync($"the lonely girl that run the command needs a girlfriend! Somebody make her happy");

        }
        [Command("gay")]
        public async Task LookingForGay()
        {
            await Context.Channel.SendMessageAsync($"the lonely boy that run the command needs a boyfriend! Somebody make him happy");

        }

        [Command("dogfact")]
        public async Task GetRandomDogFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/dog");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Dog Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("catfact")]
        public async Task GetRandomCatFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/cat");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Cat Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }

        [Command("pandafact")]
        public async Task GetRandomPandaFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/panda");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Panda Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("racoonfact")]
        public async Task GetRandomRacoonFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/racoon");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Racoon Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }

        [Command("foxfact")]
        public async Task GetRandomFoxFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/fox");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Fox Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }

        [Command("koalafact")]
        public async Task GetRandomKoalaFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/koala");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Koala Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("kangaroofact")]
        public async Task GetRandomKangarooFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/kangaroo");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Kangaroo Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("birbfact")]
        public async Task GetRandomBirbFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/birb");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Birb Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("elephantfact")]
        public async Task GetRandomElephantFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/elephant");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Elephant Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("giraffefact")]
        public async Task GetRandomGiraffeFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/giraffe");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Giraffe Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("whalefact")]
        public async Task GetRandomWhaleFact()
        {
            var client = new RestClient($"https://some-random-api.ml/facts/whale");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Animal animal = JsonConvert.DeserializeObject<Animal>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Random Whale Facts")
                .WithDescription($"{animal.fact}")
                .WithFooter(" From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }

        [Command("dogimg")]
        public async Task GetRandomDogImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/dog");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Doggo")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("catimg")]
        public async Task GetRandomCatImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/cat");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Cat")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("pandaimg")]
        public async Task GetRandomPandaImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/panda");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Panda")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("foximg")]
        public async Task GetRandomFoxImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/fox");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Fox")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("birbimg")]
        public async Task GetRandomBirbImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/birb");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Birb")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("kialaimg")]
        public async Task GetRandomKoalaImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/koala");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Koala")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("Kangarooimg")]
        public async Task GetRandomKangarooImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/kangaroo");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Kangaroo")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("Racoonimg")]
        public async Task GetRandomRacoonImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/racoon");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Racoon")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("Whaleimg")]
        public async Task GetRandomWhaleImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/whale");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Whale")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("Pikachuimg")]
        public async Task GetRandomPikachuImage()
        {
            var client = new RestClient($"https://some-random-api.ml/img/pikachu");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            AnimalImage animalimages = JsonConvert.DeserializeObject<AnimalImage>(response.Content);
            Console.WriteLine(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle("Pickachu")
                .WithImageUrl($"{animalimages.link}")
                .WithFooter("From Some Random API");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("animu")]
        public async Task GetAnimuGif(string category)
        {
            if(category == "wink")
            {
                var client = new RestClient($"https://some-random-api.ml/animu/wink");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);


                AnimuImage animu = JsonConvert.DeserializeObject<AnimuImage>(response.Content);

                await Context.Channel.SendMessageAsync(animu.link);
            }else if(category == "pat")
            {
                var client = new RestClient($"https://some-random-api.ml/animu/pat");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);


                AnimuImage animu = JsonConvert.DeserializeObject<AnimuImage>(response.Content);

                await Context.Channel.SendMessageAsync(animu.link);
            }else if(category == "hug")
            {
                var client = new RestClient($"https://some-random-api.ml/animu/hug");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);


                AnimuImage animu = JsonConvert.DeserializeObject<AnimuImage>(response.Content);

                await Context.Channel.SendMessageAsync(animu.link);
            }else if(category == "face palm")
            {
                var client = new RestClient($"https://some-random-api.ml/animu/face-palm");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);


                AnimuImage animu = JsonConvert.DeserializeObject<AnimuImage>(response.Content);

                await Context.Channel.SendMessageAsync(animu.link);
            }
            else
            {
                await Context.Channel.SendMessageAsync("You need to specify a category. Choose from:" +
                    "\n `face palm`" +
                    "\n `wink`" +
                    "\n `hug`" +
                    "\n `pat`");
            }
            

        }

        [Command("ytcomment")]
        public async Task CreateYTComment(string avatar, string username, string comment)
        {
            await Context.Channel.SendMessageAsync($"https://some-random-api.ml/canvas/youtube-comment?avatar={avatar}&username={username}&comment={comment}");

        }

        [Command("viewcolor")]
        public async Task CreateColor(string hex)
        {
            await Context.Channel.SendMessageAsync($"https://some-random-api.ml/canvas/colorviewer?hex={hex}");
        }

        [Command("filterimg")]
        public async Task FilterImg(string filter, string avatarLink)
        {
            if (filter == null)
            {
                await Context.Channel.SendMessageAsync("Please instet a valid filter: greyscale, invert, brightness, threshold, sepia, red, green, blue, blurple, pixelate, blur");
            }
            await Context.Channel.SendMessageAsync($"https://some-random-api.ml/canvas/{filter}?avatar={avatarLink}");
        }



    }
}
