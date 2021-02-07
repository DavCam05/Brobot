using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models.Economy
{
    class DrawResponse
    {
        public int drawId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime drawDate { get; set; }
        public DateTime cutOffTime { get; set; }
        public string drawCode { get; set; }
        public int status { get; set; }
        public int prize { get; set; }
        public int ticketCost { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastUpdate { get; set; }
    }
}
