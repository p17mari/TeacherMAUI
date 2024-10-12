using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherMAUI.Models
{
    public class FinalTimetable : List<Schedgule> //class that handles Schedgule as a sorted list
    {
       
            public string DayOfWeek { get; private set; }//Day of Week for the timetable item

            public FinalTimetable(string dayOfWeek, List<Schedgule> items) : base(items)
            {
                DayOfWeek = dayOfWeek;
            }
        
    }
}
