using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.DataTables;
using SubscriptionManager.DataLayer.Access;

using Ninject;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Subscription
    {
        public bool HasData { get; private set; }
        public Guid SubscriptionId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ComicBookSeriesId { get; private set; }

        public string PublisherName { get; private set; }
        public string SeriesTitle { get; private set; }

        public DateTime EffectiveDate { get; private set; }
        public DateTime ExpiresDate { get; private set; }

        private DateTime CreateDate { get; set; }
        private Guid CreateUserId { get; set; }
        private Guid ChangeUserId { get; set; }
        private DateTime ChangeDate { get; set; }
        private DateTime? DeleteDate { get; set; }


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

        public Subscription(Guid subscriptionId)
        {
            Instantiate(SubscriptionAccess.LoadCustomerSubscription(subscriptionId));
        }

        public Subscription(CustomerSubscription subscriptionDl)
        {
            Instantiate(subscriptionDl);
        }

        public Subscription()
        {
            this.HasData = false;
        }

        private void Instantiate(CustomerSubscription subscriptionDl)
        {
            
            this.HasData = false;

            if (subscriptionDl != null)
            {
                this.HasData = true;
                this.SubscriptionId = subscriptionDl.CustomerSubscriptionId;
                this.CustomerId = subscriptionDl.CustomerId;
                this.ComicBookSeriesId = subscriptionDl.ComicBookSeriesId;

                this.PublisherName = subscriptionDl.PublisherName;
                this.SeriesTitle = subscriptionDl.SeriesTitle;

                this.EffectiveDate = subscriptionDl.EffectiveDate;
                this.ExpiresDate = subscriptionDl.ExpiresDate;

                this.CreateDate = subscriptionDl.CreateDate;
                this.CreateUserId = subscriptionDl.CreateUserId;
                this.ChangeUserId = subscriptionDl.ChangeUserId;
                this.ChangeDate = subscriptionDl.ChangeDate;
                this.DeleteDate = subscriptionDl.DeleteDate;
            }
        }

        public Migi.Framework.Models.ChangeResult Remove(Guid changeUserId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (!IsSubscriptionAlreadyRemoved())
            {
                this.ExpiresDate = DateTime.UtcNow;
                this.DeleteDate = DateTime.UtcNow;
                this.ChangeUserId = changeUserId;
                this.ChangeDate = DateTime.UtcNow;

                result = this.Save();
            }
            else
            {
                result.AddErrorMessage("Subscription has already been removed.");
            }

            return result;
        }

        private bool IsSubscriptionAlreadyRemoved()
        {
            return (this.ExpiresDate < DateTime.UtcNow || this.DeleteDate.HasValue);
        }

        public Migi.Framework.Models.ChangeResult Save()
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            CustomerSubscription subscriptionDl = new CustomerSubscription()
            {
                ChangeDate = this.ChangeDate,
                ChangeUserId = this.ChangeUserId,
                ComicBookSeriesId = this.ComicBookSeriesId,
                CreateDate = this.CreateDate,
                CreateUserId = this.CreateUserId,
                CustomerId = this.CustomerId,
                CustomerSubscriptionId = this.SubscriptionId,
                DeleteDate = this.DeleteDate,
                EffectiveDate = this.EffectiveDate,
                ExpiresDate = this.ExpiresDate,
                PublisherName = this.PublisherName,
                SeriesTitle = this.SeriesTitle
            };

            if (!this.SubscriptionAccess.SaveSubscription(subscriptionDl))
            {
                result.AddErrorMessage("Could not remove Subscription.");
            }
            return result;
        }

        public static Subscription GetNewSubscription(Guid customerId, Guid comicBookSeriesId, Guid userId)
        {
            Subscription sub = new Subscription()
            {
                ChangeDate = DateTime.UtcNow,
                ChangeUserId = userId,
                ComicBookSeriesId = comicBookSeriesId,
                CreateDate = DateTime.UtcNow,
                CreateUserId = userId,
                CustomerId = customerId,
                DeleteDate = null,
                EffectiveDate = DateTime.UtcNow,
                ExpiresDate = Base.Helper.GetDefaultExpiresDate(),
                HasData = true,
                PublisherName = string.Empty,
                SeriesTitle = string.Empty,
                SubscriptionId = Guid.NewGuid()
            };

            return sub;
        }
    }
}
