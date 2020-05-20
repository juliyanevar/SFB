using SFB.Commands;
using SFB.DataBase;
using SFB.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SFB.BookPage
{
    public class BookPageViewModel : ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public BookPageViewModel()
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


        private string _author;
        public string Author
        {
            get
            {
                _author = MainViewModel.MainContext.GetBook.Author;
                return _author;
            }
        }

        private int _count;
        public int CountOfCh
        {
            get
            {
                _count = MainViewModel.MainContext.GetBook.CountOfChapter;
                return _count;
            }
        }
        #endregion

        #region Commands
        private Command _backCommand;
        private Command _chaptersCommand;

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new Command(Back);
                return _backCommand;
            }
        }
        public ICommand ChaptersCommand
        {
            get
            {
                if (_chaptersCommand == null)
                {
                    _chaptersCommand = new Command(GetChapters);
                }
                return _chaptersCommand;
            }
        }

        public void Back()
        {
            if (MainViewModel.MainContext.Page == 3)
            {
                MainViewModel.MainContext.WindowState = 5;
            }
            else if (MainViewModel.MainContext.Page == 2)
            {
                MainViewModel.MainContext.WindowState = 1;
            }
        }


        public void GetChapters()
        {
            if (_selectedStatus == 0)
            {
                //MainViewModel.MainContext.Page = 4;
                MainViewModel.MainContext.WindowState = 7;
            }
            else MessageBox.Show("Select status 'Read' to go to the page");
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
                        if (unitOfWork.Books.GetStatusBook(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetBook.Id) == "Read")
                            _selectedStatus = 0;
                        else if (unitOfWork.Books.GetStatusBook(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetBook.Id) == "Going to read")
                            _selectedStatus = 1;
                        else if (unitOfWork.Books.GetStatusBook(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetBook.Id) == "Not read")
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
                            unitOfWork.Books.UpdateStatusBook(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetBook.Id, "Read");
                            break;
                        case 1:
                            unitOfWork.Books.UpdateStatusBook(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetBook.Id, "Going to read");
                            break;
                        case 2:
                            unitOfWork.Books.UpdateStatusBook(MainWindowViewModel.WindowContext.GetUser.Id, MainViewModel.MainContext.GetBook.Id, "Not read");
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
