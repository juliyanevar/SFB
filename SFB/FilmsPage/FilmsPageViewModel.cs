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

namespace SFB.FilmsPage
{
    public class FilmsPageViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public FilmsPageViewModel()
        {

        }

        #region Fields and Properties
        private User user;
        public User GetUser
        {
            get
            {
                if (MainWindowViewModel.WindowContext != null)
                    if (MainWindowViewModel.WindowContext.WindowState == 2)
                        user = MainWindowViewModel.WindowContext.GetUser;
                return user;
            }
        }

        public ObservableCollection<Film> FilmsObs
        {
            get
            {
                return new ObservableCollection<Film>(Films);
            }
        }
        private List<Film> _films;
        public List<Film> Films
        {
            get
            {
                if (_films == null)
                    _films = (List<Film>)unitOfWork.Films.GetAll();
                return _films;
            }
            set
            {
                _films = value;
            }
        }


        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get
            {
                NotifyPropertyChanged("SelectedYear");
                return _selectedFilm;
            }
            set
            {
                if (value != null)
                    _selectedFilm = value;
            }
        }


        private int _selectedYear = -1;
        public int SelectedYear
        {
            get
            {
                return _selectedYear;
            }
            set
            {
                _selectedYear = value;
                NotifyPropertyChanged("SelectedYear");
                switch (_selectedYear)
                {
                    case 0:
                        Films = (List<Film>)unitOfWork.Films.GetAll();
                        NotifyPropertyChanged("FilmsObs");
                        break;
                    case 1:
                        Films = unitOfWork.Films.FindFilmByYear1(1996,2000);
                        NotifyPropertyChanged("FilmsObs");
                        break;
                    case 2:
                        Films = unitOfWork.Films.FindFilmByYear1(2001,2005);
                        NotifyPropertyChanged("FilmsObs");
                        break;
                    case 3:
                        Films = unitOfWork.Films.FindFilmByYear1(2006, 2010);
                        NotifyPropertyChanged("FilmsObs");
                        break;
                    case 4:
                        Films = unitOfWork.Films.FindFilmByYear1(2011, 2015);
                        NotifyPropertyChanged("FilmsObs");
                        break;
                    case 5:
                        Films = unitOfWork.Films.FindFilmByYear1(2016, 2020);
                        NotifyPropertyChanged("FilmsObs");
                        break;
                }
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
                    _moreInf = new Command(AboutFilm);
                return _moreInf;
            }
        }

        public void AboutFilm()
        {
            if (_selectedFilm != null)
            {
                _selectedYear = -1;
                NotifyPropertyChanged("SelectedYear");
                MainViewModel.MainContext.Film = _selectedFilm;
                MainViewModel.MainContext.SelectedPage = -1;
                MainViewModel.MainContext.Page = 1;
                MainViewModel.MainContext.WindowState = 2;
                Films = (List<Film>)unitOfWork.Films.GetAll();
                NotifyPropertyChanged("FilmsObs");
            }
            else MessageBox.Show("Select film");
        }
        #endregion
    }
}
