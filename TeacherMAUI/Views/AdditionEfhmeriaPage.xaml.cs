using TeacherMAUI.Models;


namespace TeacherMAUI
{
    public partial class AdditionEfhmeriaPage : ContentPage
    {
        int count = 0;

        public AdditionEfhmeriaPage()
        {
            InitializeComponent();
        }

        async void OnChaperonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(locationEntry.Text) && !(startchaperonEntry == null) && !(endchaperonEntry == null) && !(dayEntry == null))
            {
                TimeSpan timeEnds = endchaperonEntry.Time;
                TimeSpan timeStarts = startchaperonEntry.Time;
                string selectedDay = (string)dayEntry.SelectedItem;

                await App.Database.SaveEfhmeriaAsync(new Efhmeria
                {
                    Location = locationEntry.Text,
                    Starts = new DateTime(1, 1, 1, timeStarts.Hours, timeStarts.Minutes, timeStarts.Seconds),
                    Ends = new DateTime(1, 1, 1, timeEnds.Hours, timeEnds.Minutes, timeEnds.Seconds),
                    Day = selectedDay
                });


            }

        }


    }

}
