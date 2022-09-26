using MauiApp1;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System.Collections.ObjectModel;

namespace RealEstateApp;

public partial class HomePage : ContentPage
{
    ObservableCollection<Category> CategoriesCollection;
    ObservableCollection<TrendingProperty> TopPicksCollection;
    public HomePage()
    {
        InitializeComponent();
        CategoriesCollection = new ObservableCollection<Category>();
        TopPicksCollection = new ObservableCollection<TrendingProperty>();
        GetCategories();
        GetTrendingProperties();

    }

    private void TapSearch_Tapped(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new SearchPage());
    }

    // Navigation.PushAsync(new PropertyListPage());

    private async void GetTrendingProperties()
    {
        var properties = await ApiService.GetTrendingProperties();
        foreach (var property in properties)
        {
            TopPicksCollection.Add(property);
        }
        CvTopPicks.ItemsSource = TopPicksCollection;
    }
    private async void GetCategories()
    {
        var categories = await ApiService.GetCategories();
        foreach (var category in categories)
        {
            CategoriesCollection.Add(category);
        }
        CvCategories.ItemsSource = CategoriesCollection;
    }

    private async void CvTopPicks_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as TrendingProperty;
        if (currentSelection == null) return;
        await Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }

    private async void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
        if (currentSelection == null) return;
        await Navigation.PushAsync(new PropertyListPage(currentSelection.Id, currentSelection.Name));
        ((CollectionView)sender).SelectedItem = null;
    }
}