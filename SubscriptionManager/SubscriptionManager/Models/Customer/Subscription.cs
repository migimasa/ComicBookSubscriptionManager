using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Models.Customer
{
    public class Subscription
    {
        [HiddenInput(DisplayValue=false)]
        [JsonProperty(PropertyName = "customerSubscriptionId")]
        public Guid SubscriptionId { get; set; }

        [HiddenInput(DisplayValue=false)]
        [JsonProperty(PropertyName = "customerId")]
        public Guid CustomerId { get; set; }

        [HiddenInput(DisplayValue = false)]
        [JsonProperty(PropertyName = "comicBookSeriesId")]
        public Guid ComicBookSeriesId { get; set; }

        [JsonProperty(PropertyName="publisherName")]
        public string PublisherName { get; set; }

        [JsonProperty(PropertyName="comicBookSeriesTitle")]
        public string ComicBookSeriesTitle { get; set; }

        private DateTime EffectiveDate { get; set; }

        [JsonProperty(PropertyName = "effectiveDate")]
        public string EffectiveDateDisplay
        {
            get
            {
                return this.EffectiveDate.ToLocalTime().ToShortDateString();
            }
        }

        private DateTime ExpiresDate { get; set; }

        [JsonProperty(PropertyName="expiresDate")]
        public string ExpiresDateDisplay
        {
            get
            {
                string display = string.Empty;

                if (this.ExpiresDate.Year < 2099)
                {
                    display = this.ExpiresDate.ToLocalTime().ToShortDateString();
                }
                return display;
            }
        }

        public Subscription(Domain.ComicBookSeriesManagement.Subscription subscription)
        {
            this.SubscriptionId = subscription.CustomerSubscriptionId;
            this.CustomerId = subscription.CustomerId;
            this.ComicBookSeriesId = subscription.ComicBookSeriesId;
            this.PublisherName = subscription.PublisherName;
            this.ComicBookSeriesTitle = subscription.ComicBookSeriesTitle;
            this.EffectiveDate = subscription.EffectiveDate;
            this.ExpiresDate = subscription.ExpiresDate;
        }


    }
}