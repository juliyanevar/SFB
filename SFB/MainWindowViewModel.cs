using SFB.Admin;
using SFB.Login;
using SFB.Main;
using SFB.Models;
using SFB.Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SFB
{
    public class MainWindowViewModel : ViewModelBase
    {
        public User User;
        public User GetUser
        {
            get
            {
                return User;
            }
        }
        public MainWindow mainWindow;
        public static object[] userCon = new object[6];
        public MainWindowViewModel()
        {
            userCon[0] = (new LoginView()).DataContext;
            userCon[1] = (new RegistrationView()).DataContext;
            userCon[2] = (new MainView()).DataContext;
            userCon[3] = this;
            userCon[4] = (new MainAdminView()).DataContext;
            userCon[5] = (new ForgetPasswordView()).DataContext;
        }


        #region Contexts
        public static LoginViewModel LoginContext
        {
            get => (LoginViewModel)userCon[0];
        }

        public static RegistrationViewModel RegistrationContext
        {
            get => (RegistrationViewModel)userCon[1];
        }

        public static MainViewModel MainContext
        {
            get => (MainViewModel)userCon[2];
        }

        public static MainWindowViewModel WindowContext
        {
            get => (MainWindowViewModel)userCon[3];
        }

        public static MainAdminView MainAdminContext
        {
            get => (MainAdminView)userCon[4];
        }

        public static ForgetPasswordView ForgetPasswordContext
        {
            get => (ForgetPasswordView)userCon[5];
        }
        #endregion


        public UserControl MainUserControl
        {
            get
            {
                switch (_windowState)
                {
                    case 1:
                        return new RegistrationView();
                    case 2:
                        MainView MV = new MainView();
                        MainWindowViewModel.MainContext.test();
                        return MV;
                    case 3:
                        MainAdminView MAV = new MainAdminView();
                        //MainWindowViewModel.MainAdminContext.Test();
                        return MAV;
                    case 4:
                        return new ForgetPasswordView();

                }
                return new LoginView();
            }
        }



        private int _windowState = 0;
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

        public void ShotDown()
        {
            mainWindow.Close();
        }

        public void CenterWindowOnScreen()
        {
            //double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            //double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            //double windowWidth = mainWindow.Width;
            //double windowHeight = mainWindow.Height;
            mainWindow.Left = 228;
            mainWindow.Top = 132;
            //mainWindow.Left = (screenWidth / 2) - (windowWidth / 2);
            //mainWindow.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
