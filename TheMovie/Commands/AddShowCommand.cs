using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.Model;
using TheMovies.ViewModel;

namespace TheMovies.Commands
{
    internal class AddShowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                return !string.IsNullOrEmpty(mvm.SelectedCinema) &&
                       !string.IsNullOrEmpty(mvm.SelectedRoom) &&
                       !string.IsNullOrEmpty(mvm.SelectedMovie) &&
                       !string.IsNullOrEmpty(mvm.tbTimeOfShowText);
            }
            return false;
        }

        public void Execute(object? parameter)
        {         
            //Needs to calculate the duration of the show
            
            if (parameter is MainViewModel mvm)
            {
                string movieTitle = mvm.SelectedMovie.Split(',')[0];
                string showDuration;
                mvm.ShowRepo.AddShow(new Show(mvm.SelectedCinema, mvm.SelectedRoom, movieTitle, mvm.tbTimeOfShowText, "2 timer"));
            }
        }
    }
}
