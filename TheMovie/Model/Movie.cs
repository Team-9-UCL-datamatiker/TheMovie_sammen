using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Movie(string title, string duration, string genre, string director, string premierDate)
    {
        public string Title { get; set; } = title;
        public string Duration { get; set; } = duration;
        public string Genre { get; set; } = genre;
        public string Director { get; set; } = director;
        public string PremierDate { get; set; } = premierDate;

        public override string ToString()
        {
            return $"{Title}, {Genre}, {Duration}, {Director}, {PremierDate}";
        }
    }
}
