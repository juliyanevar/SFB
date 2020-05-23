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
    public class EditBookViewModel:ViewModelBase
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public EditBookViewModel()
        {

        }

        #region Fields and Properties
        private string _name;
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    if (MainAdminViewModel.MainAdminContext != null)
                    {
                        if (MainAdminViewModel.MainAdminContext.GetBook != null)
                            _name = MainAdminViewModel.MainAdminContext.GetBook.Name;
                    }
                }
                return _name;
            }
            set => _name = value;
        }

        private string _author;
        public string Author
        {
            get
            {
                if (_author == null)
                {
                    if (MainAdminViewModel.MainAdminContext != null)
                    {
                        if (MainAdminViewModel.MainAdminContext.GetBook != null)
                            _author = MainAdminViewModel.MainAdminContext.GetBook.Author;
                    }
                }
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        private int _count=0;
        public int Count
        {
            get
            {
                if (_count == 0)
                {
                    if (MainAdminViewModel.MainAdminContext != null)
                    {
                        if (MainAdminViewModel.MainAdminContext.GetBook != null)
                            _count = MainAdminViewModel.MainAdminContext.GetBook.CountOfChapter;
                    }
                }
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        #endregion

        #region Commands
        private Command _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new Command(Save);
                return _saveCommand;
            }
        }

        public void Save()
        {
            if (MainAdminViewModel.MainAdminContext != null)
            {
                if (MainAdminViewModel.MainAdminContext.GetBook != null)
                {
                    unitOfWork.Books.Update(new Book(MainAdminViewModel.MainAdminContext.GetBook.Id, Name, Author,Count));
                    MessageBox.Show("The book was saved");
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
                MainAdminViewModel.MainAdminContext.WindowState = 9;
        }

        #endregion
    }
}
