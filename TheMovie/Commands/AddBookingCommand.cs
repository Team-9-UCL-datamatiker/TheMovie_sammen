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
    internal class AddBookingCommand : ICommand
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
                return mvm.SelectedShow != null &&
                       mvm.tbReservedSeats != 0 &&
                       mvm.tbPhone > 10000000 &&
                       mvm.tbPhone < 99999999 &&
                       !string.IsNullOrEmpty(mvm.tbEmail);
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            //Needs to calculate the duration of the show

            if (parameter is MainViewModel mvm)
            {
                Customer newCustomer = new Customer(mvm.tbPhone.ToString(), mvm.tbEmail);
                Booking newBooking = new Booking(mvm.tbReservedSeats, mvm.SelectedShow, newCustomer);
                mvm.BookingRepo.AddBooking(newBooking);
            }
        }
    }
}
