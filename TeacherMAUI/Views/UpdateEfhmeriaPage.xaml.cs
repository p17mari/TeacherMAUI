using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherMAUI.Models;



namespace TeacherMAUI.Views
{

    public partial class UpdateEfhmeriaPage :ContentPage


    {
        private Efhmeria _efhmeria;

        public UpdateEfhmeriaPage(Efhmeria efhmeria)
        {
            InitializeComponent();
            _efhmeria = efhmeria;

            // Initialize pickers and entries with existing data

            startchaperonEntry.Time = efhmeria.Starts.TimeOfDay;

            endchaperonEntry.Time = efhmeria.Ends.TimeOfDay;

            dayEntry.ItemsSource = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            dayEntry.SelectedItem = efhmeria.Day;

            locationEntry.Text = efhmeria.Location;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Update the Efhmeria object with new values
            DateTime defaultDate = new DateTime(); // returns 1/1/0001 12:00:00 AM
            _efhmeria.Starts = defaultDate.Date + startchaperonEntry.Time;
            _efhmeria.Ends = defaultDate.Date + endchaperonEntry.Time;
            _efhmeria.Day = dayEntry.SelectedItem as string;
            _efhmeria.Location = locationEntry.Text;

            // Save changes to the database
            await App.Database.SaveEfhmeriaAsync(_efhmeria);

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page without saving changes
            await Navigation.PopAsync();
        }


    }
}