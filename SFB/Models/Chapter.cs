using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class Chapter
    {
        public Chapter() { }

        public Chapter(int id, int id_book, int number, bool status, int id_user)
        {
            Id = id;
            Id_book = id_book;
            Number = number;
            Status = status;
            Id_user = id_user;
        }

        public int Id { get; set; }
        public int Id_book { get; set; }
        public int Number { get; set; }
        public bool Status { get; set; }
        public int Id_user { get; set; }
    }
}
