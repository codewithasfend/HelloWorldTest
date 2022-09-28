using RealEstateApp.Services;
using System.Collections.ObjectModel;

namespace RealEstateApp;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}

	private async void SbProperty_TextChanged(object sender, TextChangedEventArgs e)
	{
        if (e.NewTextValue == null)
        {
            return;
        }
        var propertiesList = await ApiService.FindProperties(e.NewTextValue.ToLower());
        CvSearch.ItemsSource = propertiesList;
    }

	private void ImgBack_Clicked(object sender, EventArgs e)
	{
        Navigation.PopModalAsync(); 
    }
}