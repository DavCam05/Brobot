using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models
{
    class IMDbSearchResult
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Trailer
        {
            public string id { get; set; }
            public string link { get; set; }
        }

        public class Cast
        {
            public string actor { get; set; }
            public string actor_id { get; set; }
            public string character { get; set; }
        }

        public class IMDb
        {
            public string id { get; set; }
            public string title { get; set; }
            public string year { get; set; }
            public string length { get; set; }
            public string rating { get; set; }
            public string rating_votes { get; set; }
            public string poster { get; set; }
            public string plot { get; set; }
            public Trailer trailer { get; set; }
            public List<Cast> cast { get; set; }
            public List<List<string>> technical_specs { get; set; }
        }

    }
}
