using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class Film
    {
        public Film() { }

        public Film(int id, string name, int year)
        {
            Id = id;
            Name = name;
            Year = year;
        }

        public Film(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
