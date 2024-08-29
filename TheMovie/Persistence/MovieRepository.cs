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
    public class MovieRepository
    {
        public ObservableCollection<Movie> Movies { get; set; }

        public MovieRepository()
        {
            Movies = new ObservableCollection<Movie>();
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        public void RemoveMovie(int index)
        {
            Movies.Remove(Movies[index]);
        }

        public void UpdateMovie(Movie movie)
        {
            //implementation
        }

        public void AddMoviesFromList(string filename)
        {
            string line;

            using (StreamReader sr = new StreamReader(filename))
            {
                //Reads and ignores the headerline
                string headerLine = sr.ReadLine();

                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');

                    string title = words[3];

                    //Only if a movie with the given title doesn't exist - add the movie to the collection
                    if (!Movies.Any(x => x.Title == title))
                    {
                        AddMovie(new Movie(words[3], words[5], words[4], words[6], words[7]));
                    }                                       
                }
            }
        }
    }
}
