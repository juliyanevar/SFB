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

namespace SFB.Login
{
    public class ForgetPasswordViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ForgetPasswordViewModel()
        {

        }

        #region Commands
        private Command _cancelCommand;
        private Command _closeWindowCommand;
        private Command _sendRequestCommand;


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

        public ICommand SendRequestCommand
        {
            get
            {
                if (_sendRequestCommand == null)
                    _sendRequestCommand = new Command(SendRequest);
                return _sendRequestCommand;
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

        public void SendRequest()
        {
            if(_mail!=null && _login!=null)
            {
                int id = unitOfWork.Users.GetIdUser(_login, _mail);
                if (id != 0)
                {
                    unitOfWork.Requests.Create(new Request(_login, _mail));
                    _login = null;
                    _mail = null;
                    NotifyPropertyChanged("Mail");
                    NotifyPropertyChanged("Login");
                    MessageBox.Show("Your request has been sent\nAdmin will send a new password within 24 hours");
                }
                else MessageBox.Show("This user doesn't exist\nVerify the entered data");
            }
           else  MessageBox.Show("Enter your username and mail");
        }
        #endregion

        #region Fields And Properties
        
        private string _mail;
       

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

        private string _login;
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
       
        #endregion

        
    }
}

