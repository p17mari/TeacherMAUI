using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherMAUI.Models
{
    public class Efhmeria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Location { get; set; } // location that chaperoning starts

        public DateTime Starts { get; set; } // time event starts
        public DateTime Ends { get; set; } // time event ends
        public string Day { get; set; } // day that the event takes place
    }
}
