using SFB.Commands;
using SFB.DataBase;
using SFB.Main;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.HomePage
{
    public class HomePageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public HomePageViewModel()
        {

        }

        #region Fields and Properties

        private User user;
        public User GetUser
        {
            get
            {
                if(MainWindowViewModel.WindowContext != null)
                    if(MainWindowViewModel.WindowContext.WindowState==2)
                        user = MainWindowViewModel.WindowContext.GetUser;
                return user;
            }
        }
        

        private string _userName;
        public string UserName
        {
            get
            {
                if (_userName == null && GetUser!=null)
                    _userName = user.Login;
                return _userName;
            }
        }

        public ObservableCollection<Film> LaterFilmsObs
        {
            get
            {
                return new ObservableCollection<Film>(LaterFilms);
            }
        }
        private List<Film> _laterFilms = new List<Film>();
        public List<Film> LaterFilms
        {
            get
            {
                if(user!=null)
                    _laterFilms = unitOfWork.Films.GetLaterFilms(GetUser.Id);
                return _laterFilms;
            }
            set
            {
                _laterFilms = value;
            }
        }

        public ObservableCollection<Film> WatchingFilmsObs
        {
            get
            {
                return new ObservableCollection<Film>(WatchingFilms);
            }
        }
        private List<Film> _watchingFilms = new List<Film>();
        public List<Film> WatchingFilms
        {
            get
            {
                if (user != null)
                    _watchingFilms = unitOfWork.Films.GetWatchingFilms(GetUser.Id);
                return _watchingFilms;
            }
            set
            {
                _watchingFilms = value;
            }
        }

        public ObservableCollection<Book> ReadingBooksObs
        {
            get
            {
                return new ObservableCollection<Book>(ReadingBooks);
            }
        }
        private List<Book> _readingBooks;
        public List<Book> ReadingBooks
        {
            get
            {
                if (user != null)
                    _readingBooks = unitOfWork.Books.GetReadingBooks(GetUser.Id);
                return _readingBooks;
            }
        }

        public ObservableCollection<Book> LaterBooksObs
        {
            get
            {
                return new ObservableCollection<Book>(LaterBooks);
            }
        }
        private List<Book> _laterBooks;
        public List<Book> LaterBooks
        {
            get
            {
                if (user != null)
                    _laterBooks = unitOfWork.Books.GetLaterBooks(GetUser.Id);
                return _laterBooks;
            }
        }

        public ObservableCollection<Serial> LaterSerialsObs
        {
            get
            {
                return new ObservableCollection<Serial>(LaterSerials);
            }
        }
        private List<Serial> _laterSerials = new List<Serial>();
        public List<Serial> LaterSerials
        {
            get
            {
                if (user != null)
                    _laterSerials = unitOfWork.Serials.GetLaterSerials(GetUser.Id);
                return _laterSerials;
            }
            set
            {
                _laterSerials = value;
            }
        }

        public ObservableCollection<Serial> WatchingSerialsObs
        {
            get
            {
                return new ObservableCollection<Serial>(WatchingSerials);
            }
        }
        private List<Serial> _watchingSerials = new List<Serial>();
        public List<Serial> WatchingSerials
        {
            get
            {
                if (user != null)
                    _watchingSerials = unitOfWork.Serials.GetWatchingSerials(GetUser.Id);
                return _watchingSerials;
            }
            set
            {
                _watchingSerials = value;
            }
        }
        #endregion

        #region Selected
        private Film _selectedWatchingFilm;
        public Film SelectedWatchingFilm
        {
            get
            {
                return _selectedWatchingFilm;
            }
            set
            {
                if (value != null)
                {
                    _selectedWatchingSerial = null;
                    _selectedLaterSerial = null;
                    _selectedLaterBook = null;
                    _selectedReadingBook = null;
                    _selectedLaterFilm = null;
                    _selectedWatchingFilm = value;
                    NotifyPropertyChanged("SelectedLaterFilm");
                    NotifyPropertyChanged("SelectedLaterBook");
                    NotifyPropertyChanged("SelectedReadingBook");
                    NotifyPropertyChanged("SelectedWatchingSerial");
                    NotifyPropertyChanged("SelectedLaterSerial");
                }
            }
        }

        private Film _selectedLaterFilm;
        public Film SelectedLaterFilm
        {
            get
            {
                return _selectedLaterFilm;
            }
            set
            {
                if (value != null)
                {
                    _selectedWatchingSerial = null;
                    _selectedLaterSerial = null;
                    _selectedLaterBook = null;
                    _selectedReadingBook = null;
                    _selectedWatchingFilm = null;
                    _selectedLaterFilm = value;
                    NotifyPropertyChanged("SelectedWatchingFilm");
                    NotifyPropertyChanged("SelectedLaterBook");
                    NotifyPropertyChanged("SelectedReadingBook");
                    NotifyPropertyChanged("SelectedWatchingSerial");
                    NotifyPropertyChanged("SelectedLaterSerial");
                }
            }
        }

        private Book _selectedReadingBook;
        public Book SelectedReadingBook
        {
            get
            {
                return _selectedReadingBook;
            }
            set
            {
                if (value != null)
                {
                    _selectedWatchingSerial = null;
                    _selectedLaterSerial = null;
                    _selectedLaterFilm = null;
                    _selectedLaterBook = null;
                    _selectedWatchingFilm = null;
                    _selectedReadingBook = value;
                    NotifyPropertyChanged("SelectedLaterBook");
                    NotifyPropertyChanged("SelectedWatchingFilm");
                    NotifyPropertyChanged("SelectedLaterFilm");
                    NotifyPropertyChanged("SelectedWatchingSerial");
                    NotifyPropertyChanged("SelectedLaterSerial");
                }
            }
        }

        private Book _selectedLaterBook;
        public Book SelectedLaterBook
        {
            get
            {
                return _selectedLaterBook;
            }
            set
            {
                if (value != null)
                {
                    _selectedWatchingSerial = null;
                    _selectedLaterSerial = null;
                    _selectedReadingBook = null;
                    _selectedLaterFilm = null;
                    _selectedWatchingFilm = null;
                    _selectedLaterBook = value;
                    NotifyPropertyChanged("SelectedReadingBook");
                    NotifyPropertyChanged("SelectedWatchingFilm");
                    NotifyPropertyChanged("SelectedLaterFilm");
                    NotifyPropertyChanged("SelectedWatchingSerial");
                    NotifyPropertyChanged("SelectedLaterSerial");
                }
            }
        }

        private Serial _selectedWatchingSerial;
        public Serial SelectedWatchingSerial
        {
            get
            {
                return _selectedWatchingSerial;
            }
            set
            {
                if (value != null)
                {
                    _selectedLaterSerial = null;
                    _selectedReadingBook = null;
                    _selectedLaterFilm = null;
                    _selectedWatchingFilm = null;
                    _selectedLaterBook = null;
                    _selectedWatchingSerial = value;
                    NotifyPropertyChanged("SelectedReadingBook");
                    NotifyPropertyChanged("SelectedWatchingFilm");
                    NotifyPropertyChanged("SelectedLaterFilm");
                    NotifyPropertyChanged("SelectedLaterBook");
                    NotifyPropertyChanged("SelectedLaterSerial");
                }
            }
        }

        private Serial _selectedLaterSerial;
        public Serial SelectedLaterSerial
        {
            get
            {
                return _selectedLaterSerial;
            }
            set
            {
                if (value != null)
                {
                    _selectedReadingBook = null;
                    _selectedLaterFilm = null;
                    _selectedWatchingFilm = null;
                    _selectedLaterBook = null;
                    _selectedWatchingSerial = null;
                    _selectedLaterSerial = value;
                    NotifyPropertyChanged("SelectedReadingBook");
                    NotifyPropertyChanged("SelectedWatchingFilm");
                    NotifyPropertyChanged("SelectedWatchingSerial");
                    NotifyPropertyChanged("SelectedLaterFilm");
                    NotifyPropertyChanged("SelectedLaterBook");
                }
            }
        }

        #endregion

        #region Commands
        private Command _infoCommand;
        public ICommand InfoCommand
        {
            get
            {
                if (_infoCommand == null)
                    _infoCommand = new Command(Info);
                return _infoCommand;
            }
        }

        public void Info()
        {
            if (_selectedLaterFilm != null || _selectedWatchingFilm != null)
            {
                if (_selectedLaterFilm != null)
                    MainViewModel.MainContext.Film = _selectedLaterFilm;
                else MainViewModel.MainContext.Film = _selectedWatchingFilm;
                MainViewModel.MainContext.Page = 2;
                MainViewModel.MainContext.WindowState = 2;
                _selectedLaterFilm = null;
                _selectedWatchingFilm = null;
                //NotifyPropertyChanged("SelectedWatchingFilm");
                //NotifyPropertyChanged("SelectedLaterFilm");
            }
            else if(_selectedReadingBook!=null || _selectedLaterBook != null)
            {
                if (_selectedLaterBook != null)
                    MainViewModel.MainContext.Book = _selectedLaterBook;
                else MainViewModel.MainContext.Book = _selectedReadingBook;
                MainViewModel.MainContext.Page = 2;
                MainViewModel.MainContext.WindowState = 6;
                _selectedReadingBook = null;
                _selectedLaterBook = null;
                //NotifyPropertyChanged("SelectedLaterBook");
                //NotifyPropertyChanged("SelectedReadingBook");
            }
            else if(_selectedWatchingSerial!=null || _selectedLaterSerial!=null)
            {
                if (_selectedLaterSerial != null)
                    MainViewModel.MainContext.Serial = _selectedLaterSerial;
                else MainViewModel.MainContext.Serial = _selectedWatchingSerial;
                MainViewModel.MainContext.Page = 2;
                MainViewModel.MainContext.WindowState = 8;
                _selectedWatchingSerial = null;
                _selectedLaterSerial = null;
            }
            else
                MessageBox.Show("Select something");
        }
        #endregion



    }
}
