using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using IMDbApiLib.Models;
using JikanDotNet;

namespace Brobot.Commands
{
    public class ModCommands : ModuleBase
    {
        [RequireBotPermission(GuildPermission.BanMembers, ErrorMessage = "The bot does not have BanMembers permission")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "You need to have BanMembers permission to use this command")]
        [Command("ban")]
        public async Task BanUser(SocketGuildUser user)
        {
            await user.BanAsync();
            await Context.Guild.AddBanAsync(user);
            await Context.Channel.SendMessageAsync($"The user {user} has been banned by {Context.User.Username}. Next time follow those damn rules");
        }

        [RequireBotPermission(GuildPermission.KickMembers, ErrorMessage = "The bot does not have KickMembers permission")]
        [RequireUserPermission(GuildPermission.KickMembers, ErrorMessage = "You need to have the KickMembers permission")]
        [Command("kick")]
        public async Task KickUser(SocketGuildUser user)
        {
            await user.KickAsync();
            await Context.Channel.SendMessageAsync($"The user {user} has been kicked by {Context.User.Username}. Next time follow those damn rules");
        }

        [RequireBotPermission(GuildPermission.ManageRoles, ErrorMessage = "The bot requires the ManageRoles permission")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "You need to have the ManageRoles permission")]
        [Command("addrole")]
        public async Task AddRole(IRole role, SocketGuildUser user)
        {
            await user.AddRoleAsync(role);
            await Context.Channel.SendMessageAsync($"The {role} role was added to {user}");
        }

        [RequireBotPermission(GuildPermission.ManageRoles, ErrorMessage = "The bot requires the ManageRoles permission")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "You need to have the ManageRoles permission")]
        [Command("remrole")]
        public async Task RemoveRole(IRole role, SocketGuildUser user)
        {
            await user.RemoveRoleAsync(role);
            await Context.Channel.SendMessageAsync($"The {role} role was removed from {user}");
        }

        [Command("newtext")]
        [RequireBotPermission(GuildPermission.ManageChannels, ErrorMessage = "The bot require the ManageChannels permission")]
        [RequireUserPermission(GuildPermission.ManageChannels, ErrorMessage = "You need to have the ManageChannels permission")]
        public async Task CreateText(string channelname)
        {
            await Context.Guild.CreateTextChannelAsync(channelname);
            await Context.Channel.SendMessageAsync($"`{channelname}` has been created. You can now add permissions and move it in your chosen category. The channel is at the top of the left sidebar");
        }

        [Command("newvoice")]
        [RequireUserPermission(ChannelPermission.ManageChannels, ErrorMessage = "You require the ManageChannels permission")]
        [RequireBotPermission(ChannelPermission.ManageChannels, ErrorMessage = "The bot require the ManageChannels permission")]
        public async Task CreateVoice(string channelname)
        {
            await Context.Guild.CreateVoiceChannelAsync(channelname);
            await Context.Channel.SendMessageAsync("Channel has been created. You can now add permissions and move it in your chosen category. The channel is at the top of the left sidebar");
        }

        [Command("newrole")]
        [RequireUserPermission(GuildPermission.ManageRoles, ErrorMessage = "You require the ManageRoles permission")]
        [RequireBotPermission(GuildPermission.ManageRoles, ErrorMessage = "The bot requires the ManageRoles permission")]
        public async Task CreateRole(string rolename)
        {
            await Context.Guild.CreateRoleAsync($"{rolename}", null, null, false, null);
            await Context.Channel.SendMessageAsync($"The `{rolename}` role has been created. You may now go and edit the permission for said role.");
        }
    }
}
