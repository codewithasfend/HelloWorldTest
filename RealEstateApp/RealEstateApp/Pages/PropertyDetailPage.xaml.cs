using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using RealEstateApp.Models;
using RealEstateApp.Services;

namespace MauiApp1;

public partial class PropertyDetailPage : ContentPage
{
    private static bool IsBookmarkEnabled;
    private int propertyId;
    private int bookmarkId;
    public PropertyDetailPage(int propertyId)
    {
        InitializeComponent();
        GetPropertyDetail(propertyId);
        this.propertyId = propertyId;
    }

    private async void GetPropertyDetail(int propertyId)
    {
        var property = await ApiService.GetPropertyDetail(propertyId);
        LblAddress.Text= property.Address;
        LblDescription.Text = property.Detail;
        LblPrice.Text = "$ "+property.Price;
        ImgProperty.Source = property.FullImageUrl;
        if (property.Bookmarks==null)
        {
            ImgBookmark.Source = "bookmark_icon.svg";
            IsBookmarkEnabled = false;
        }
        else
        {
            ImgBookmark.Source = property.Bookmarks[0].Status ? "bookmark_fill_icon.svg" : "bookmark_icon.svg";
            bookmarkId= property.Bookmarks[0].Id;
            IsBookmarkEnabled = true;
        }
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

    private async void TapBookmark_Tapped(object sender, EventArgs e)
    {
        if (IsBookmarkEnabled== false)
        {
            var addBookmark = new AddBookmark()
            {
                PropertyId = propertyId,
                User_Id = Preferences.Get("userId", 0)
            };
            var response = await ApiService.AddBookMark(addBookmark);
            if (response)
            {
                ImgBookmark.Source = "bookmark_fill_icon.svg";
                IsBookmarkEnabled = true;
            }
        }
        else
        {
            var response = await ApiService.DeleteBookMark(bookmarkId);
            if (response)
            {
                ImgBookmark.Source = "bookmark_icon.svg";
                IsBookmarkEnabled = false;
            }
        }
    }

    private void TapBack_Tapped(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}