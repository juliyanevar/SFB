using SFB.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SFB.Admin
{
    public class MainAdminViewModel:ViewModelBase
    {
        public static object[] userCon = new object[5];
        public MainAdminViewModel()
        {
            userCon[0] = this;
            userCon[1] = (new HomeAdminPageView()).DataContext;
            userCon[2] = (new SerialAdminPageView()).DataContext;
            userCon[3] = (new FilmAdminPageView()).DataContext;
            userCon[4] = (new BookAdminPageView()).DataContext;
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
            MainWindowViewModel.WindowContext.WindowState = 0;
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

                }
                return new MainAdminView();
            }
        }

        public static MainAdminView MainAdminContext
        {
            get => (MainAdminView)userCon[0];
        }

        public static HomeAdminPageView HomeAdminPageContext
        {
            get => (HomeAdminPageView)userCon[1];
        }

        public static SerialAdminPageView SerialAdminPageContext
        {
            get => (SerialAdminPageView)userCon[2];
        }

        public static FilmAdminPageView FilmAdminPageContext
        {
            get => (FilmAdminPageView)userCon[3];
        }

        public static BookAdminPageView BookAdminPageContext
        {
            get => (BookAdminPageView)userCon[4];
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
                        _windowState = 2;
                        NotifyPropertyChanged("MainUserControl");
                        break;
                    case 1:
                        _windowState = 3;
                        NotifyPropertyChanged("MainUserControl");
                        break;
                    case 2:
                        _windowState = 4;
                        NotifyPropertyChanged("MainUserControl");
                        break;

                }
            }
        }
        #endregion


        public void Test()
        {
            if (MainWindowViewModel.WindowContext != null)
            {
                MainWindowViewModel.WindowContext.CenterWindowOnScreen();
            }
        }
    }
}
