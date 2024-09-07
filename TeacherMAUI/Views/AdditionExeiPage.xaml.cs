using TeacherMAUI.Models;
using TeacherMAUI.Services;


namespace TeacherMAUI
{
    public partial class AdditionExeiPage : ContentPage
    {
          public AdditionExeiPage()
        {
            InitializeComponent();
        }

        async void OnLessonClicked(object sender, EventArgs e)//does the commands in the brackets when onlessonclicked button got clicked
        {
            if (!string.IsNullOrWhiteSpace(tmimaEntry.Text) && !(startlessonEntry == null) && !(endlessonEntry == null) && !(dayEntry == null))//does the code in the brackets if the input is not null
            {
                TimeSpan timeEnds = endlessonEntry.Time;//saving endclessonentry in timeEnds
                TimeSpan timeStarts = startlessonEntry.Time;//saving startlessonentry in timeStarts
                string selectedDay = (string)dayEntry.SelectedItem;//saving dayEntry in selectedDay

                await App.Database.SaveExeiAsync(new Exei //calling SaveExei for insertion of codebinded input
                {
                    Tmima = tmimaEntry.Text,//inserting the Tmima the class is being taught
                    Lesson = lessonEntry.Text,//inserting the Lesson the class is being taught
                    Starts = new DateTime(1, 1, 1, timeStarts.Hours, timeStarts.Minutes, timeStarts.Seconds),//inserting the starting time the class is being taught
                    Ends = new DateTime(1, 1, 1, timeEnds.Hours, timeEnds.Minutes, timeEnds.Seconds),//inserting the closing time the class is being taught
                    Day = selectedDay//inserting the day of the week the class is being taught

                });
                await DisplayAlert("Success", "Class details were saved", "OK");//pop up that says the form entry was submitted

            }

        }


    }

}
