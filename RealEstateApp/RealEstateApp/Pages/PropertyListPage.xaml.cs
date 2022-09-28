using MauiApp1;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System.Collections.ObjectModel;

namespace RealEstateApp;

public partial class PropertyListPage : ContentPage
{
    ObservableCollection<PropertyByCategory> PropertiesCollection;

    public PropertyListPage(int categoryId, string categoryName)
    {
        InitializeComponent();
        Title = categoryName;
        PropertiesCollection = new ObservableCollection<PropertyByCategory>();
        GetPropertiesList(categoryId);
    }


    private async void GetPropertiesList(int categoryId)
    {
        var properties = await ApiService.GetPropertyByCategory(categoryId);
        foreach (var property in properties)
        {
            PropertiesCollection.Add(property);
        }
        CvProperty.ItemsSource = PropertiesCollection;
    }

    private async void CvProperty_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as PropertyByCategory;
        if (currentSelection == null) return;
        await Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }
}