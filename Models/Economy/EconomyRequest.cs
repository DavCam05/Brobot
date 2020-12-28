using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using YamlDotNet.Serialization.TypeInspectors;

namespace Brobot.Models.Economy
{
    public class EconomyRequest
    {
        public ulong discordID { get; set; }
        public string username { get; set; }
        public string discriminator { get; set; }
        public Boolean bot { get; set; }
    }
}
