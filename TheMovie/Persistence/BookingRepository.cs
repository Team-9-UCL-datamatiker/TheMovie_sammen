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
            Bookings.Add(new Booking(12));
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