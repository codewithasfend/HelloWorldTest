using MauiApp1;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System.Collections.ObjectModel;

namespace RealEstateApp;

public partial class BookmarkPage : ContentPage
{

    ObservableCollection<BookmarkList> PropertiesCollection;

    public BookmarkPage()
    {
        InitializeComponent();
        PropertiesCollection = new ObservableCollection<BookmarkList>();
        GetPropertiesList();
    }


    private async void GetPropertiesList()
    {
        var properties = await ApiService.GetBookmarkList();
        foreach (var property in properties)
        {
            PropertiesCollection.Add(property); 
        }
        CvProperty.ItemsSource = PropertiesCollection;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        //GetPropertiesList();

    }

    private async void CvProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        var currentSelection = e.CurrentSelection.FirstOrDefault() as BookmarkList;
        if (currentSelection == null) return;
        await Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.PropertyId));
        ((CollectionView)sender).SelectedItem = null;
    }
}