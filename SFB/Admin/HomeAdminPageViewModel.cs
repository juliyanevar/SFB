using SFB.Commands;
using SFB.DataBase;
using SFB.Models;
using SFB.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.Admin
{
    public class HomeAdminPageViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public HomeAdminPageViewModel()
        {

        }

        #region Fields and Properties
        private List<Request> _requests;
        public List<Request> Requests
        {
            get
            {
                //if (_requests == null)
                    _requests = (List<Request>)unitOfWork.Requests.GetAll();
                return _requests;
            }
        }

        private Request _selectedRequest;
        public Request SelectedRequest
        {
            get
            {
                return _selectedRequest;
            }
            set
            {
                if (value != null)
                    _selectedRequest = value;
            }
        }
        #endregion

        #region Commands
        private Command _sendPasswordCommand;
        public ICommand SendPsswordCommand
        {
            get
            {
                if (_sendPasswordCommand == null)
                    _sendPasswordCommand = new Command(SendPassword);
                return _sendPasswordCommand;
            }
        }

        public void SendPassword()
        {
            if (_selectedRequest != null)
            {
                SendEmail();
                if (!_selectedRequest.Status)
                {
                    _selectedRequest.Status = true;
                    unitOfWork.Requests.Update(_selectedRequest);
                    NotifyPropertyChanged("Requests");
                    NotifyPropertyChanged("SelectedRequest");
                    MessageBox.Show("Password sent");
                }
            }

            
        }

        private void SendEmail()
        {
            string genRandPassword = RandomGenerator.GetRandomString(6);
            List<User> users = (List<User>)unitOfWork.Users.GetAll();
            User user = new User();
            foreach(var item in users)
            {
                if(item.Login==_selectedRequest.Login && item.Mail==_selectedRequest.Mail)
                {
                    user = item;
                }
            }
            user.Password = PasswordCoder.PasswordCoder.GetHash(genRandPassword);
            MailsService.SendEmailAsync(user.Mail, "New password", "SFB",
                "Your new password for " + user.Login + " is :" + genRandPassword);
            unitOfWork.Users.Update(user);
            Thread.Sleep(2000);
        }


        #endregion
    }
}
