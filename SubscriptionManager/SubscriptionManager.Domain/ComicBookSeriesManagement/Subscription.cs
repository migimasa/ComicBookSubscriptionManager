using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.ComicBookSeriesManagement
{
    public class Subscription : Base.TransactionBase
    {
        public bool HasData { get; private set; }
        public Guid CustomerSubscriptionId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ComicBookSeriesId { get; private set; }

        public string PublisherName { get; private set; }
        public string ComicBookSeriesTitle { get; private set; }

        public DateTime EffectiveDate { get; private set; }
        public DateTime ExpiresDate { get; private set; }

        public Subscription(DataLayer.DataTables.CustomerSubscription customerSubscription)
        {
            this.HasData = false;
            if (customerSubscription != null)
            {
                this.HasData = true;
                this.CustomerSubscriptionId = customerSubscription.CustomerSubscriptionId;
                this.CustomerId = customerSubscription.CustomerId;
                this.ComicBookSeriesId = customerSubscription.ComicBookSeriesId;
                
                this.PublisherName = customerSubscription.PublisherName;
                this.ComicBookSeriesTitle = customerSubscription.SeriesTitle;

                this.EffectiveDate = customerSubscription.EffectiveDate;
                this.ExpiresDate = customerSubscription.ExpiresDate;
            }
        }

        public Migi.Framework.Models.ChangeResult Expire(Guid userId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (!IsCustomerComicBookAlreadyExpired())
            {
                SubscriptionManager.DataLayer.Abstract.ICustomerSubscriptionAccess customerComicBookDataLayer = new SubscriptionManager.DataLayer.Access.CustomerSubscriptionAccess();

                result.IsSuccess = customerComicBookDataLayer.RemoveSubscription(new DataLayer.DataTables.CustomerSubscription()
                {
                    ChangeDate = DateTime.UtcNow,
                    ChangeUserId = userId,
                    ComicBookSeriesId = this.ComicBookSeriesId,
                    CustomerSubscriptionId = this.CustomerSubscriptionId,
                    CustomerId = this.CustomerId,
                    DeleteDate = DateTime.UtcNow,
                    ExpiresDate = DateTime.UtcNow
                });
            }
            else
            {
                result.AddErrorMessage("Subscription has already been removed.");
            }

            return result;
        }

        private bool IsCustomerComicBookAlreadyExpired()
        {
            return this.ExpiresDate < DateTime.UtcNow;
        }
    }

    public class Subscriptions : List<Subscription>
    {
        private Guid CustomerId { get; set; }
        private DateTime SearchDate { get; set; }

        private DataLayer.Abstract.ICustomerSubscriptionAccess _customerSubscriptionAccess;
        private DataLayer.Abstract.ICustomerSubscriptionAccess CustomerSubscriptionAccess
        {
            get
            {
                if (this._customerSubscriptionAccess == null)
                {
                    this._customerSubscriptionAccess = new DataLayer.Access.CustomerSubscriptionAccess();
                }
                return _customerSubscriptionAccess;
            }
        }

        public Subscriptions(Guid customerId, DateTime searchDate)
        {
            this.CustomerId = customerId;
            this.SearchDate = searchDate;

            this.Process();
        }

        private void Process()
        {
            var customerSubscriptions = this.CustomerSubscriptionAccess.LoadSubscriptionsForCustomer(this.CustomerId, this.SearchDate);

            foreach (var subscription in customerSubscriptions)
            {
                this.Add(new Subscription(subscription));
            }
        }


        public Migi.Framework.Models.ChangeResult AddSubscription(Guid comicBookSeriesId, Guid userId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (!IsCustomerAlreadySubscribed(comicBookSeriesId))
            {
                DataLayer.DataTables.CustomerSubscription customerSubscription = new DataLayer.DataTables.CustomerSubscription()
                {
                    ChangeDate = DateTime.Now,
                    ChangeUserId = userId,
                    ComicBookSeriesId = comicBookSeriesId,
                    CreateDate = DateTime.Now,
                    CreateUserId = userId,
                    CustomerSubscriptionId = Guid.NewGuid(),
                    CustomerId = this.CustomerId,
                    DeleteDate = null,
                    EffectiveDate = DateTime.Now,
                    ExpiresDate = Base.Helper.GetDefaultExpiresDate()
                };

                if (!this._customerSubscriptionAccess.AddSubscription(customerSubscription))
                {
                    result.AddErrorMessage("Could not save subscription");
                }
            }
            else
            {
                result.AddErrorMessage("Customer is already subscribed.");
            }

            return result;
        }

        private bool IsCustomerAlreadySubscribed(Guid comicBookSeriesId)
        {
            Subscription subscription = GetSubscription(comicBookSeriesId);

            if (subscription != null)
            {
                return true;
            }
            return false;
        }

        public Migi.Framework.Models.ChangeResult RemoveSubscription(Guid comicBookSeriesId, Guid userId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();
            Subscription subscription = GetSubscription(comicBookSeriesId);

            if (subscription != null)
            {
                result = subscription.Expire(userId);
            }
            else
            {
                result.AddErrorMessage("Could not load subscription.");
            }
            return result;
        }

        public Subscription GetSubscription(Guid comicBookSeriesId)
        {
            Subscription subscription = null;

            subscription = this.Where(x => x.ComicBookSeriesId == comicBookSeriesId).FirstOrDefault();

            return subscription;
        }
    }
}
