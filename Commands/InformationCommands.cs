using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            var builder = new EmbedBuilder()
                .WithTitle("Ping Time")
                .WithDescription("The Ping time of the bot!")
                .AddField("Latency", $"```{(Context.Client as DiscordSocketClient).Latency}```", true)
                .AddField("Shard", $"```{(Context.Client as DiscordSocketClient).ShardId}```", true)
                .AddField("Connection State", $"```{(Context.Client as DiscordSocketClient).ConnectionState}```", true)
                .WithColor(3, 252, 28);
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(":ping_pong:", false, embed);
        }

        [Command("infobot")]
        public async Task InfoBot()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Brobot#0605")
                .WithDescription("Brobot is a general purpose bot that does tasks for you!")
                .AddField("Help Center", "to get to the help center you need to use `bro!help`")
                .AddField("Prefix", "Brobot takes 2 prefixes: `bro!` or it's mention")
                .AddField("Developer", "The developer of the bot is TheDeveloper#2860")
                .AddField("Version", "1.4.0");

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
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
            var count = await Context.Guild.GetUsersAsync();
            var users = count.Count();

            var onlineUsers = count.Where(x => x.Status == UserStatus.Online).Count();
            var offlineUsers = count.Where(x => x.Status == UserStatus.Offline).Count();
            var dndUsers = count.Where(x => x.Status == UserStatus.DoNotDisturb).Count();
            var idleUsers = count.Where(x => x.Status == UserStatus.Idle).Count();

            var builder = new EmbedBuilder()
                   .WithTitle($"Server Info for {Context.Guild.Name} ")
                   .WithThumbnailUrl(Context.Guild.IconUrl)
                   .WithDescription("This is the Server Info")
                   .WithColor(new Color(66, 242, 245))
                   .AddField("Server 🆔", Context.Guild.Id)
                   .AddField("Server Name", Context.Guild.Name)
                   .AddField("Server Creation Date 🍰", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                   .AddField("Emotes Count", Context.Guild.Emotes.Count(), true)
                   .AddField("Member Count", $"{users} users are in this server", true )
                   .AddField("Online Members <:online2:464520569975603200> ", $"{onlineUsers} users are online", true)
                   .AddField("Offline Members <:offline2:464520569929334784>", $"{offlineUsers} users are offline", true)
                   .AddField("Do Not Disturb Members <:dnd2:464520569560498197> ",  $"{dndUsers} users are on Do Not Disturb", true)
                   .AddField("Idle Members <:away2:464520569862357002> ", $"{idleUsers} users are idle", true)
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
                "\n```BadArgCount: This means that you haven't provided all the arguments that the command needs```" +
                "\n```UnknownCommand: The command does not exist in the bot. Check your spelling and try again```" +
                "\n```ParseFailed: This means that the bot has failed to parse your command. Check if the command is written correctly```")
                .WithColor(222, 0, 0);

            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("invite")]
        public async Task Invite()
        {
            var builder = new EmbedBuilder()
                .WithTitle("Bot Invite Link")
                .WithDescription("Click the link below to invite the bot to your server!")
                .AddField("Invite Link", "https://discord.com/oauth2/authorize?client_id=755427910306889820&scope=bot&permissions=2146958839")
                .AddField("Support Server", "https://discord.gg/XFs3HRU");
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
