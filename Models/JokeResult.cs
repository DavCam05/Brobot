using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models
{
    class JokeResult
    {
        public class Body
        {
            public string _id { get; set; }
            public string type { get; set; }
            public string setup { get; set; }
            public string punchline { get; set; }
        }

        public class Joke
        {
            public bool success { get; set; }
            public List<Body> body { get; set; }
        }

    }
}
