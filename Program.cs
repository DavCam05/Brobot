using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace Brobot
{
    class Program
    {

        static void Main(string[] args)
        {
            Bot bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
   
    }
}
