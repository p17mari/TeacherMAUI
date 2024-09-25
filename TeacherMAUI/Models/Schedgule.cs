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

        public string Name { get; set; }
    }
}
