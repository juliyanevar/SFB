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
    public class FilmsAdminPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public FilmsAdminPageViewModel()
        {

        }

        #region Fields and Properties
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
                return _selectedFilm;
            }
            set
            {
                if (value != null)
                    _selectedFilm = value;
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
            if (_selectedFilm != null)
            {
                unitOfWork.Films.Delete(_selectedFilm.Id);
                MessageBox.Show("The film was removed");
                Films = (List<Film>)unitOfWork.Films.GetAll();
                NotifyPropertyChanged("FilmsObs");
            }
            else MessageBox.Show("Select film");
        }

        public void Edit()
        {
            if(_selectedFilm!=null)
            {
                MainAdminViewModel.MainAdminContext.Film = _selectedFilm;
                MainAdminViewModel.MainAdminContext.WindowState = 6;
                Films = (List<Film>)unitOfWork.Films.GetAll();
                NotifyPropertyChanged("FilmsObs");
            }
            else MessageBox.Show("Select film");
        }

        public void Add()
        {
            MainAdminViewModel.MainAdminContext.WindowState = 3;
            Films = (List<Film>)unitOfWork.Films.GetAll();
            NotifyPropertyChanged("FilmsObs");
        }
        #endregion
    }
}
