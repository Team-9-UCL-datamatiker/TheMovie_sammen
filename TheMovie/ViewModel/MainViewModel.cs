﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TheMovies.Commands;
using TheMovies.Model;
using TheMovies.Persistence;

namespace TheMovies.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _tbTitleText;
        private string _tbDurationText;
        private string _tbGenreText;
        private int _lsSelectedIndex;

        public string projectDirectory;
        public string BookingPath;
        public string MoviePath;
        public string ShowPath;

        public string tbTitleText
        {
            get => _tbTitleText;
            set
            {
                _tbTitleText = value;
                OnPropertyChanged(nameof(tbTitleText));
            }
        }

        public string tbDurationText
        {
            get => _tbDurationText;
            set
            {
                _tbDurationText = value;
                OnPropertyChanged(nameof(tbDurationText));
            }
        }

        public string tbGenreText
        {
            get => _tbGenreText;
            set
            {
                _tbGenreText = value;
                OnPropertyChanged(nameof(tbGenreText));
            }
        }

        public int lsSelectedIndex
        {
            get => _lsSelectedIndex;
            set
            {
                _lsSelectedIndex = value;
                OnPropertyChanged(nameof(lsSelectedIndex));
            }
        }

        public string tbDirectorText { get; set; }
        public string tbPremierDateText { get; set; }
        public string SelectedCinema { get; set; }
        public string SelectedMovie { get; set; }
        public string SelectedRoom { get; set; }
        public string tbTimeOfShowText { get; set; }
        public Show SelectedShow { get; set; }
        public int tbReservedSeats { get; set; }
        public int tbPhone { get; set; }
        public string tbEmail { get; set; }
        public Booking SelectedBooking { get; set; }


        //ObservableCollections
        public ObservableCollection<Movie> Movies { get; set; }

        public ObservableCollection<Cinema> Cinemas { get; set; }

        public ObservableCollection<Show> Shows { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        public ObservableCollection<Booking> Bookings { get; set; }

        //ICommands
        public ICommand AddCmd { get; set; }
        public ICommand RemoveCmd { get; set; }
        public ICommand AddShowCmd { get; set; }
        public ICommand RemoveShowCmd { get; set; }
        public ICommand AddBookingCmd { get; set; }
        public ICommand RemoveBookingCmd { get; set; }
        public ICommand SaveMoviesCmd { get; set; }
        public ICommand SaveBookingsCmd { get; set; }
        public ICommand SaveShowsCmd { get; set; }
               

        //Constructor
        public MainViewModel()
        {
            MovieRepo = new MovieRepository();
            CinemaRepo = new CinemaRepository();
            ShowRepo = new ShowRepository();
            RoomRepo = new RoomRepository();
            BookingRepo = new BookingRepository();
            Movies = MovieRepo.Movies;
            Cinemas = CinemaRepo.Cinemas;
            Bookings = BookingRepo.Bookings;
            Shows = ShowRepo.Shows;
            Rooms = RoomRepo.Rooms;
            AddCmd = new AddCommand();
            RemoveCmd = new RemoveCommand();
            AddShowCmd = new AddShowCommand();
            RemoveShowCmd = new RemoveShowCommand();
            AddBookingCmd = new AddBookingCommand();
            RemoveBookingCmd = new RemoveBookingCommand();
            projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            BookingPath = Path.Combine(projectDirectory, "Database/BookingDatabase.csv");
            MoviePath = Path.Combine(projectDirectory, "Database/MovieDatabase.csv");
            ShowPath = Path.Combine(projectDirectory, "Database/ShowDatabase.csv");
            MovieRepo.LoadFromFile(MoviePath);
            ShowRepo.LoadFromFile(ShowPath);
            BookingRepo.LoadFromFile(BookingPath);
            SaveShowsCmd = new RelayCommand(SaveShows);
            SaveBookingsCmd = new RelayCommand(SaveBookings);
            SaveMoviesCmd = new RelayCommand(SaveMovies);


        }

        public MovieRepository MovieRepo;
        public ShowRepository ShowRepo;
        public CinemaRepository CinemaRepo;
        public RoomRepository RoomRepo;
        public BookingRepository BookingRepo;

        public event PropertyChangedEventHandler? PropertyChanged;


        

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveMovies()
        {
            MovieRepo.SaveToFile(MoviePath);
        }
        private void SaveBookings()
        {
            BookingRepo.SaveToFile(BookingPath);
        }
        private void SaveShows()
        {
            ShowRepo.SaveToFile(ShowPath);
        }
        
    }
}
