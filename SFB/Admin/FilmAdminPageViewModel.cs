using SFB.Commands;
using SFB.DataBase;
using SFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.Admin
{
    public class FilmAdminPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public FilmAdminPageViewModel()
        {

        }

        #region Fields and Properties
        private string _nameFilm;
        public string NameFilm
        {
            get
            {
                return _nameFilm;
            }
            set
            {
                _nameFilm = value;
            }
        }

        private string _year;
        public string Year { get => _year; set => _year = value; }
        
        private string _nameOfFilm;
        public string NameOfFilm { get => _nameOfFilm; set => _nameOfFilm = value; }
       
        private string _nameOfActor;
        public string NameOfActor { get => _nameOfActor; set => _nameOfActor = value; }

        #endregion

        #region Commands
        private Command _addFilmCommand;
        public ICommand AddFilmCommand
        {
            get
            {
                if (_addFilmCommand == null)
                    _addFilmCommand = new Command(AddFilm);
                return _addFilmCommand;
            }
        }

        public void AddFilm()
        {
            if (_nameFilm != null && _year != null && int.Parse(_year) > 1900)
            {
                unitOfWork.Films.Create(new Film(_nameFilm, int.Parse(_year)));
                _nameFilm = null;
                _year = null;
                NotifyPropertyChanged("NameFilm");
                NotifyPropertyChanged("Year");
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
            if (_nameOfActor != null && _nameOfFilm != null)
            {
                unitOfWork.Actors.CreateFilmActor(_nameOfFilm, _nameOfActor);
                _nameOfActor = null;
                NotifyPropertyChanged("NameOfActor");
                MessageBox.Show("The actor was added");
            }
            else MessageBox.Show("Incorrect data");
        }
        #endregion
    }
}
