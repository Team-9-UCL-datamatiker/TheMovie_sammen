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
    public class CinemaRepository
    {
        public ObservableCollection<Cinema> Cinemas { get; set; }

        public CinemaRepository()
        {
            Cinemas = new ObservableCollection<Cinema>();
            Cinemas.Add(new Cinema("Hjerm"));
            Cinemas.Add(new Cinema("Videbæk"));
            Cinemas.Add(new Cinema("Thorsminde"));
            Cinemas.Add(new Cinema("Ræhr"));
        }

    }
}