using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Brobot.Helpers;
using Brobot.Models;
using Discord;
using Discord.Commands;
using IMDbApiLib;
using IMDbApiLib.Models;
using ImgFlip4NET;
using JikanDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json;
using PokeApiNet;
using RestSharp;
using RestSharp.Extensions;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using WikipediaNet;
using WikipediaNet.Objects;
using YamlDotNet.Core.Tokens;
using YamlDotNet.RepresentationModel;
using static Brobot.Models.DeezerResult;
using static Brobot.Models.IMDbSearchResult;
using static Brobot.Models.JokeResult;
using static Brobot.Models.RAWGAPI;
namespace Brobot.Commands
{
    public class FetchApi : ModuleBase
    {
        public static IConfigurationRoot _config;
        public FetchApi(IConfigurationRoot config)
        {
            _config = config;

        }

        [Command("anime")] //command name
        public async Task Anime(string query) //command method
        {
            Console.WriteLine("Search query: " + query);

            IJikan jikan = new Jikan();

            var services = new ServiceCollection().AddSingleton<IJikan, Jikan>().BuildServiceProvider();

            AnimeSearchResult result = await jikan.SearchAnime(query);

            if (result == null)
            {
                await Context.Channel.SendMessageAsync("Your search query returned nothing. Please check spelling and try again" +
                    "\n if the problem persists please make an issue on the bot's github (run `bro!github`)");
                return;

            }
            else
            {

                var builder = new EmbedBuilder()
                    .WithTitle(result.Results.First().Title)
                    .WithDescription(result.Results.First().Description)
                    .WithImageUrl(result.Results.First().ImageURL)
                    .AddField("MyAnimeList 🆔", result.Results.First().MalId, true)
                    .AddField("Age Rating 🔞", $"{ result.Results.First().Rated}. ", true)
                    .AddField("Episode Count 🎞️", $"{result.Results.First().Episodes}. ", true)
                    .AddField("Start Date 📅", $"{result.Results.First().StartDate}. ", true)
                    .AddField("Airing? 📺", $"{result.Results.First().Airing}. ", true)
                    .AddField("End Date 📅", $"{result.Results.First().EndDate}. ", true)
                    .AddField("Score ⭐", $"{result.Results.First().Score}.", true)
                    .AddField("Type 📽️", $"{result.Results.First().Type}.", true)
                    .AddField("Anime Members count on MAL 🧑🏻‍🤝‍🧑🏽", $"{result.Results.First().Members}.", true)
                    .WithFooter($"{result.Results.First().URL}. ")
                    .WithColor(242, 145, 0);

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
                Console.WriteLine("Search was Successful");
                EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 10, _config["brobotapibaseurl"]);
            }
        }

        [Command("manga")]
        public async Task Manga(string query)
        {
            Console.WriteLine("Search query: " + query);
            if (string.IsNullOrEmpty(query))
            {
                await Context.Channel.SendMessageAsync("Search Failed." +
                    "\n No query was specified");

                return;
            }
            IJikan jikan = new Jikan();

            var services = new ServiceCollection().AddSingleton<IJikan, Jikan>().BuildServiceProvider();

            MangaSearchResult result = await jikan.SearchManga(query);
            if (result == null)
            {
                await Context.Channel.SendMessageAsync("Your search query returned nothing. Please check spelling and try again" +
                    "\n if the problem persists please make an issue on the bot's github (run `bro!github`)");
                return;

            }
            else
            {


                var builder = new EmbedBuilder()
                    .WithTitle(result.Results.First().Title)
                    .WithDescription(result.Results.First().Description)
                    .WithImageUrl(result.Results.First().ImageURL)
                    .AddField("MyAnimeList 🆔", result.Results.First().MalId, true)
                    .AddField("Chapter 📘", $"{result.Results.First().Chapters}. ", true)
                    .AddField("Volumes 📗", $"{result.Results.First().Volumes}.", true)
                    .AddField("Start Date 📅", $"{result.Results.First().StartDate}. ", true)
                    .AddField("Publishing? 📚", $"{result.Results.First().Publishing}. ", true)
                    .AddField("End Date 📅", $"{result.Results.First().EndDate}. ", true)
                    .AddField("Score ⭐", $"{result.Results.First().Score}. ", true)
                    .AddField("Type 📖 ️", $"{result.Results.First().Type}. ", true)
                    .AddField("Manga Members count on MAL 🧑🏻‍🤝‍🧑🏽", $"{result.Results.First().Members}. ", true)
                    .WithFooter($"{result.Results.First().URL}. ")
                    .WithColor(157, 252, 3);

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
                Console.WriteLine("Search was Successful");
                EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 10, _config["brobotapibaseurl"]);
            }
        }

        [Command("malcharacter")]
        public async Task MangaCharacter(string query)
        {
            Console.WriteLine("Search query: " + query);
            IJikan jikan = new Jikan();

            var services = new ServiceCollection().AddSingleton<IJikan, Jikan>().BuildServiceProvider();

            CharacterSearchResult result = await jikan.SearchCharacter(query);

            var builder = new EmbedBuilder()
                .WithTitle(result.Results.First().Name)
                .WithImageUrl(result.Results.First().ImageURL)
                .AddField("MyAnimeList 🆔", result.Results.First().MalId, true)
                .WithFooter($"{result.Results.First().URL}. ")
                .WithColor(245, 120, 66);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
            Console.WriteLine("Search was Successful");
            EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 10, _config["brobotapibaseurl"]);
        }

        [Command("memetemplates")]
        public async Task MemesTemplates()
        {
            var service = new ImgFlipService(new ImgFlipOptions());
            var template = await service.GetRandomMemeTemplateAsync();

            await Context.Channel.SendMessageAsync($"{template.Url}");
            EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 2, _config["brobotapibaseurl"]);
        }

        [Command("news")]
        public async Task FetchNews(string query)
        {
            var apikey = _config["newskey"].ToString();
            var newsApiClient = new NewsApiClient($"{apikey}");
            var articlesResponse = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest
            {
                Q = query,
                Language = Languages.EN,
                PageSize = 4
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                await Context.Channel.SendMessageAsync($"Results Found: {articlesResponse.TotalResults}");
                EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 7, _config["brobotapibaseurl"]);
                // total results found
                Console.WriteLine(articlesResponse.TotalResults);
                // here's the first 20
                foreach (var article in articlesResponse.Articles)
                {

                    var builder = new EmbedBuilder()
                        .WithTitle($"{article.Title}.")
                        .WithUrl($"{article.Url}")
                        .WithDescription($"{article.Description}.")
                        .AddField("Author", $"{article.Author}.")
                        .WithImageUrl($"{article.Url}.")
                        .WithFooter($"{article.PublishedAt}.")
                        .WithColor(11, 3, 252);

                    var embed = builder.Build();
                    await Context.Channel.SendMessageAsync(null, false, embed);
                }
            }
        }

        [Command("imdb")]
        public async Task IMDbFilmSearch(string movie)
        {
            var apikey = _config["imdbkey"].ToString();
            var client = new RestClient($"https://imdb-internet-movie-database-unofficial.p.rapidapi.com/film/{movie}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "imdb-internet-movie-database-unofficial.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", $"{apikey}");
            IRestResponse response = client.Execute(request);

            IMDb result = JsonConvert.DeserializeObject<IMDb>(response.Content);

            var builder = new EmbedBuilder() // add emojis to the embed
                .WithTitle($"{result.title}")
                .WithDescription($"{result.plot}.")
                .WithImageUrl($"{result.poster}")
                .AddField("Rating", $"{result.rating}.", true)
                .AddField("Year", $"{result.year}.", true)
                .AddField("Lenght", $"{result.length}.", true)
                .AddField("IMDb ID", $"{result.id}", true)
                .WithColor(235, 229, 52)
                .WithFooter("From IMDb");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
            EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 20, _config["brobotapibaseurl"]);

        }

        [Command("music")]
        public async Task MusicSearch(string song)
        {
            var apikey = _config["deezerkey"];
            var client = new RestClient($"https://deezerdevs-deezer.p.rapidapi.com/search?q={song}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "deezerdevs-deezer.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", $"{apikey}");
            IRestResponse response = client.Execute(request);

            Deezer result = JsonConvert.DeserializeObject<Deezer>(response.Content);


            var builder = new EmbedBuilder()
                .WithTitle($"{result.data.First().title}")
                .WithUrl($"{result.data.First().link}")
                .AddField("Duration 🕰️", $"{result.data.First().duration}.")
                .AddField("Rank ⭐", $"{result.data.First().rank}.")
                .AddField("Artist 🧑‍🎤", $"{result.data.First().artist.name}.")
                .AddField("Album :cd: ", $"{result.data.First().album.title}.")
                .WithImageUrl($"{result.data.First().artist.picture}")
                .WithThumbnailUrl($"{result.data.First().album.cover}")
                .WithColor(8, 8, 8);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
            EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 1, _config["brobotapibaseurl"]);

        }

        [Command("dadjoke")]
        public async Task GetJoke()
        {
            var apikey = _config["jokekey"];
            var client = new RestClient("https://dad-jokes.p.rapidapi.com/random/joke");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "dad-jokes.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", $"{apikey}");
            IRestResponse response = client.Execute(request);

            Joke result = JsonConvert.DeserializeObject<Joke>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle($"{result.body.First().setup}")
                .WithDescription($"{result.body.First().punchline}")
                .WithColor(64, 21, 71);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
            EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 100, _config["brobotapibaseurl"]);
        }

        [Command("game")]
        public async Task GetGame(string name)
        {
            var client = new RestClient($"https://api.rawg.io/api/games/{name}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            RAWG result = JsonConvert.DeserializeObject<RAWG>(response.Content);

            var builder = new EmbedBuilder()
                .WithTitle(result.name)
                .WithDescription($"{result.description}.")
                //.WithThumbnailUrl($"{result.background_image}")
                //.AddField("Rating", $"{result.rating}.")
                .AddField("Released", $"{result.released}.")
                .AddField("Last Updated", $"{result.updated}.")
                .AddField("Website", $"{result.website}.")
                .AddField("Sub Reddit", $"{result.reddit_url}.")
                .AddField("Information By", "RAWG Game Database")
                .WithImageUrl($"{result.background_image}")
                .WithColor(35, 43, 69);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
            EconomyHelper.DepositEconomy(Context.User.Id, Context.User.Discriminator, Context.User.Username, 10, _config["brobotapibaseurl"]);
        }

        [Command("pokemon")] //Command still in development, DO NOT ADD TO HELP COMMAND 
        public async Task GetPokemon(string pokemon)
        {
            PokeApiClient pokeApiClient = new PokeApiClient();

            Pokemon poke = await pokeApiClient.GetResourceAsync<Pokemon>(pokemon);

            var builder = new EmbedBuilder()
                .WithTitle(poke.Name)
                .AddField("Weight", poke.Weight)
                .AddField("Height", poke.Height)
                .AddField("Base XP", poke.BaseExperience)
                .AddField("Species", poke.Species.Name)
                //.AddField("", poke.)
                //.AddField("Abilities", poke.Abilities.ToList())
                //.AddField("Stats", poke.Stats.ToList())
                .WithColor(255, 255, 0)
                .WithThumbnailUrl(poke.Sprites.FrontDefault);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("steam")]
        public async Task SteamGames(uint gameid)
        {
            var webInterfaceFactory = new SteamWebInterfaceFactory(_config["steamkey"]);
            var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamStore>(new HttpClient());
            var searchedGame = await steamInterface.GetStoreAppDetailsAsync(gameid);

            await Context.Channel.SendMessageAsync(searchedGame.Name);
        }
    }
}
