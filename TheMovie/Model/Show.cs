using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheMovies.Model
{
    public class Show
    {
        //Testing two properties
        public string CinemaName { get; set; }
        public string MovieName { get; set; }
        
        public string RoomNumber { get; set; } 
        public string TimeOfShow { get; set; }
        public string ShowLength { get; set; }

        public int AvailableSeats { get; set; } = 40;

        public Show(string cinemaName, string roomNumber, string movieName, string time, string showLength)
        {
            CinemaName = cinemaName;            
            RoomNumber = roomNumber;
            MovieName = movieName;
            TimeOfShow = time;
            ShowLength = showLength;
        }

        public Show(string cinemaName, string roomNumber, string movieName, string time, string showLength, int availableSeats)
        {
            CinemaName = cinemaName;
            RoomNumber = roomNumber;
            MovieName = movieName;
            TimeOfShow = time;
            ShowLength = showLength;
            AvailableSeats = availableSeats;
        }

        public override string ToString()
        {
            return $"{CinemaName}, {RoomNumber}, {MovieName}, {TimeOfShow}, {ShowLength}";
        }

        public static Show Parse(string data)
        {
            var parts = data.Split(',');
            string cinemaName = parts[0].Trim();
            string roomNumber = parts[1].Trim();
            string movieName = parts[2].Trim();
            string timeOfShow = parts[3].Trim();
            string showLength = parts[4].Trim();

            return new Show(cinemaName, roomNumber, movieName, timeOfShow, showLength);
        }
    }    
}