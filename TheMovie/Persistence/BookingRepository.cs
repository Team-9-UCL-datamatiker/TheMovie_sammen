using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.Persistence
{
    public class BookingRepository
    {
        public ObservableCollection<Booking> Bookings { get; set; }

        public BookingRepository()
        {
            Bookings = new ObservableCollection<Booking>();
            //Bookings.Add(new Booking(12));
            Bookings.Add(new Booking(12, new Show("Hjerm", "10", "I, Tonya", "123", "123"), new Customer("24974635", "alborde@yahoo.com")));
        }

        public void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }

        public void RemoveBooking(Booking booking)
        {
            Bookings.Remove(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            //implementation
        }
    }
}