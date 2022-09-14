namespace RealEstateApp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	private void TapSearch_Tapped(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new SearchPage());	
    }

	private void TapCategory_Tapped(object sender, EventArgs e)
	{
        Navigation.PushAsync(new PropertyListPage());
    }
}