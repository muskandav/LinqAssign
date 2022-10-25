using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    internal class TennisPlayer
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public TennisPlayer(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public static List<TennisPlayer> GetTennisPlayer()
        {
            return new List<TennisPlayer>()
            {
                new TennisPlayer("Bruce", "Asgard"),
                new TennisPlayer("Thor", "Asgard"),
                new TennisPlayer("Tony", "US"),
                new TennisPlayer("Steve", "India"),
                new TennisPlayer("Natasha", "US"),
                new TennisPlayer("Clint", "India"),
                new TennisPlayer("Makima", "Japan"),
                new TennisPlayer("Denji", "China"),
                new TennisPlayer("Izuku", "Japan"),
                new TennisPlayer("Naruto", "India"),
                new TennisPlayer("Kakashi", "US"),
                new TennisPlayer("Minato", "India"),
                new TennisPlayer("Azuma", "Japan"),
                new TennisPlayer("Shikamaru", "Russia")
            };
        }


    }
}
