using TeacherMAUI.Models;
using TeacherMAUI.Services;


namespace TeacherMAUI
{
    public partial class AdditionExeiPage : ContentPage
    {
        int count = 0;

        public AdditionExeiPage()
        {
            InitializeComponent();
        }

        async void OnLessonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tmimaEntry.Text) && !(startchaperonEntry == null) && !(endchaperonEntry == null) && !(dayEntry == null))
            {
                TimeSpan timeEnds = endchaperonEntry.Time;
                TimeSpan timeStarts = startchaperonEntry.Time;
                string selectedDay = (string)dayEntry.SelectedItem;

                await App.Database.SaveExeiAsync(new Exei
                {
                    Tmima = tmimaEntry.Text,
                    Lesson = lessonEntry.Text,
                    Starts = new DateTime(1, 1, 1, timeStarts.Hours, timeStarts.Minutes, timeStarts.Seconds),
                    Ends = new DateTime(1, 1, 1, timeEnds.Hours, timeEnds.Minutes, timeEnds.Seconds),
                    Day = selectedDay
       
                });


            }

        }


    }

}
