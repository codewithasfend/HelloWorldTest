using MauiApp1;

namespace RealEstateApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // MainPage = new AppShell();
       // MainPage = new CustomTabbedPage();
       // MainPage = new LoginPage();
        var accessToken = Preferences.Get("accessToken", string.Empty);
        if (string.IsNullOrEmpty(accessToken))
        {
            MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            //MainPage = new NavigationPage(new CustomTabbedPage());
           // MainPage = new CustomTabbedPage();
            Application.Current.MainPage = new CustomTabbedPage();
            //MainPage = new HomePage();

        }
    }
}
