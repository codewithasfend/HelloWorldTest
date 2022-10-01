using MauiApp1;

namespace RealEstateApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
     
        var accessToken = Preferences.Get("accessToken", string.Empty);
        if (string.IsNullOrEmpty(accessToken))
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            MainPage = new CustomTabbedPage();
        }
    }
}
