using SFB.Commands;
using SFB.DataBase;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.Registration
{
    public class RegistrationViewModel:ViewModelBase
    {
        
        public RegistrationViewModel() 
        {

        }


        #region Commands
        private Command _registrationCommand;
        private Command _cancelCommand;
        private Command _closeWindowCommand;

        public ICommand RegistrationCommand
        {
            get
            {
                if (_registrationCommand == null)
                    _registrationCommand = new Command(Registration);
                return _registrationCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                    _cancelCommand = new Command(Cancel);
                return _cancelCommand;
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                if (_closeWindowCommand == null)
                    _closeWindowCommand = new Command(CloseWindow);
                return _closeWindowCommand;
            }
        }

        public void Registration()
        {
            MessageBox.Show(CheckLogin());
            if(reg)
            {
                MainWindowViewModel.WindowContext.WindowState = 2;
            }
        }

        public void Cancel()
        {
            MainWindowViewModel.WindowContext.WindowState = 0;
        }

        public void CloseWindow()
        {
            MainWindowViewModel.WindowContext.ShotDown();
        }
        #endregion

        #region Fields And Properties
        private UnitOfWork unitOfWork = new UnitOfWork();
        private string _login;
        private string _mail;
        private string _password1;
        private string _password2;

        public string Login
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

        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
            }
        }
        public string Password1
        {
            get
            {
                return _password1;
            }
            set
            {
                _password1 = value;
            }
        }
        public string Password2
        {
            get
            {
                return _password2;
            }
            set
            {
                _password2 = value;
            }
        }

        public ICommand PasswordChangedCommand1
        {
            get
            {
                return new RelayCommand<object>(ExecChangePassword1);
            }
        }
        public ICommand PasswordChangedCommand2
        {
            get
            {
                return new RelayCommand<object>(ExecChangePassword2);
            }
        }

        private void ExecChangePassword1(object obj)
        {
            Password1 = ((System.Windows.Controls.PasswordBox)obj).Password;
        }
        private void ExecChangePassword2(object obj)
        {
            Password2 = ((System.Windows.Controls.PasswordBox)obj).Password;
        }
        #endregion

        #region Registration

        private bool reg = false;
        private string CheckLogin()
        {
            if (_login==null)
                return "Enter your username";
            if (unitOfWork.Users.FindTheSameLogin(_login).Login != null)
                return "This username already exists";
            return CheckMail();
        }

        private string CheckMail()
        {
            if (_mail == null)
                return "Enter your mail";
            if (unitOfWork.Users.FindTheSameMail(_mail).Login != null)
                return "You can only register one user per email address";
            return CheckPasswords();
        }

        private string CheckPasswords()
        {
            if (_password1 != null)
            {
                if (_password2 != null)
                {
                    if (_password1.Length >= 6)
                    {
                        if (_password1 == _password2)
                        {
                            unitOfWork.Users.Create(new User(_login, _password1, _mail));
                            reg = true;
                            return "The user is registered";
                        }
                        else return "Passwords didn't match";
                    }
                    else return "The password is too short(min 6 symbols)";
                }
                else return "Repeat the password";
            }
            else return "Enter password";
        }

        #endregion
    }
}
