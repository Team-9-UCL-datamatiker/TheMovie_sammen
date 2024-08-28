using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TheMovies.Model;
using TheMovies.ViewModel;

namespace TheMovies.Commands
{
    public class RemoveCommand : ICommand

    {
        public RemoveCommand() { }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                // Ensure an item is selected
                return mvm.lsSelectedIndex >= 0;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                if (mvm.lsSelectedIndex >= 0)
                {
                    mvm.MovieRepo.RemoveMovie(mvm.lsSelectedIndex);
                }
            }
        }
    }
}
