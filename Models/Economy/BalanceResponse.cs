using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models.Economy
{
    class BalanceResponse
    {
        public long userId { get; set; }
        public ulong balance { get; set; }
        public DateTime lastUpdate { get; set; }

    }
}
