﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
using RestSharp;
using RestSharp.Extensions;
using WikipediaNet;
using WikipediaNet.Objects;
using YamlDotNet.Core.Tokens;
using YamlDotNet.RepresentationModel;

namespace Brobot.Commands
{
    public class FetchApi : ModuleBase
    {

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
        }

        [Command("memetemplates")]
        public async Task MemesTemplates()
        {
            var service = new ImgFlipService(new ImgFlipOptions());
            var template = await service.GetRandomMemeTemplateAsync();

            await Context.Channel.SendMessageAsync($"{template.Url}");
        }

        [Command("news")]
        public async Task FetchNews(string query)
        {
            var newsApiClient = new NewsApiClient("API KEY GOES HERE");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = query,
                SortBy = SortBys.Popularity,
                Language = Languages.EN
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                await Context.Channel.SendMessageAsync($"Results Found: {articlesResponse.TotalResults}");
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

        [Command("moviesearch")]
        public async Task IMDbSearch(string query)
        {
            var apiLib = new ApiLib("API KEY GOES HERE");

            // Search
            var data = await apiLib.SearchMovieAsync(query);


            var builder = new EmbedBuilder()
                .WithTitle(data.Results.First().Title)
                .WithDescription("Due to limitations on the API, please copy the id and run `bro!IMDb [ID]`")
                .WithImageUrl(data.Results.First().Image)
                .AddField("ID", data.Results.First().Id)
                .WithColor(244, 252, 3);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("IMDb")]
        public async Task IMDbMovie(string id)
        {

            var apiLib = new ApiLib("API KEY GOES HERE");

            // Search
            var data = await apiLib.TitleAsync(id);


            var builder = new EmbedBuilder()
                .WithTitle(data.Title)
                .WithDescription(data.Plot + ".")
                .WithImageUrl(data.Image)
                .AddField("Year", data.Year + ".")
                .AddField("Awards", data.Awards + ".")
                .AddField("Rating", data.IMDbRating + ".")
                .AddField("Writers", data.Writers + ".")
                .AddField("Duration", data.RuntimeMins + ".")
                .AddField("Genres", data.Genres + ".")
                .AddField("Age Rating", data.ContentRating + ".")
                .WithColor(244, 252, 3);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("tvsearch")]
        public async Task IMDbTVSearch(string query)
        {
            var apiLib = new ApiLib("API KEY GOES HERE"); 

            // Search
            var data = await apiLib.SearchSeriesAsync(query);


            var builder = new EmbedBuilder()
                .WithTitle(data.Results.First().Title)
                .WithDescription("Due to limitations on the API, please copy the id and run `bro!IMDb [ID]`")
                .WithImageUrl(data.Results.First().Image)
                .AddField("ID", data.Results.First().Id)
                .WithColor(244, 252, 3);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }


    }
}

