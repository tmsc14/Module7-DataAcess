using MauiApp1.Services;
using MauiApp1.ViewModel;

namespace MauiApp1.View;

public partial class ViewPersonal : ContentPage
{
	public ViewPersonal()
	{
		InitializeComponent();

		var personalViewModel = new PersonalViewModel();
		BindingContext = personalViewModel;
	}

    private async void OnBackToMainPageClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}