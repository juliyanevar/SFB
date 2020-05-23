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

namespace SFB.Admin
{
    public class SerialAdminPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public SerialAdminPageViewModel()
        {

        }

        #region Fields and Properties
        private string _nameSerial;
        public string NameSerial { get => _nameSerial; set => _nameSerial = value; }

        private string _count;
        public string Count { get => _count; set => _count = value; }

        private string _nameOfSerial;
        public string NameOfSerial { get => _nameOfSerial; set => _nameOfSerial = value; }

        private string _nameOfActor;
        public string NameOfActor { get => _nameOfActor; set => _nameOfActor = value; }

        #endregion


        #region Commands
        private Command _addSerialCommand;
        public ICommand AddSerialCommand
        {
            get
            {
                if (_addSerialCommand == null)
                    _addSerialCommand = new Command(AddSerial);
                return _addSerialCommand;
            }
        }

        public void AddSerial()
        {
            if (_nameSerial != null && _count != null && int.Parse(_count) > 0)
            {
                unitOfWork.Serials.Create(new Serial(_nameSerial, int.Parse(_count)));
                _nameSerial = null;
                _count = null;
                NotifyPropertyChanged("NameSerial");
                NotifyPropertyChanged("Count");
                MessageBox.Show("The film was added");
            }
            else MessageBox.Show("Incorrect data");
        }

        private Command _addActorCommand;
        public ICommand AddActorCommand
        {
            get
            {
                if (_addActorCommand == null)
                    _addActorCommand = new Command(AddActor);
                return _addActorCommand;
            }
        }

        public void AddActor()
        {
            if (_nameOfActor != null && _nameOfSerial != null)
            {
                unitOfWork.Actors.CreateSerialActor(_nameOfSerial, _nameOfActor);
                _nameOfActor = null;
                NotifyPropertyChanged("NameOfActor");
                MessageBox.Show("The actor was added");
            }
            else MessageBox.Show("Incorrect data");
        }

        private Command _backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new Command(Back);
                return _backCommand;
            }
        }
        public void Back()
        {
            if (MainAdminViewModel.MainAdminContext != null)
                MainAdminViewModel.MainAdminContext.WindowState = 7;
        }
        #endregion
    }
}
