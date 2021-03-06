using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brobot.Models.Guild;

namespace Brobot.Models.Guild
{
    class ServerGuild
    {
        public ulong Id { get; set; } //guild id
        public string Name { get; set; } // guild name (2-100 characters, excluding trailing and leading whitespace)
        public string Icon { get; set; } //icon hash
        public string Icon_Hash { get; set; } //icon hash, returned when in the template object
        public string Splash { get; set; } // splash hash
        public string Discovery_Splash { get; set; } // discovery spash hash only present for guilds with the "Discoverable" feature
        public Boolean Owner {get; set;} //true if the user is the owner of the guild
        public ulong OwnerId { get; set; } //id of the owner
        public string Permissions { get; set; } //total permissions for the user in the guild (excludes override)
        public string Region { get; set; } // voice region id for the guild
        public ulong Afk_Channel_Id { get; set; } // id of the afk channel
        public int Afk_Timeout { get; set; } // afk timeout in seconds
        public Boolean WidgetEnabled { get; set; } //true if server widget is enabled
        public ulong WidgetChannelId { get; set; } //the channel id that the widget will generate an invite to. or null if set to no invite
        public int VerificationLevel { get; set; } //verification level required for the guild
        public int DefaultMessageNotifications { get; set; } //default message notifications level
        public int ExplicitContentFilter { get; set; } //explicit content filter level
        public List<Roles> Roles { get; set; } // array of roles in the guild
        public List<Emojis> Emojis { get; set; } // arrray of all custom emojis in the server
        public List<Features> Features { get; set; } // arrray of all enabled guild feautres
        public int Mfa_level { get; set; } // required MFA level for the guild
        public ulong ApplicationId { get; set; } //application id of the guild creator if it is bot-created
        public ulong SystemChannelId { get; set; } //id of the channel where guild notices such as welcome messages and boosts are posted
        public int SystemChannelFlags { get; set; } // system channel flags
        public ulong RulesChannelId { get; set; } //id of the channel where Community guilds can display rules and/or guidelines
        public DateTime JoinedAt { get; set; } //date of when the guild was joined at
        public Boolean Large { get; set; } //true if it is considered a large guild
        public Boolean Unavailable { get; set; } //true if this guild is unavailable due to outage
        public int MemberCount { get; set; } //member count of all people in the guild
        public List<VoiceStates> Voicestates { get; set; } // array of all states of mebmers currently in thecoice channell. lacks the guild id key
        public List<GuildMember> Member { get; set; } // array of members in  the guild
        public List<GuildChannels> Channels { get; set; } // arrray of all the channels present in thbe guild
        public List<Presences> Presences { get; set;  } //array of presences of members in the guild.
        public int MaxPresences { get; set; } //the maximum number of presences for the guild. the default vaule is 25000 and it is in effect when null is returned
        public int MaxMembers { get; set; } // the maximum number of members the guild has
        public string VanityUrlCode { get; set; } // the vanity url code for the guild
        public string Description { get; set; } //description of the guild if the guild is discoverable
        public string Banner { get; set; } //banner hash
        public int PremiumTier { get; set;  } // server boost level
        public int PremiumSubscriptionCount { get; set; } //the number of boosts that the guild has
        public string PreferredLocale { get; set; }
        public ulong PublicUpdatesChannelId { get; set; }
        public int MaxVideoChannelUsers { get; set; }
        public int AppropriateMemberCount { get; set; }
        public int ApproximatePresenceCount { get; set; }
        public WelcomeScreen WelcomeScreen { get; set; }


    }
}
