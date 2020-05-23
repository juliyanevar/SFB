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
    public class BooksAdminViewModel:ViewModelBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public BooksAdminViewModel()
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
            if (_selectedBook != null)
            {
                unitOfWork.Books.Delete(_selectedBook.Id);
                MessageBox.Show("The book was removed");
                Books = (List<Book>)unitOfWork.Books.GetAll();
                NotifyPropertyChanged("BooksObs");
            }
            else MessageBox.Show("Select book");
        }

        public void Edit()
        {
            if (_selectedBook != null)
            {
                MainAdminViewModel.MainAdminContext.Book = _selectedBook;
                MainAdminViewModel.MainAdminContext.WindowState = 10;
                Books = (List<Book>)unitOfWork.Books.GetAll();
                NotifyPropertyChanged("BooksObs");
            }
            else MessageBox.Show("Select Book");
        }

        public void Add()
        {
            MainAdminViewModel.MainAdminContext.WindowState = 4;
            Books = (List<Book>)unitOfWork.Books.GetAll();
            NotifyPropertyChanged("BooksObs");
        }
        #endregion
    }
}
