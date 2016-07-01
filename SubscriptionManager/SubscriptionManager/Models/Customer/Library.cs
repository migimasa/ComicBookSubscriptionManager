using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models.Customer
{
    public class Library
    {
        [JsonProperty(PropertyName = "customerId")]
        public Guid CustomerId { get; set; }
        private DateTime SearchDate { get; set; }

        [JsonProperty(PropertyName = "subscriptions")]
        public List<Subscription> Subscriptions { get; set; }


        public Library(Guid customerId, List<Domain.CustomerManagement.Subscription> subscriptions)
        {
            CustomerId = customerId;
            Subscriptions = new List<Subscription>();

            FillSubscriptions(subscriptions);
        }

        private void FillSubscriptions(List<Domain.CustomerManagement.Subscription> customerSubscriptions)
        {
            foreach (var subscription in customerSubscriptions)
                Subscriptions.Add(new Subscription(subscription));
        }
    }
}