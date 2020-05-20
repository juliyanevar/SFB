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

namespace SFB.Chapters
{
    public class ChaptersViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ChaptersViewModel()
        {

        }

        #region Fields and Properties
        private string _nameBook;
        public string NameBook
        {
            get
            {
                _nameBook = MainViewModel.MainContext.GetBook.Name;
                return _nameBook;
            }
        }

        private List<Chapter> _chapters;
        public List<Chapter> Chapters
        {
            get
            {
                if (MainWindowViewModel.WindowContext != null)
                        _chapters = unitOfWork.Chapters.GetChaptersBook(MainViewModel.MainContext.GetBook.Id, MainWindowViewModel.WindowContext.GetUser.Id);
                return _chapters;
            }
            set
            {
                _chapters = value;
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
            foreach (var item in _chapters)
            {
                unitOfWork.Chapters.Update(item);
                NotifyPropertyChanged("Chapters");
            }
            MessageBox.Show("Information was save");
        }
        public void Back()
        {
            MainViewModel.MainContext.WindowState = 6;
        }
        #endregion
    }
}
