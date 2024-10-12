using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherMAUI.Models;


namespace TeacherMAUI.Views
{

    public partial class UpdateExeiPage : ContentPage
    {
        private Exei _exei;

        public UpdateExeiPage(Exei exei)
        {
            InitializeComponent();
            _exei = exei;

            // Initialize pickers and entries with existing data

            startlessonEntry.Time = exei.Starts.TimeOfDay;
            endlessonEntry.Time = exei.Ends.TimeOfDay;
            dayEntry.ItemsSource = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            dayEntry.SelectedItem = exei.Day;

            lessonEntry.Text = exei.Lesson;
            tmimaEntry.Text = exei.Tmima;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Update the Exei object with new values
            DateTime defaultDate = new DateTime(); // returns 1/1/0001 12:00:00 AM
            _exei.Starts = defaultDate.Date + startlessonEntry.Time;
            _exei.Ends = defaultDate.Date + endlessonEntry.Time;
            _exei.Day = dayEntry.SelectedItem as string;
            _exei.Lesson = lessonEntry.Text;
            _exei.Tmima = tmimaEntry.Text;

            // Save changes to the database
            await App.Database.SaveExeiAsync(_exei);

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