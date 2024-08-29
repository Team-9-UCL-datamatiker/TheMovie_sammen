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
        public Show BookedShow { get; set; }
        public Customer Customer { get; set; }
        public string ReservedSeats { get; set; }

        public Booking(string resevedSeats)
        {
            ReservedSeats = resevedSeats;
        }

        public Booking(string resevedSeats, Show bookedShow, Customer customer)
        {
            ReservedSeats = resevedSeats;
            BookedShow = bookedShow;
            Customer = customer;
        }

        public override string ToString()
        {
            return $"{ReservedSeats},{BookedShow},{Customer}";
        }

        public static Booking Parse(string data)
        {
            var parts = data.Split(',');

            string reservedSeats = parts[0].Trim();

            string showData = string.Join(",", parts.Skip(1).Take(5)).Trim();
            var show = Show.Parse(showData);
            string customerData = string.Join(",", parts.Skip(6)).Trim();
            var customer = Customer.Parse(customerData);

            return new Booking(reservedSeats, show, customer);
        }
    }
}