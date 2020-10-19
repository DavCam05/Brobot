﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

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

    }
}
