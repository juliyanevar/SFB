using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class Series
    {
        public Series() { }

        public Series(int id, int id_serial, int numberSeason, int numberSeries, bool status, int id_user)
        {
            Id = id;
            Id_serial = id_serial;
            NumberSeason = numberSeason;
            NumberSeries = numberSeries;
            Status = status;
            Id_user = id_user;
        }

        public int Id { get; set; }
        public int Id_serial { get; set; }
        public int NumberSeason { get; set; }
        public int NumberSeries { get; set; }
        public bool Status { get; set; }
        public int Id_user { get; set; }
    }
}
