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
}