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
    public class BookAdminPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public BookAdminPageViewModel()
        {

        }
        #region Fields and Properties
        private string _nameBook;
        public string NameBook
        {
            get
            {
                return _nameBook;
            }
            set
            {
                _nameBook = value;
            }
        }

        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        private string _count;
        public string Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        #endregion


        #region Commands
        private Command _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new Command(AddBook);
                return _addCommand;
            }
        }

        public void AddBook()
        {
            if (_nameBook != null && _author != null && _count != null && int.Parse(_count)>0)
            {
                unitOfWork.Books.Create(new Book(_nameBook, _author, int.Parse(_count)));
                _nameBook = null;
                _author = null;
                _count = null;
                NotifyPropertyChanged("NameBook");
                NotifyPropertyChanged("Author");
                NotifyPropertyChanged("Count");
                MessageBox.Show("The book is added");
            }
            else MessageBox.Show("Incorrect data");
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
                MainAdminViewModel.MainAdminContext.WindowState = 9;
        }
        #endregion
    }
}
