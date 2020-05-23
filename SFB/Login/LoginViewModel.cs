using SFB.Commands;
using SFB.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SFB.Login
{
    public class LoginViewModel:ViewModelBase
    {
        
        public LoginViewModel()
        {

        }

        #region Fields And Properties
        private bool enter = false;
        private UnitOfWork unitOfWork = new UnitOfWork();

        private string _login;
        public string login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public ICommand PasswordChangedCommand
        {
            get
            {
                return new RelayCommand<object>(ExecChangePassword);
            }
        }

        private void ExecChangePassword(object obj)
        {
            Password = ((System.Windows.Controls.PasswordBox)obj).Password;
        }

        #endregion

        #region Commands
        private RelayCommand<UserControl> _loginCommand { get; set; }
        private RelayCommand<UserControl> _registrationCommand { get; set; }
        private RelayCommand<UserControl> CloseWindowCommand { get; set; }
        private RelayCommand<UserControl> _forgetPasswordCommand { get; set; }

        public RelayCommand<UserControl> LoginCommand 
        { 
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand<UserControl>(Login);
                return _loginCommand;
            }
        }

        public RelayCommand<UserControl> RegistrationCommand
        {
            get
            {
                if (_registrationCommand == null)
                    _registrationCommand = new RelayCommand<UserControl>(Registration);
                return _registrationCommand;
            }
        }


        public RelayCommand<UserControl> CloseWindow
        {
            get
            {
                if (this.CloseWindowCommand == null)
                {
                    CloseWindowCommand = new RelayCommand<UserControl>(OnCloseWindow);
                }
                return CloseWindowCommand;
            }
        }

        public RelayCommand<UserControl> ForgetPasswordCommand
        {
            get
            {
                if (_forgetPasswordCommand == null)
                    _forgetPasswordCommand = new RelayCommand<UserControl>(ForgetPassword);
                return _forgetPasswordCommand;
            }
        }


        public void Login(UserControl user)
        {
            MessageBox.Show(CheckLogin());
            if (enter)
            {
                MainWindowViewModel.WindowContext.User = unitOfWork.Users.FindUser(_login, PasswordCoder.PasswordCoder.GetHash(_password));
                DependencyObject ucParent = user.Parent;

                while (!(ucParent is Window))
                {
                    ucParent = LogicalTreeHelper.GetParent(ucParent);
                }
                if (MainWindowViewModel.WindowContext.mainWindow == null)
                {
                    MainWindowViewModel.WindowContext.mainWindow = (MainWindow)ucParent;
                }
                if (_login == "admin")
                    MainWindowViewModel.WindowContext.WindowState = 3;
                else MainWindowViewModel.WindowContext.WindowState = 2;
                _login = null;
            }
            else
            {
                _login = null;
                _password = null;
                NotifyPropertyChanged("Login");
                NotifyPropertyChanged("Password");
            }
        }

        public void Registration(UserControl user)
        {
            DependencyObject ucParent = user.Parent;

            while (!(ucParent is Window))
            {
                ucParent = LogicalTreeHelper.GetParent(ucParent);
            }
            if (MainWindowViewModel.WindowContext.mainWindow == null)
            {
                MainWindowViewModel.WindowContext.mainWindow = (MainWindow)ucParent;
            }
            _login = null;
            MainWindowViewModel.WindowContext.WindowState = 1;
        }

        public void ForgetPassword(UserControl user)
        {
            DependencyObject ucParent = user.Parent;

            while (!(ucParent is Window))
            {
                ucParent = LogicalTreeHelper.GetParent(ucParent);
            }
            if (MainWindowViewModel.WindowContext.mainWindow == null)
            {
                MainWindowViewModel.WindowContext.mainWindow = (MainWindow)ucParent;
            }
            _login = null;
            MainWindowViewModel.WindowContext.WindowState = 4;
        }

        public void OnCloseWindow(UserControl user)
        {
            DependencyObject ucParent = user.Parent;

            while (!(ucParent is Window))
            {
                ucParent = LogicalTreeHelper.GetParent(ucParent);
            }
            //if (MainWindowViewModel.WindowContext.mainWindow == null)  
            //{
            //    MainWindowViewModel.WindowContext.mainWindow = (MainWindow)ucParent;
            //}
            //MainWindowViewModel.WindowContext.ShotDown();

            ((Window)ucParent).Close();
        }

        #endregion

        #region LogIn
        public string CheckLogin()
        {
            enter = false;
            if (_login != null)
            {
                if (_password != null)
                {
                    if (unitOfWork.Users.FindUser(_login, PasswordCoder.PasswordCoder.GetHash( _password)).Login != null)
                    {
                        enter = true;
                        return "The user is logged in";
                    }
                    else return "The user is not found";
                }
                else return "Enter your password";
            }
            else return "Enter your username";
        }
        #endregion
    }
}
