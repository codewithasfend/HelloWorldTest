using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using RealEstateApp.Services;

namespace MauiApp1;

public partial class PropertyDetailPage : ContentPage
{
    public PropertyDetailPage(int propertyId)
    {
        InitializeComponent();
        GetPropertyDetail(propertyId);
    }
    
    private async void GetPropertyDetail(int propertyId)
    {
        var property = await ApiService.GetPropertyDetail(propertyId);
        LblAddress.Text= property.Address;
        LblDescription.Text = property.Detail;
        LblPrice.Text = "$ "+property.Price;
        ImgProperty.Source = property.FullImageUrl;

    }
    private async void TapLocation_Tapped(object sender, EventArgs e)
    {

        if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
        {
            // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
            await Launcher.OpenAsync("http://maps.apple.com/?daddr=San+Francisco,+CA&saddr=cupertino");
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
            await Launcher.OpenAsync("http://maps.google.com/?daddr=San+Francisco,+CA&saddr=Mountain+View");
        }
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
        {
            await Launcher.OpenAsync("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052");
        }
    }



    private void TapPhone_Tapped(object sender, EventArgs e)
    {

    }

    private void TapMessage_Tapped(object sender, EventArgs e)
    {

    }

    private void ImgBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();

    }

    private void TapBookmark_Tapped(object sender, EventArgs e)
    {

    }
}