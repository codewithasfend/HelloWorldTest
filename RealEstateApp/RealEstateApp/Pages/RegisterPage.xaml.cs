using RealEstateApp.Services;

namespace RealEstateApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void BtnRegister_Clicked(object sender, EventArgs e)
    {

        var response = await ApiService.RegisterUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);
        if (response)
        {
            Preferences.Set("username", EntFullName.Text);
            await DisplayAlert("", "Your account has been created", "Alright");
            await Navigation.PushModalAsync(new LoginPage());
        }
        else
        {
            await DisplayAlert("Oops", "Something went wrong", "Cancel");
        }

    }

    private async void TapSignIn_Tapped(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}