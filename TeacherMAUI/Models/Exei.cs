using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherMAUI.Models
{
    public class Exei //reflects the "Exei" Relationship from the ERD from Documentation
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Lesson { get; set; }//title of lesson at specific timeslot

        public int Tmima { get; set; } // title of tmima at specific timeslot

        public DateTime Starts { get; set; } //time the event starts
        public DateTime Ends { get; set; } //time the event ends
        public string Day { get; set; } //day the event starts
    }
}
