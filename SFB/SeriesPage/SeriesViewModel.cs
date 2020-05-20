using SFB.Commands;
using SFB.DataBase;
using SFB.Main;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.SeriesPage
{
    public class SeriesViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public SeriesViewModel()
        {

        }


        #region Fields and Properties
        private string _nameSerial;
        public string NameSerial
        {
            get
            {
                _nameSerial = MainViewModel.MainContext.GetSerial.Name;
                return _nameSerial;
            }
        }

        private List<Series> _series;
        public List<Series> Series
        {
            get
            {
                if (MainWindowViewModel.WindowContext != null)
                    _series = unitOfWork.Series.GetSeriesSerial(MainViewModel.MainContext.GetSerial.Id, MainWindowViewModel.WindowContext.GetUser.Id);
                return _series;
            }
            set
            {
                _series = value;
            }
        }
        #endregion

        #region Commands
        private Command _saveCommand;
        private Command _backCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new Command(Save);
                return _saveCommand;
            }
        }
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new Command(Back);
                return _backCommand;
            }
        }

        public void Save()
        {
            foreach (var item in _series)
            {
                unitOfWork.Series.Update(item);
                NotifyPropertyChanged("Series");
            }
            MessageBox.Show("Information was save");
        }
        public void Back()
        {
            MainViewModel.MainContext.WindowState = 8;
        }
        #endregion
    }
}
