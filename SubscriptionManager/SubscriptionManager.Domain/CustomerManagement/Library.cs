using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.Access;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Library
    {
        private Guid CustomerId { get; set; }
        private DateTime SearchDate { get; set; }

        private ICustomerSubscriptionAccess _subscriptionAccess;
        private ICustomerSubscriptionAccess SubscriptionAccess
        {
            get
            {
                if (_subscriptionAccess == null)
                {
                    _subscriptionAccess = new CustomerSubscriptionAccess();
                }
                return _subscriptionAccess;
            }
        }

        private List<Subscription> _subscriptions;
        public List<Subscription> Subscriptions
        {
            get
            {
                if (_subscriptions == null)
                {
                    _subscriptions = GetCustomerSubscriptions();
                }
                return _subscriptions;
            }
        }

        public Library(Guid customerId, DateTime searchDate)
        {
            this.CustomerId = customerId;
            this.SearchDate = searchDate;
        }

        private List<Subscription> GetCustomerSubscriptions()
        {
            List<Subscription> subscriptions = new List<Subscription>();

            var customerSubscriptions = SubscriptionAccess.LoadSubscriptionsForCustomer(this.CustomerId, this.SearchDate);

            foreach (CustomerSubscription subscription in customerSubscriptions)
            {
                subscriptions.Add(new Subscription(subscription));
            }
            return subscriptions;
        }

        public Migi.Framework.Models.ChangeResult AddSubscription(Guid comicBookSeriesId, Guid userId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (!IsCustomerAlreadySubscribedToSeries(comicBookSeriesId))
            {
                Subscription subscription = Subscription.GetNewSubscription(this.CustomerId, comicBookSeriesId, userId);

                result = subscription.Save();
            }
            else
            {
                result.AddErrorMessage("Customer is already subscribed.");
            }

            return result;
        }

        private bool IsCustomerAlreadySubscribedToSeries(Guid comicBookSeriesId)
        {
            List<Guid> customerComicBookSeriesIds = this.Subscriptions.Select(x => x.ComicBookSeriesId).ToList();

            return customerComicBookSeriesIds.Contains(comicBookSeriesId);            
        }

    }
}
