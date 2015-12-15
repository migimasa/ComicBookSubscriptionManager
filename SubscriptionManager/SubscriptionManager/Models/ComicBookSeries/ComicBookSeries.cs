using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Models.ComicBookSeries
{
    public class ComicBookSeries
    {
        [HiddenInput(DisplayValue = false)]
        [JsonProperty(PropertyName="comicBookSeriesId")]
        public Guid ComicBookSeriesId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [JsonProperty(PropertyName = "publisherId")]
        public Guid PublisherId { get; set; }

        [JsonProperty(PropertyName = "comicBookSeriesTitle")]
        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A title is requried.")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "A title must be less than 500 characters long.")]
        public string ComicBookSeriesTitle { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public ComicBookSeries(Domain.ComicBookSeriesManagement.Series series)
        {
            this.ComicBookSeriesId = series.ComicBookSeriesId;
            this.PublisherId = series.PublisherId;
            this.ComicBookSeriesTitle = series.ComicBookSeriesTitle;
            this.IsActive = series.IsActive;
        }

        public ComicBookSeries()
        {

        }
    }
}