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
    public class EditSerialViewModel:ViewModelBase
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public EditSerialViewModel()
        {

        }

        #region Fields and Properties
        private string _name;
        private int _count = 0;
        private List<Actor> _actors;
        private Actor _selectedActror;

        public string Name
        {
            get
            {
                if (_name == null)
                {
                    if (MainAdminViewModel.MainAdminContext != null)
                    {
                        if (MainAdminViewModel.MainAdminContext.GetSerial != null)
                            _name = MainAdminViewModel.MainAdminContext.GetSerial.Name;
                    }
                }
                return _name;
            }
            set => _name = value;
        }
        public int Count
        {
            get
            {
                if (_count == 0)
                {
                    if (MainAdminViewModel.MainAdminContext != null)
                    {
                        if (MainAdminViewModel.MainAdminContext.GetSerial != null)
                            _count = MainAdminViewModel.MainAdminContext.GetSerial.CountOfSeason;
                    }
                }
                return _count;
            }
            set => _count = value;
        }
        public List<Actor> Actors
        {
            get
            {
                if (MainAdminViewModel.MainAdminContext != null)
                {
                    if (MainAdminViewModel.MainAdminContext.GetSerial != null)
                        _actors = unitOfWork.Actors.GetActorSerial(MainAdminViewModel.MainAdminContext.GetSerial.Id);
                }
                return _actors;
            }
            set => _actors = value;
        }
        public Actor SelectedActror { get => _selectedActror; set => _selectedActror = value; }


        #endregion


        #region Commands
        private Command _deleteCommand;
        private Command _saveCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new Command(Delete);
                return _deleteCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new Command(Save);
                return _saveCommand;
            }
        }

        public void Delete()
        {
            if (_selectedActror != null)
            {
                if (MainAdminViewModel.MainAdminContext != null)
                {
                    if (MainAdminViewModel.MainAdminContext.GetSerial != null)
                    {
                        unitOfWork.Actors.Delete(_selectedActror.Id);
                        MessageBox.Show("The actor was removed");
                        Actors = unitOfWork.Actors.GetActorSerial(MainAdminViewModel.MainAdminContext.GetSerial.Id);
                        NotifyPropertyChanged("Actors");
                    }
                }
            }
            else MessageBox.Show("Select actor");
        }

        public void Save()
        {
            if (MainAdminViewModel.MainAdminContext != null)
            {
                if (MainAdminViewModel.MainAdminContext.GetSerial != null)
                {
                    unitOfWork.Serials.Update(new Serial(MainAdminViewModel.MainAdminContext.GetSerial.Id, Name, Count));
                    MessageBox.Show("The serial was saved");
                }
            }
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
