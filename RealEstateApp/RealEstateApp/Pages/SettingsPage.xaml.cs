namespace RealEstateApp;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

    }

    void TapLogout_Tapped(System.Object sender, System.EventArgs e)
    {
        Preferences.Set("accessToken", string.Empty);
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }

}