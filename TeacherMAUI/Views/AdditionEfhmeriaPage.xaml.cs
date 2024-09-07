using TeacherMAUI.Models;


namespace TeacherMAUI
{
    public partial class AdditionEfhmeriaPage : ContentPage
    {
    

        public AdditionEfhmeriaPage()
        {
            InitializeComponent();
        }

        async void OnChaperonClicked(object sender, EventArgs e)//does the commands in the brackets when onlessonclicked button got clicked
        {
            if (!string.IsNullOrWhiteSpace(locationEntry.Text) && !(startchaperonEntry == null) && !(endchaperonEntry == null) && !(dayEntry == null))//does the code in the brackets if the input is not null
            {
                TimeSpan timeEnds = endchaperonEntry.Time;//saving endchaperonentry in timeEnds
                TimeSpan timeStarts = startchaperonEntry.Time;//saving startchaperonentry in timeStarts
                string selectedDay = (string)dayEntry.SelectedItem;//saving dayEntry in selectedDay

                await App.Database.SaveEfhmeriaAsync(new Efhmeria //calling SaveEfhmeria for insertion of codebinded input
                {
                    Location = locationEntry.Text,//inserting the location where the chaperoning takes place
                    Starts = new DateTime(1, 1, 1, timeStarts.Hours, timeStarts.Minutes, timeStarts.Seconds),//inserting the starting time the chaperoning starts
                    Ends = new DateTime(1, 1, 1, timeEnds.Hours, timeEnds.Minutes, timeEnds.Seconds),//inserting the closing time the chaperoning ends
                    Day = selectedDay//inserting the day the chaperoning ends
                });

                await DisplayAlert("Success", "Chaperoning details were saved", "OK");//pop up that says the form entry was submitted

            }

        }


    }

}
