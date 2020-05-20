using SFB.Commands;
using SFB.DataBase;
using SFB.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.SerialPage
{
    public class SerialPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public SerialPageViewModel()
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

        private int _count;
        public int CountOfSeason
        {
            get
            {
                _count = MainViewModel.MainContext.GetSerial.CountOfSeason;
                return _count;
            }
        }

        private string _actorSerial;
        public string ActorSerial
        {
            get
            {
                _actorSerial = null;
                foreach (var actor in unitOfWork.Actors.GetActorSerial(MainViewModel.MainContext.GetSerial.Id))
                    _actorSerial += actor.Name + "\n";
                return _actorSerial;
            }
        }
        #endregion

        #region Selected
        private int _selectedStatus = -1;
        public int SelectedStatus
        {
            get
            {
                if (_selectedStatus == -1)
                    if (MainWindowViewModel.WindowContext != null)
                    {
                        if (unitOfWork.Serials.GetStatusSerial(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetSerial.Id) == "Watching")
                            _selectedStatus = 0;
                        else if (unitOfWork.Serials.GetStatusSerial(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetSerial.Id) == "Going to watch")
                            _selectedStatus = 1;
                        else if (unitOfWork.Serials.GetStatusSerial(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetSerial.Id) == "Not watching")
                            _selectedStatus = 2;
                    }
                return _selectedStatus;
            }
            set
            {
                _selectedStatus = value;
                NotifyPropertyChanged("SelectedStatus");
                if (MainWindowViewModel.WindowContext != null)
                {
                    switch (_selectedStatus)
                    {
                        case 0:
                            unitOfWork.Serials.UpdateStatusSerial(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetSerial.Id, "Watching");
                            break;
                        case 1:
                            unitOfWork.Serials.UpdateStatusSerial(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetSerial.Id, "Going to watch");
                            break;
                        case 2:
                            unitOfWork.Serials.UpdateStatusSerial(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetSerial.Id, "Not watching");
                            break;
                    }
                }
            }
        }
        #endregion

        #region Commands
        private Command _backCommand;
        private Command _seriesCommand;

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new Command(Back);
                return _backCommand;
            }
        }
        public ICommand SeriesCommand
        {
            get
            {
                if (_seriesCommand == null)
                {
                    _seriesCommand = new Command(GetSeries);
                }
                return _seriesCommand;
            }
        }

        public void Back()
        {
            if (MainViewModel.MainContext.Page == 5)
            {
                MainViewModel.MainContext.WindowState = 4;
            }
            else if (MainViewModel.MainContext.Page == 2)
            {
                MainViewModel.MainContext.WindowState = 1;
            }
        }


        public void GetSeries()
        {
            if (_selectedStatus == 0)
            {
                //MainViewModel.MainContext.Page = 6;
                MainViewModel.MainContext.WindowState = 9;
            }
            else MessageBox.Show("Select status 'Watching' to go to the page");
        }


        #endregion
    }
}
