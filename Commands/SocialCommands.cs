using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Brobot.Commands
{
    public class SocialCommands : ModuleBase
    {
        [Command("github")]
        public async Task GitHub()
        {
            var builder = new EmbedBuilder()
                .WithTitle("GitHub Repository")
                .WithUrl("https://github.com/DavCam05/Brobot")
                .WithDescription("GitHub Repository for the bot. If you need to post feature requests or if you notice a bug just head over there and create an issue")
                .WithColor(250, 250, 250);

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            
        }

        [Command("donate")]
        public async Task Donate()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Donate")
                .WithUrl("https://streamelements.com/davidekingofitaly/tip")
                .WithDescription("Donate to the owner of the bot. The link sends you to StreamElements tip page. run `social.twitch` to know when TheDeveloper#2860 streams. You can also donate on https://patreon.com/davidecammarano")
                .WithColor(3, 69, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);

        }

        [Command("twitch")]
        public async Task Twitch()
        {
            var builder = new EmbedBuilder()
                .WithTitle("DavCam0055's Twitch Page")
                .WithUrl("https://twitch.tv/davidekingofitaly")
                .WithDescription("Davide, King of Italy (TheDeveloper#2860) streams on twitch, check the page to know more")
                .WithColor(169, 3, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }

        [Command("vote")]
        public async Task Vote()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Brobot's Page!")
                .WithUrl("https://top.gg/bot/755427910306889820")
                .WithDescription("Go vote the bot!!!!!!")
                .WithColor(169, 3, 252);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
