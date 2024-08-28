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

        public void AddShowsFromList(string filename)
        {
            string line;

            using (StreamReader sr = new StreamReader(filename))
            {
                string headerLine = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    AddShow(new Show(words[0], "1", words[3], words[2], words[5]));
                }
            }
        }
    }
}