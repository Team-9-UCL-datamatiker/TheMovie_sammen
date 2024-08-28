using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.ViewModel;

namespace TheMovies.Commands
{
    internal class RemoveBookingCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = true;

            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedBooking == null)
                    result = false;
            }

            CommandManager.InvalidateRequerySuggested();

            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.BookingRepo.RemoveBooking(mvm.SelectedBooking);
            }
        }
    }
}
