using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class Serial
    {
        public Serial() { }

        public Serial(int id, string name, int count)
        {
            Id = id;
            Name = name;
            CountOfSeason = count;
        }

        public Serial(string name, int count)
        {
            Name = name;
            CountOfSeason = count;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfSeason { get; set; }
    }
}
