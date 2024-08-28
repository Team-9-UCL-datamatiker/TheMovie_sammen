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
                return !string.IsNullOrEmpty(mvm.tbTitleText) &&
                       !string.IsNullOrEmpty(mvm.tbDurationText) &&
                       !string.IsNullOrEmpty(mvm.tbGenreText) &&
                       !string.IsNullOrEmpty(mvm.tbDirectorText) &&
                       !string.IsNullOrEmpty(mvm.tbPremierDateText);
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                try 
                {
                    mvm.MovieRepo.AddMovie(new Movie(mvm.tbTitleText,mvm.tbDurationText,mvm.tbGenreText, mvm.tbDirectorText, mvm.tbPremierDateText));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
