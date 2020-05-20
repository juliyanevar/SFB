using SFB.Commands;
using SFB.DataBase;
using SFB.Main;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.SerialsPage
{
    class SerialsPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public SerialsPageViewModel()
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
        private Command _moreInf;

        public ICommand MoreInf
        {
            get
            {
                if (_moreInf == null)
                    _moreInf = new Command(AboutSerial);
                return _moreInf;
            }
        }

        public void AboutSerial()
        {
            if (_selectedSerial != null)
            {
                MainViewModel.MainContext.Serial = _selectedSerial;
                MainViewModel.MainContext.SelectedPage = -1;
                MainViewModel.MainContext.Page = 5;
                MainViewModel.MainContext.WindowState = 8;
                _selectedSerial = null;
                NotifyPropertyChanged("SelectedSerial");
            }
            else MessageBox.Show("Select Serial");
        }
        #endregion
    }
}
