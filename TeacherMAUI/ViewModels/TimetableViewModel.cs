using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TeacherMAUI.Models;
using TeacherMAUI.Views;


namespace TeacherMAUI.ViewModels
{
    public class TimetableViewModel : BindableObject
    {


        private ObservableCollection<FinalTimetable> _finalTimetableItems; 
        public ObservableCollection<FinalTimetable> FinalTimetableItems
        {
            get => _finalTimetableItems; //the result of the loadscheduleitems task below is the sorted 
            set
            {
                _finalTimetableItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand EditItemCommand { get; private set; }
        public ICommand DeleteItemCommand { get; private set; }

        public TimetableViewModel()
        {
            EditItemCommand = new Command<Schedgule>(EditItem);
            DeleteItemCommand = new Command<Schedgule>(DeleteItem);

        }

        public async Task LoadScheduleItems()
        {
            // Use Task.WhenAll to fetch data in parallel
            var efhmeriaTask = App.Database.GetEfhmeriasAsync();
            var exeiTask = App.Database.GetExeisAsync();

            await Task.WhenAll(efhmeriaTask, exeiTask);

            var efhmeriaItems = efhmeriaTask.Result;
            var exeiItems = exeiTask.Result;

            var orderedDays = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            var schedgules = new List<Schedgule>();

            schedgules.AddRange(efhmeriaItems.Select(efh => new Schedgule
            {
                Day = efh.Day,
                Starts = efh.Starts,
                Ends = efh.Ends,
                Type = "Efhmeria",
                Details = efh.Location,
                OriginalItem = efh
            }));

            schedgules.AddRange(exeiItems.Select(exei => new Schedgule
            {
                Day = exei.Day,
                Starts = exei.Starts,
                Ends = exei.Ends,
                Type = "Exei",
                Details = $"{exei.Lesson} - {exei.Tmima}",
                OriginalItem = exei
            }));

            var groupedItems = schedgules
                .GroupBy(item => item.Day)
                .Select(f => new FinalTimetable(f.Key, f.OrderBy(item => item.Starts).ToList()))
                .OrderBy(f => Array.IndexOf(orderedDays, f.DayOfWeek))
                .ToList();

            FinalTimetableItems = new ObservableCollection<FinalTimetable>(groupedItems);


        }

        private async void EditItem(Schedgule item)
        {
            Page editPage;
            if (item.Type == "Efhmeria")
            {
                editPage = new UpdateEfhmeriaPage((Efhmeria)item.OriginalItem);
            }
            else // Exei
            {
                editPage = new UpdateExeiPage((Exei)item.OriginalItem);
            }

            await Application.Current.MainPage.Navigation.PushAsync(editPage);

            // Refresh the list after returning from the edit page
            await LoadScheduleItems();
        }
        private async void DeleteItem(Schedgule item)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirm Delete", $"Are you sure you want to delete this {item.Type} item?", "Yes", "No");
            if (confirm)
            {
                try
                {
                    // Delete from database based on type
                    if (item.Type == "Efhmeria")
                    {
                        await App.Database.DeleteEfhmeriaAsync((Efhmeria)item.OriginalItem);
                    }
                    else if (item.Type == "Exei")
                    {
                        await App.Database.DeleteExeiAsync((Exei)item.OriginalItem);
                    }

                    // Refresh the list after successful deletion
                    await LoadScheduleItems();

                    await Application.Current.MainPage.DisplayAlert("Delete", $"{item.Type} item deleted", "OK");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"Failed to delete item: {ex.Message}", "OK");
                }
            }
        }
    }
}