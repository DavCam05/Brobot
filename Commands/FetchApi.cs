using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using JikanDotNet;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Brobot.Commands   
{
    public class FetchApi : ModuleBase
    {
        [Command("fetch.anime")]
        public async Task Anime(string query)
        {
            Console.WriteLine("Search query: " + query);
            IJikan jikan = new Jikan();

            var services = new ServiceCollection().AddSingleton<IJikan, Jikan>().BuildServiceProvider();

            AnimeSearchResult result = await jikan.SearchAnime(query);

            var builder = new EmbedBuilder()
                .WithTitle(result.Results.First().Title)
                .WithDescription(result.Results.First().Description)
                .WithImageUrl(result.Results.First().ImageURL)
                .AddField("MyAnimeList 🆔", result.Results.First().MalId, true)
                .AddField("Age Rating 🔞", result.Results.First().Rated, true)
                .AddField("Episode Count 🎞️", result.Results.First().Episodes, true)
                .AddField("Start Date 📅", result.Results.First().StartDate, true)
                .AddField("Airing? 📺", result.Results.First().Airing, true)
                .AddField("End Date 📅", result.Results.First().EndDate, true)
                .AddField("Score ⭐", result.Results.First().Score, true)
                .AddField("Type 📽️", result.Results.First().Type, true)          
                .AddField("Anime Members count on MAL 🧑🏻‍🤝‍🧑🏽", result.Results.First().Members, true)
                .WithFooter(result.Results.First().URL)
                .WithColor(242, 145, 0);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
            Console.WriteLine("Search was Successful");
        }

        [Command("fetch.manga")]
        public async Task Manga(string query)
        {
            Console.WriteLine("Search query: " + query);
            IJikan jikan = new Jikan();

            var services = new ServiceCollection().AddSingleton<IJikan, Jikan>().BuildServiceProvider();

            MangaSearchResult result = await jikan.SearchManga(query);

            var builder = new EmbedBuilder()
                .WithTitle(result.Results.First().Title)
                .WithDescription(result.Results.First().Description)
                .WithImageUrl(result.Results.First().ImageURL)
                .AddField("MyAnimeList 🆔", result.Results.First().MalId, true)
                .AddField("Chapter 📘", result.Results.First().Chapters, true)
                .AddField("Volumes 📗", result.Results.First().Volumes, true)
                .AddField("Start Date 📅", result.Results.First().StartDate, true)
                .AddField("Publishing? 📚", result.Results.First().Publishing, true)
                .AddField("End Date 📅", result.Results.First().EndDate, true)
                .AddField("Score ⭐", result.Results.First().Score, true)
                .AddField("Type 📖 ️", result.Results.First().Type, true)
                .AddField("Manga Members count on MAL 🧑🏻‍🤝‍🧑🏽", result.Results.First().Members, true)
                .WithFooter(result.Results.First().URL)
                .WithColor(157, 252, 3);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
            Console.WriteLine("Search was Successful");
        }

    }
}
