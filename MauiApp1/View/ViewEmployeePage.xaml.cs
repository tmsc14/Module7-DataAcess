using MauiApp1.ViewModel;

namespace MauiApp1.View
{
    public partial class ViewEmployeePage : ContentPage
    {
        public ViewEmployeePage()
        {
            InitializeComponent();
            BindingContext = new EmployeeViewModel();
        }

        private async void OnBackToMainPageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
