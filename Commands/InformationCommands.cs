using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Brobot.Commands
{
    public class InformationCommands : ModuleBase
    {
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync($"Pong :ping_pong: \nThat took: {(Context.Client as DiscordSocketClient).Latency}ms");
        }

        [Command("infome")]
        public async Task UserInfo()
        {
            var builder = new EmbedBuilder()
                .WithTitle($"<:discord:314003252830011395> User info for {Context.User.Mention} ")
                .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                .WithDescription("This is your info")
                .WithColor(new Color(33, 176, 252))
                .WithFields()
                .AddField("Your 🆔", Context.User.Id)
                .AddField("Discord Tag 🏷️", Context.User.Discriminator, true)
                .AddField("Discord Username", Context.User.Username)
                .AddField("Account Creation Date 🍰", Context.User.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Joined At 📥", $"{(Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy")}.", true)
               // .AddField("Roles", string.Join(" ", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                .AddField("Activity <a:typing:393848431413559296>", $"{Context.User.Activity}.")
                .AddField("Status <:online2:464520569975603200> <:offline2:464520569929334784> <:away2:464520569862357002> <:dnd2:464520569560498197>", Context.User.Status )
                .AddField("Are you a bot? <:botTag:230105988211015680>", Context.User.IsBot, true)
                .WithCurrentTimestamp();

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("infoother")]
        public async Task OtherUserInfo(SocketGuildUser user = null)
        {
            if (user == null)
            {
                await Context.Channel.SendMessageAsync("You need to mention a user!");
            }
            else
            {
                
                var builder = new EmbedBuilder()
                   .WithTitle($"<:discord:314003252830011395> User info for {user.Mention} ")
                   .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                   .WithDescription("This is your info")
                   .WithColor(new Color(33, 176, 252))
                   .AddField("Your 🆔", user.Id)
                   .AddField("Discord Tag 🏷️", user.Discriminator, true)
                   .AddField("Discord Username", user.Username)
                   .AddField("Account Creation Date 🍰", user.CreatedAt.ToString("dd/MM/yyyy"), true)
                   .AddField("Joined At 📥", user.JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                   // .AddField("Roles", string.Join(" ", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                   //.AddField("Activity <a:typing:393848431413559296>", user.Activity)
                   .AddField("Status <:online2:464520569975603200> <:offline2:464520569929334784> <:away2:464520569862357002> <:dnd2:464520569560498197>", user.Status)
                   .AddField("Are you a bot? <:botTag:230105988211015680>", user.IsBot, true)
                   .WithCurrentTimestamp();

                var embed = builder.Build();

                await Context.Channel.SendMessageAsync(" ", false, embed);
            }

        }

        [Command("serverinfo")]
        public async Task ServerInfo()
        {
            var builder = new EmbedBuilder()
                   .WithTitle($"Server Info for {Context.Guild.Name} ")
                   .WithThumbnailUrl(Context.Guild.IconUrl)
                   .WithDescription("This is the Server Info")
                   .WithColor(new Color(66, 242, 245))
                   .AddField("Server 🆔", Context.Guild.Id)
                   .AddField("Server Name", Context.Guild.Name)
                   .AddField("Server Creation Date 🍰", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                   .AddField("Emotes Count", Context.Guild.Emotes.Count(), true)
                   //.AddField("Online Members 🟢 ", (Context.User as SocketGuild).Users.Where(x => x.Status == UserStatus.Online).Count() + " members", true)
                   // .AddField("Offline Members", (Context.User as SocketGuild).Users.Where(x => x.Status == UserStatus.Offline).Count() + " members", true)
                   // .AddField("Do Not Disturb Members 🔴", (Context.User as SocketGuild).Users.Where(x => x.Status == UserStatus.DoNotDisturb).Count() + " members", true)
                   .WithCurrentTimestamp();

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);

        }
        [Command("time")]
        public async Task Time()
        {
            await Context.Channel.SendMessageAsync($"{DateTime.Now}");
        }

        [Command("errorcodes")]
        public async Task ErrorCodes()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Error Codes")
                .WithDescription("This embed contains all the errors that the bot can give." +
                "\n`BadArgCount`: This means that you haven't provided all the arguments that the command needs" +
                "\n`UnknownCommand`: The command does not exist in the bot. Check your spelling and try again")
                .WithColor(222, 0, 0);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
