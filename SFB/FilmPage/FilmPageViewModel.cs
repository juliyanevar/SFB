using SFB.Commands;
using SFB.DataBase;
using SFB.Main;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SFB.FilmPage
{
    public class FilmPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public FilmPageViewModel()
        {

        }

        #region Fields and Properties

        private string _nameFilm;
        public string NameFilm
        {
            get
            {
                _nameFilm = MainViewModel.MainContext.GetFilm.Name;
                return _nameFilm;
            }
        }

        private int _yearFilm;
        public int YearFilm
        {
            get
            {
                _yearFilm = MainViewModel.MainContext.GetFilm.Year;
                return _yearFilm;
            }
        }


        private string _actorFilm;
        public string ActorFilm
        {
            get
            {
                _actorFilm = null;
                foreach (var actor in unitOfWork.Actors.GetActorFilm(MainViewModel.MainContext.GetFilm.Id))
                    _actorFilm += actor.Name + "\n";
                return _actorFilm;
            }
        }

        private int _selectedStatus = -1;
        public int SelectedStatus
        {
            get
            {
                if (_selectedStatus == -1)
                    if (MainWindowViewModel.WindowContext != null)
                    {
                        if (unitOfWork.Films.GetStatusFilm(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetFilm.Id) == "Watching")
                            _selectedStatus = 0;
                        else if (unitOfWork.Films.GetStatusFilm(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetFilm.Id) == "Going to watch")
                            _selectedStatus = 1;
                        else if (unitOfWork.Films.GetStatusFilm(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetFilm.Id) == "Not watching")
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
                            unitOfWork.Films.UpdateStatusFilm(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetFilm.Id, "Watching");
                            break;
                        case 1:
                            unitOfWork.Films.UpdateStatusFilm(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetFilm.Id, "Going to watch");
                            break;
                        case 2:
                            unitOfWork.Films.UpdateStatusFilm(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetFilm.Id, "Not watching");
                            break;
                    }
                }
            }
        }


        #endregion


        #region Commands
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
            if (MainViewModel.MainContext.Page == 1)
            {
                _selectedStatus = -1;
                MainViewModel.MainContext.WindowState = 3;
            }
            else if (MainViewModel.MainContext.Page == 2)
            {
                _selectedStatus = -1;
                MainViewModel.MainContext.WindowState = 1;
            }
        }
        #endregion
    }
}
