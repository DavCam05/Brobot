using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class Calculator : ModuleBase
    {
        [Command("maths")]
        public async Task Math()
        {
            await Context.Channel.SendMessageAsync("69+420*3.1415(6969)/42069420 = ????" +
                "\n idk, I cannot read your mind. Use `bro!calculator` for help with math commands");
        }
        [Command("calculator")]
        public async Task CalculateMain()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Calculator Commands")
                .WithDescription("This is the calculator main page. Use the following commands to calculate basic maths.")
                .AddField("Addition", "Use the command `add <num 1> <num 2>`")
                .AddField("Subtraction", "use the command `subtract <num 1> <num 2>`")
                .AddField("Division", "Use the command `divide <num 1> <num 2>`")
                .AddField("Multiplications", "Use the command `multiply <num 1> <num 2>`")
                .WithColor(179, 59, 65);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("add")]
        public async Task Add(int num1, int num2)
        {
            var result = num1 + num2;

            var builder = new EmbedBuilder()
                .WithTitle("Addition")
                .WithDescription("A simple addition")
                .AddField("Added", $"{num1} + {num2}")
                .AddField("Result", $"{result}")
                .WithColor(26, 128, 19);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("subtract")]
        public async Task Subtract(int num1, int num2)
        {
            var result = num1 - num2;

            var builder = new EmbedBuilder()
                .WithTitle("Subtraction")
                .WithDescription("A simple subtraction")
                .AddField("Subtracted", $"{num1} - {num2}")
                .AddField("Result", $"{result}")
                .WithColor(26, 128, 19);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("multiply")]
        public async Task Multiply(int num1, int num2)
        {
            var result = num1 * num2;

            var builder = new EmbedBuilder()
                .WithTitle("Multiplication")
                .WithDescription("A simple multiplication")
                .AddField("Multiplied", $"{num1} * {num2}")
                .AddField("Result", $"{result}")
                .WithColor(26, 128, 19);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("divide")]
        public async Task Divide(int num1, int num2)
        {
            if (num2 == 0)
            {
                await Context.Channel.SendMessageAsync("You idiot. You cannot divide numbers by 0 it is impossible. Go learn maths and come back to me when you know it perfectly");
            }
            var result = num1 / num2;

            var builder = new EmbedBuilder()
                .WithTitle("Division")
                .WithDescription("A simple division")
                .AddField("divided", $"{num1} / {num2}")
                .AddField("Result", $"{result}")
                .WithColor(26, 128, 19);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
