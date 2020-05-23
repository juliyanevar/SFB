using SFB.Admin;
using SFB.BookPage;
using SFB.BooksPage;
using SFB.Chapters;
using SFB.Commands;
using SFB.FilmPage;
using SFB.FilmsPage;
using SFB.HomePage;
using SFB.Models;
using SFB.SerialPage;
using SFB.SerialsPage;
using SFB.SeriesPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SFB.Main
{
    public class MainViewModel : ViewModelBase
    {
        public Film Film = new Film();
        public Film GetFilm
        {
            get
            {
                return Film;
            }
        }

        public Book Book = new Book();
        public Book GetBook
        {
            get
            {
                return Book;
            }
        }

        public Serial Serial = new Serial();
        public Serial GetSerial
        {
            get
            {
                return Serial;
            }
        }
        public int Page = 0; //1-FilmsPage,2-HomePage,3-BooksPage,4-BookPage,5-SerialsPage,6-SerialPage
        public int GetPage
        {
            get
            {
                return Page;
            }
        }
        public static object[] userCon = new object[10];
        public MainViewModel()
        {
            userCon[0] = this;
            userCon[1] = (new HomePageView()).DataContext;
            userCon[2] = (new FilmPageView()).DataContext;
            userCon[3] = (new FilmsPageView()).DataContext;
            userCon[4] = (new SerialsPageView()).DataContext;
            userCon[5] = (new BooksPageView()).DataContext;
            userCon[6] = (new BookPageView()).DataContext;
            userCon[7] = (new ChaptersView()).DataContext;
            userCon[8] = (new SerialPageView()).DataContext;
            userCon[9] = (new SeriesView()).DataContext;
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
                if(_homePageCommand==null)
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
        private int _windowState =1;
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
                        return new HomePageView();
                    case 2:
                        return new FilmPageView();
                    case 3:
                        return new FilmsPageView();
                    case 4:
                        return new SerialsPageView();
                    case 5:
                        return new BooksPageView();
                    case 6:
                        return new BookPageView();
                    case 7:
                        return new ChaptersView();
                    case 8:
                        return new SerialPageView();
                    case 9:
                        return new SeriesView();

                }
                return new MainView();
            }
        }

        public static MainViewModel MainContext
        {
            get => (MainViewModel)userCon[0];
        }

        public static HomePageViewModel HomePageContext
        {
            get => (HomePageViewModel)userCon[1];
        }

        public static FilmPageViewModel FilmPageContext
        {
            get => (FilmPageViewModel)userCon[2];
        }

        public static FilmsPageViewModel FilmsPageContext
        {
            get => (FilmsPageViewModel)userCon[3];
        }

        //public static SerialsPageViewModel SerialsPageContext
        //{
        //    get => (SerialsPageViewModel)userCon[4];
        //}

        //public static BooksPageViewModel BooksPageContext
        //{
        //    get => (BooksPageViewModel)userCon[5];
        //}

        public static BookPageViewModel BookPageContext
        {
            get => (BookPageViewModel)userCon[6];
        }

        public static ChaptersViewModel ChaptersContext
        {
            get => (ChaptersViewModel)userCon[7];
        }

        public static SerialPageViewModel SerialPageContext
        {
            get => (SerialPageViewModel)userCon[8];
        }

        public static SeriesViewModel SeriesContext
        {
            get => (SeriesViewModel)userCon[9];
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
                    case 0:_windowState = 4;
                        NotifyPropertyChanged("MainUserControl");
                        break;
                    case 1: _windowState = 3;
                        NotifyPropertyChanged("MainUserControl");
                        break;
                    case 2: _windowState = 5;
                        NotifyPropertyChanged("MainUserControl");
                        break;

                }
            }
        }
        #endregion

        public string test()
        {
            if (MainWindowViewModel.WindowContext != null)
            {
                MainWindowViewModel.WindowContext.CenterWindowOnScreen();
            }
            return "";
        }
    }
}
