using SFB.Commands;
using SFB.DataBase;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.Admin
{
    public class SerialsAdminViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public SerialsAdminViewModel()
        {

        }

        #region Fields and Properties
        public ObservableCollection<Serial> SerialsObs
        {
            get
            {
                return new ObservableCollection<Serial>(Serials);
            }
        }
        private List<Serial> _serials;
        public List<Serial> Serials
        {
            get
            {
                _serials = (List<Serial>)unitOfWork.Serials.GetAll();
                return _serials;
            }
            set
            {
                _serials = value;
            }
        }
        #endregion

        #region Selected
        private Serial _selectedSerial;
        public Serial SelectedSerial
        {
            get
            {
                return _selectedSerial;
            }
            set
            {
                if (value != null)
                    _selectedSerial = value;
            }
        }


        #endregion

        #region Commands
        private Command _deleteCommand;
        private Command _editCommand;
        private Command _addCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new Command(Delete);
                return _deleteCommand;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                    _editCommand = new Command(Edit);
                return _editCommand;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new Command(Add);
                return _addCommand;
            }
        }

        public void Delete()
        {
            if (_selectedSerial != null)
            {
                unitOfWork.Serials.Delete(_selectedSerial.Id);
                MessageBox.Show("The serial was removed");
                Serials = (List<Serial>)unitOfWork.Serials.GetAll();
                NotifyPropertyChanged("SerialsObs");
            }
            else MessageBox.Show("Select serial");
        }

        public void Edit()
        {
            if (_selectedSerial != null)
            {
                MainAdminViewModel.MainAdminContext.Serial = _selectedSerial;
                MainAdminViewModel.MainAdminContext.WindowState = 8;
                Serials = (List<Serial>)unitOfWork.Serials.GetAll();
                NotifyPropertyChanged("SerialsObs");
            }
            else MessageBox.Show("Select serial");
        }

        public void Add()
        {
            MainAdminViewModel.MainAdminContext.WindowState = 2;
            Serials = (List<Serial>)unitOfWork.Serials.GetAll();
            NotifyPropertyChanged("SerialsObs");
        }
        #endregion
    }
}
