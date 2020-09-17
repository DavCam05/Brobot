using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace Brobot
{
    class Program
    {

        static void Main(string[] args)
        {
            //starts the bot
            Bot bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
   
    }
}
