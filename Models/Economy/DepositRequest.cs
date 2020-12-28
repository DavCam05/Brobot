using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models.Economy
{
    class DepositRequest
    {
        public ulong discordId { get; set; }
        public ulong coins { get; set; }
    }
}
