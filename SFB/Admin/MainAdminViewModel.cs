using SFB.Commands;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SFB.Admin
{
    public class MainAdminViewModel:ViewModelBase
    {
        public Film Film;
        public Film GetFilm
        {
            get
            {
                return Film;
            }
        }

        public Serial Serial;
        public Serial GetSerial
        {
            get
            {
                return Serial;
            }
        }

        public Book Book;
        public Book GetBook
        {
            get
            {
                return Book;
            }
        }
        public static object[] userCon = new object[11];
        public MainAdminViewModel()
        {
            userCon[0] = this;
            userCon[1] = (new HomeAdminPageView()).DataContext;
            userCon[2] = (new SerialAdminPageView()).DataContext;
            userCon[3] = (new FilmAdminPageView()).DataContext;
            userCon[4] = (new BookAdminPageView()).DataContext;
            userCon[5] = (new FilmsAdminPageView()).DataContext;
            userCon[6] = (new EditFilmView()).DataContext;
            userCon[7] = (new SerialsAdminView()).DataContext;
            userCon[8] = (new EditSerialView()).DataContext;
            userCon[9] = (new BooksAdminView()).DataContext;
            userCon[10] = (new EditBookView()).DataContext;
        }
        #region Commands
        private Command _closeWindowCommand;
        private Command _toLoginCommand;
        private Command _homePageCommand;

        public ICommand CloseWindowCommand
        {
            get
            {
                if (_closeWindowCommand == null)
                    _closeWindowCommand = new Command(CloseWindow);
                return _closeWindowCommand;
            }
        }

        public ICommand ToLoginCommand
        {
            get
            {
                if (_toLoginCommand == null)
                    _toLoginCommand = new Command(ToLogin);
                return _toLoginCommand;
            }
        }

        public ICommand HomePageCommand
        {
            get
            {
                if (_homePageCommand == null)
                    _homePageCommand = new Command(ToHomePage);
                return _homePageCommand;
            }
        }


        public void CloseWindow()
        {
            MainWindowViewModel.WindowContext.ShotDown();
        }

        public void ToLogin()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to change the user?", "Change user",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindowViewModel.WindowContext.WindowState = 0;
            }
        }

        public void ToHomePage()
        {
            _selectedPage = -1;
            WindowState = 1;
            NotifyPropertyChanged("MainUserControl");
            NotifyPropertyChanged("SelectedPage");
        }
        #endregion

        #region WindowState
        private int _windowState = 1;
        public int WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                if (_windowState != value)
                {

                    (new Task(() =>
                    {
                        _windowState = value;
                    })).Start();

                    NotifyPropertyChanged("MainUserControl");

                }
            }
        }

        public UserControl MainUserControl
        {
            get
            {
                switch (_windowState)
                {
                    case 1:
                        return new HomeAdminPageView();
                    case 2:
                        return new SerialAdminPageView();
                    case 3:
                        return new FilmAdminPageView();
                    case 4:
                        return new BookAdminPageView();
                    case 5:
                        return new FilmsAdminPageView();
                    case 6:
                        return new EditFilmView();
                    case 7:
                        return new SerialsAdminView();
                    case 8:
                        return new EditSerialView();
                    case 9:
                        return new BooksAdminView();
                    case 10:
                        return new EditBookView();

                }
                return new MainAdminView();
            }
        }

        public static MainAdminViewModel MainAdminContext
        {
            get => (MainAdminViewModel)userCon[0];
        }

        public static HomeAdminPageViewModel HomeAdminPageContext
        {
            get => (HomeAdminPageViewModel)userCon[1];
        }

        public static SerialAdminPageViewModel SerialAdminPageContext
        {
            get => (SerialAdminPageViewModel)userCon[2];
        }

        public static FilmAdminPageViewModel FilmAdminPageContext
        {
            get => (FilmAdminPageViewModel)userCon[3];
        }

        public static BookAdminPageViewModel BookAdminPageContext
        {
            get => (BookAdminPageViewModel)userCon[4];
        }

        public static FilmsAdminPageViewModel FilmsAdminPageContext
        {
            get => (FilmsAdminPageViewModel)userCon[5];
        }

        public static EditFilmViewModel EditFilmContext
        {
            get => (EditFilmViewModel)userCon[6];
        }

        public static SerialsAdminViewModel SerialsAdminContext
        {
            get => (SerialsAdminViewModel)userCon[7];
        }

        public static EditSerialViewModel EditSerialContext
        {
            get => (EditSerialViewModel)userCon[8];
        }

        public static BooksAdminViewModel BooksAdminContext
        {
            get => (BooksAdminViewModel)userCon[9];
        }

        public static EditBookViewModel EditBookContext
        {
            get => (EditBookViewModel)userCon[10];
        }
        #endregion

        #region Selected Page

        private int _selectedPage = -1;
        public int SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                _selectedPage = value;
                NotifyPropertyChanged("SelectedPage");
                switch (_selectedPage)
                {
                    case 0:
                        _windowState = 7;
                        NotifyPropertyChanged("MainUserControl");
                        break;
                    case 1:
                        _windowState = 5;
                        NotifyPropertyChanged("MainUserControl");
                        break;
                    case 2:
                        _windowState = 9;
                        NotifyPropertyChanged("MainUserControl");
                        break;

                }
            }
        }
        #endregion
    }
}
