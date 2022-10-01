using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using RealEstateApp.Models;
using RealEstateApp.Services;

namespace MauiApp1;

public partial class PropertyDetailPage : ContentPage
{
    private bool IsBookmarkEnabled;
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

    private void TapPhone_Tapped(object sender, EventArgs e)
    {

    }

    private void TapMessage_Tapped(object sender, EventArgs e)
    {

    }


    private void ImgBackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void ImgBookmark_Clicked(object sender, EventArgs e)
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
}