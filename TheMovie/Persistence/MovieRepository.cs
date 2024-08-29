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

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var movie in Movies)
                {
                    writer.WriteLine(movie.ToString());
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
                    var movie = Movie.Parse(line);
                    Movies.Add(movie);
                }
            }
        }
    }
}
