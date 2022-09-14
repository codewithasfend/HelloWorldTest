using MauiApp1;

namespace RealEstateApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        //MainPage = new PropertyDetailPage();
	}
}
