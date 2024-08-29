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
    public class ShowRepository
    {
        public ObservableCollection<Show> Shows { get; set; }

        public ShowRepository()
        {
            Shows = new ObservableCollection<Show>();
        }

        public void AddShow(Show show)
        {
            Shows.Add(show);
        }

        public void RemoveShow(Show show)
        {
            Shows.Remove(show);
        }

        public void UpdateShow(Show show)
        {
            //Needs implementation
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var show in Shows)
                {
                    writer.WriteLine(show.ToString());
                }
            }
        }

        // Load bookings from a file
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file could not be found.", filePath);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var show = Show.Parse(line);
                    Shows.Add(show);
                }
            }
        }
    }
}