using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    internal class Room
    {
        public string Number { get; set; }
        public int Seats { get; set; }

        public Room(string number)
        {
            Number = number;
        }

        public Room(string number, int seats)
        {
            Number = number;
            Seats = seats;
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }
}
