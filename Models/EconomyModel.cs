using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models
{
    public class EconomyModel
    {
        public ulong DiscordId { get; set; }
        public long balance { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
