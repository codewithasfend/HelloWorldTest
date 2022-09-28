﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class Bookmark
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }
        //public string IsBookmark
        //{
        //    get
        //    {
        //        if (Status==true)
        //            return "bookmark_fill_icon.svg";
        //        else if (Status == null)
        //            return "bookmark_icon.svg";
        //        return "bookmark_icon.svg";
        //    }
        //}

        [JsonProperty("user_Id")]
        public int UserId { get; set; }

        [JsonProperty("propertyId")]
        public int PropertyId { get; set; }
    }

    public class PropertyDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl + ImageUrl;


        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("bookmarks")]
        public List<Bookmark> Bookmarks { get; set; }
    }
}
