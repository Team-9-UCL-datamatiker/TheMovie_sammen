﻿using System;
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
        }

        public override string ToString()
        {
            return $"{ReservedSeats},{BookedShow},{Customer}";
        }

        public static Booking Parse(string data)
        {
            var parts = data.Split(',');
            int reservedSeats = int.Parse(parts[0]);
            var show = Show.Parse(parts[1]);
            var customer = Customer.Parse(parts[2]);

            return new Booking(reservedSeats, show, customer);
        }
    }
}