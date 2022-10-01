using MauiApp1;
using RealEstateApp.Models;
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

    private async void CvSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as SearchProperty;
        if (currentSelection == null) return;
        await Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }
}