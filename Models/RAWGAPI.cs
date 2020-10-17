using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brobot.Models
{
    class RAWGAPI
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class RAWG
        {
            //public int id { get; set; }
            //public string slug { get; set; }
            public string name { get; set; }
            //public string name_original { get; set; }
            public string description { get; set; }
            //public int metacritic { get; set; }
            public string released { get; set; }
            //public bool tba { get; set; }
            public DateTime updated { get; set; }
            public string background_image { get; set; }
            //public string background_image_additional { get; set; }
            public string website { get; set; }
            //public int rating { get; set; }
            public int rating_top { get; set; }
            //public int playtime { get; set; }
            //public int screenshots_count { get; set; }
            //public int movies_count { get; set; }
            //public int creators_count { get; set; }
            //public int achievements_count { get; set; }
            //public string parent_achievements_count { get; set; }
            public string reddit_url { get; set; }
            //public string reddit_name { get; set; }
            //public string reddit_description { get; set; }
            //public string reddit_logo { get; set; }
            //public int reddit_count { get; set; }
            //public string twitch_count { get; set; }
            //public string youtube_count { get; set; }
            //public string reviews_text_count { get; set; }
            //public int ratings_count { get; set; }
            //public int suggestions_count { get; set; }
            //public string metacritic_url { get; set; }
            //public int parents_count { get; set; }
            //public int additions_count { get; set; }
            //public int game_series_count { get; set; }
        }


    }
}
       