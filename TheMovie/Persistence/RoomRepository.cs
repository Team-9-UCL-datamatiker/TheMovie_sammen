using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovies.Model;

namespace TheMovies.Persistence
{
    internal class RoomRepository
    {
        public ObservableCollection<Room> Rooms { get; set; }

        public RoomRepository()
        {
            Rooms = new ObservableCollection<Room>();
            Rooms.Add(new Room("1"));
            Rooms.Add(new Room("2"));
            Rooms.Add(new Room("3"));
        }
    }
}
