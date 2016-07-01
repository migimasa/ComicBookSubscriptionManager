using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperWrapper;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.Access;
using SubscriptionManager.DataLayer.DataTables;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Library
    {
        //private Guid CustomerId { get; set; }
        //private DateTime SearchDate { get; set; }
        //private bool ShowRemovedSubscriptions { get; set; }

        //private ICustomerSubscriptionAccess _subscriptionAccess;
        //private ICustomerSubscriptionAccess SubscriptionAccess
        //{
        //    get
        //    {
        //        if (_subscriptionAccess == null)
        //        {
        //            _subscriptionAccess = new CustomerSubscriptionAccess();
        //        }
        //        return _subscriptionAccess;
        //    }
        //}

        //private List<ISubscription> _subscriptions;
        //public List<ISubscription> Subscriptions
        //{
        //    get
        //    {
        //        if (_subscriptions == null)
        //        {
        //            _subscriptions = GetCustomerSubscriptions();
        //        }
        //        return _subscriptions;
        //    }
        //}

        //public Library(Guid customerId, DateTime searchDate, bool showRemovedSubscriptions)
        //{
        //    this.CustomerId = customerId;
        //    this.SearchDate = searchDate;
        //    this.ShowRemovedSubscriptions = showRemovedSubscriptions;
        //}
        //public Library(Guid customerId, DateTime searchDate)
        //    : this(customerId, searchDate, false)
        //{

        //}

        //public ISubscription GetSubscription(Guid subscriptionId)
        //{
        //    return Subscriptions.Where(x => x.SubscriptionId == subscriptionId).FirstOrDefault();
        //}

        //private List<ISubscription> GetCustomerSubscriptions()
        //{
        //    List<ISubscription> subscriptions = new List<ISubscription>();

        //    var customerSubscriptions = SubscriptionAccess.LoadSubscriptionsForCustomer(this.CustomerId, this.SearchDate);

        //    foreach (CustomerSubscription subscription in customerSubscriptions)
        //    {
        //        if (IsSubscriptionThatNeedsToBeShown(subscription))
        //        {
        //            subscriptions.Add(new Subscription(subscription));
        //        }
        //    }
        //    return subscriptions;
        //}

        //private bool IsSubscriptionThatNeedsToBeShown(CustomerSubscription subscription)
        //{
        //    bool showSubscription = true;

        //    if (!this.ShowRemovedSubscriptions && subscription.DeleteDate.HasValue)
        //    {
        //        showSubscription = false;
        //    }
        //    return showSubscription;
        //}

        //public Migi.Framework.Models.ChangeResult AddSubscription(Guid comicBookSeriesId, Guid userId)
        //{
        //    Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

        //    if (!IsCustomerAlreadySubscribedToSeries(comicBookSeriesId))
        //    {
        //        ISubscription subscription = Subscription.GetNewSubscription(this.CustomerId, comicBookSeriesId, userId);

        //        result = subscription.Save();

        //        ClearSubscriptionsForRefresh();
        //    }
        //    else
        //    {
        //        result.AddErrorMessage("Customer is already subscribed.");
        //    }


        //    return result;
        //}

        //public Migi.Framework.Models.ChangeResult RemoveSubscription(Guid subscriptionId, Guid userId)
        //{
        //    Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

        //    ISubscription subscriptionToRemove = GetSubscription(subscriptionId);

        //    if (subscriptionToRemove != null)
        //    {
        //        result = subscriptionToRemove.Remove(userId);
        //    }
        //    else
        //    {
        //        result.AddErrorMessage("Cannot remove subscription.");
        //    }

        //    return result;
        //}

        //private bool IsCustomerAlreadySubscribedToSeries(Guid comicBookSeriesId)
        //{
        //    List<Guid> customerComicBookSeriesIds = this.Subscriptions.Select(x => x.ComicBookSeriesId).ToList();

        //    return customerComicBookSeriesIds.Contains(comicBookSeriesId);
        //}

        //private void ClearSubscriptionsForRefresh()
        //{
        //    if (this._subscriptions != null)
        //    {
        //        this._subscriptions = null;
        //    }
        //}

    }
}
