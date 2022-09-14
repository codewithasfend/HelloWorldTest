using System.Collections.ObjectModel;

namespace RealEstateApp;

public partial class SettingsPage : ContentPage
{
    public ObservableCollection<Settings> SettingsCollection;
    public SettingsPage()
    {
        InitializeComponent();
        SettingsCollection = new ObservableCollection<Settings>();
        SettingsCollection.Add(new Settings() { Id = 1, Name = "About", ImageName="account_icon" });
        SettingsCollection.Add(new Settings() { Id = 2, Name = "Privacy & Security", ImageName="privacy_icon" });
        SettingsCollection.Add(new Settings() { Id = 3, Name = "Help & Support", ImageName="faq_icon" });
        SettingsCollection.Add(new Settings() { Id = 4, Name = "Logout", ImageName="logout_box_icon" });
        CvSettings.ItemsSource = SettingsCollection;
    }

    public class Settings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
    }
}