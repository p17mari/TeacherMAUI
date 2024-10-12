using SQLite;

namespace TeacherMAUI.Models
{
    public class Schedgule //reflects the "Exei" Relationship from the ERD from Documentation
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Day { get; set; } //day the event starts

        public DateTime Starts { get; set; } //time the event starts
        public DateTime Ends { get; set; } //time the event ends

        public string Type { get; set; } //differentiates the different inputs by "Efhmeria" or "Exei"
        public string Details { get; set; } //test displayed in the ui, Location for Efhmeria, Lesson and Tmima for Exei
        public object OriginalItem { get; set; } // reference to the original Efhmeria or Exei item

    }
}
