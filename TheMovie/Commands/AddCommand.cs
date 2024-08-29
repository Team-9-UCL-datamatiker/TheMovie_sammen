using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheMovies.Model;
using TheMovies.ViewModel;

namespace TheMovies.Commands
{
    public class AddCommand : ICommand
    {
        public AddCommand() { }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            // Example condition: Add command can only execute if text fields are not null or empty
            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedMovie == null)
                    return false;
                
                return !string.IsNullOrEmpty(mvm.SelectedMovie.Title) &&
                       !string.IsNullOrEmpty(mvm.SelectedMovie.Duration) &&
                       !string.IsNullOrEmpty(mvm.SelectedMovie.Genre) &&
                       !string.IsNullOrEmpty(mvm.SelectedMovie.Director) &&
                       !string.IsNullOrEmpty(mvm.SelectedMovie.PremierDate);
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.MovieRepo.AddMovie(new Movie(mvm.SelectedMovie.Title,mvm.SelectedMovie.Duration, mvm.SelectedMovie.Genre, mvm.SelectedMovie.Director, mvm.SelectedMovie.PremierDate));
            }
        }
    }
}
