using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models
{
    class AnimalFacts
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Animal
        {
            public string fact { get; set; }
            public string image { get; set; }
        }
    }
}
