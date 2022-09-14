using System.Collections.ObjectModel;

namespace RealEstateApp;

public partial class SearchPage : ContentPage
{
	public ObservableCollection<PropertySearch> PropertySearchCollection;
	public SearchPage()
	{
		PropertySearchCollection = new ObservableCollection<PropertySearch>
		{
			new PropertySearch() { Address = "Dubai alshing" },
            new PropertySearch() { Address = "Dubai a" },
            new PropertySearch() { Address = "Dubai als" },
			new PropertySearch() { Address = "Dubai alsh" },
            new PropertySearch() { Address = "Dubai birkshire" },
			new PropertySearch() { Address = "Dubai cpirtla" },
			new PropertySearch() { Address = "Dubai dirlma" },
        };
		InitializeComponent();
	}

	private void SbProperty_TextChanged(object sender, TextChangedEventArgs e)
	{
		CvSearch.ItemsSource = PropertySearchCollection.Where(c=>c.Address.Contains(SbProperty.Text.ToLower()));
    }
	public class PropertySearch
	{
		public string Address { get; set; }
	}
}