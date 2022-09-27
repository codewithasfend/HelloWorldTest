using RealEstateApp.Services;

namespace RealEstateApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void BtnSignIn_Clicked(object sender, EventArgs e)
    {

        var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);
        Preferences.Set("email", EntEmail.Text);
        Preferences.Set("password", EntPassword.Text);
        if (response)
        {
            // Application.Current.MainPage = new NavigationPage(new HomePage());
            Application.Current.MainPage = new NavigationPage(new CustomTabbedPage());

        }
        else
        {
            await DisplayAlert("Oops", "Something went wrong", "Cancel");
        }


        //await Navigation.PushModalAsync(new HomePage());
        // Application.Current.MainPage = new CustomTabbedPage();
        //await Shell.Current.GoToAsync($"//MainPage");

    }

    private async void TapJoinNow_Tapped(object sender, EventArgs e)
    {
        // await Shell.Current.GoToAsync($"{nameof(LoginPage)}/{nameof(RegisterPage)}");
        await Navigation.PushModalAsync(new RegisterPage());

    }
}