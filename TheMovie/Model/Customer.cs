using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheMovies.Model
{
    public class Customer
    {
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }

        public Customer(string phoneNumber, string mail)
        {
            PhoneNumber = phoneNumber;
            Mail = mail;
        }
    }
}