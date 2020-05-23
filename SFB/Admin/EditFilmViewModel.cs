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
    public class EditFilmViewModel : ViewModelBase
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public EditFilmViewModel()
        {

        }

        #region Fields and Properties
        private string _name;
        private int _year = 0;
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
                        if (MainAdminViewModel.MainAdminContext.GetFilm != null)
                            _name = MainAdminViewModel.MainAdminContext.GetFilm.Name;
                    }
                }
                return _name;
            }
            set => _name = value;
        }
        public int Year
        {
            get
            {
                if (_year == 0)
                {
                    if (MainAdminViewModel.MainAdminContext != null)
                    {
                        if (MainAdminViewModel.MainAdminContext.GetFilm != null)
                            _year = MainAdminViewModel.MainAdminContext.GetFilm.Year;
                    }
                }
                return _year;
            }
            set => _year = value;
        }
        public List<Actor> Actors
        {
            get
            {
                if (MainAdminViewModel.MainAdminContext != null)
                {
                    if (MainAdminViewModel.MainAdminContext.GetFilm != null)
                        _actors = unitOfWork.Actors.GetActorFilm(MainAdminViewModel.MainAdminContext.GetFilm.Id);
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
                    if (MainAdminViewModel.MainAdminContext.GetFilm != null)
                    {
                        unitOfWork.Actors.Delete(_selectedActror.Id);
                        MessageBox.Show("The actor was removed");
                        Actors = unitOfWork.Actors.GetActorFilm(MainAdminViewModel.MainAdminContext.GetFilm.Id);
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
                if (MainAdminViewModel.MainAdminContext.GetFilm != null)
                {
                    unitOfWork.Films.Update(new Film(MainAdminViewModel.MainAdminContext.GetFilm.Id, Name, Year));
                    MessageBox.Show("The film was saved");
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
                MainAdminViewModel.MainAdminContext.WindowState = 5;
        }
        #endregion 

    }
}
