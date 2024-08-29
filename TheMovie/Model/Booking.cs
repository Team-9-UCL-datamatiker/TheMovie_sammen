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
        public Show BookedShow { get; set; } = new Show(" ", " ", " ", " ", " ");
        public Customer Customer { get; set; } = new Customer("", ""); 
        public int ReservedSeats { get; set; }

        public Booking(int resevedSeats)
        {
            ReservedSeats = resevedSeats;
        }

        public Booking(int resevedSeats, Show bookedShow, Customer customer)
        {
            ReservedSeats = resevedSeats;
            BookedShow = bookedShow;
            Customer = customer;
            //BookedShow.AvailableSeats -= ReservedSeats;
        }

        public override string ToString()
        {
            return $"{BookedShow.MovieName}, {ReservedSeats}, {Customer.PhoneNumber}";
        }
    }
}