using System.Windows.Input;//to use icommand
using TeacherMAUI.Models;
using TeacherMAUI.Views;
using TeacherMAUI.ViewModels;

namespace TeacherMAUI
{
    public partial class TestPage : ContentPage
    {
        private TimetableViewModel _viewModel;

        public TestPage()
        {
            InitializeComponent();
            _viewModel = new TimetableViewModel();
            BindingContext = _viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadScheduleItems();
        }
    }

}
