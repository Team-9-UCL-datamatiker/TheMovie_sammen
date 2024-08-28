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

        public Show(string cinemaName, string roomNumber, string movieName, string time, string showLength)
        {
            CinemaName = cinemaName;            
            RoomNumber = roomNumber;
            MovieName = movieName;
            TimeOfShow = time;
            ShowLength = showLength;
        }

        public override string ToString()
        {
            return $"{CinemaName}, {RoomNumber}, {MovieName}, {TimeOfShow}, {ShowLength}";
        }
    }    
}