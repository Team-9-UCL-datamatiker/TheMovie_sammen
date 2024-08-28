using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheMovies.Model
{
    public class Booking
    {
        public int ReservedSeats { get; set; }

        public Booking(int resevedSeats)
        {
            ReservedSeats = resevedSeats;
        }

        public override string ToString()
        {
            return $"{ReservedSeats}";
        }
    }
}