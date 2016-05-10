using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models.Customer
{
    public class Library
    {
        [JsonProperty(PropertyName="customerId")]
        public Guid CustomerId { get; set; }
        private DateTime SearchDate { get; set; }
        
        //list of subscriptions
        private List<Subscription> _subscriptions;

        [JsonProperty(PropertyName = "subscriptions")]
        public List<Subscription> Subscriptions
        {
            get
            {
                if (_subscriptions == null)
                {
                    _subscriptions = GetSubscriptions();
                }
                return _subscriptions;
            }
        }

        public Library(Guid customerId, DateTime searchDate)
        {
            this.CustomerId = customerId;
            this.SearchDate = searchDate;
        }

        private List<Subscription> GetSubscriptions()
        {
            List<Subscription> subscriptions = new List<Subscription>();

            Domain.CustomerManagement.Library customerLibrary = new Domain.CustomerManagement.Library(this.CustomerId, Migi.Framework.Helper.Search.GetUTCEndOfDaySearchDate(this.SearchDate));

            foreach (var subscription in customerLibrary.Subscriptions)
            {
                subscriptions.Add(new Subscription(subscription));
            }

            return subscriptions;
        }
    }
}