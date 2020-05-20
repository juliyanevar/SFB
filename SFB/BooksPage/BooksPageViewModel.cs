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

namespace SFB.BooksPage
{
    class BooksPageViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public BooksPageViewModel()
        {

        }

        #region Fields and Properties
        public ObservableCollection<Book> BooksObs
        {
            get
            {
                return new ObservableCollection<Book>(Books);
            }
        }
        private List<Book> _books;
        public List<Book> Books
        {
            get
            {
                _books = (List<Book>)unitOfWork.Books.GetAll();
                return _books;
            }
            set
            {
                _books = value;
            }
        }
        #endregion

        #region Selected
        private Book _selectedBook;
        public Book SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                if (value != null)
                    _selectedBook = value;
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
                    _moreInf = new Command(AboutBook);
                return _moreInf;
            }
        }

        public void AboutBook()
        {
            if (_selectedBook != null)
            {
                MainViewModel.MainContext.Book = _selectedBook;
                MainViewModel.MainContext.SelectedPage = -1;
                MainViewModel.MainContext.Page = 3;
                MainViewModel.MainContext.WindowState = 6;
                _selectedBook = null;
                NotifyPropertyChanged("SelectedBook");
            }
            else MessageBox.Show("Select book");
        }
        #endregion


    }
}
