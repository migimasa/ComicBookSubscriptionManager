using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.ComicBookSeriesManagement
{
    public class Subscription
    {
        public bool HasData { get; private set; }
        public Guid CustomerComicBookSeriesId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ComicBookSeriesId { get; private set; }
        public DateTime EffectiveDate { get; private set; }
        public DateTime ExpiresDate { get; private set; }

        public Subscription(DataLayer.DataTables.CustomerComicBookSeries customerComicBookSeries)
        {
            if (customerComicBookSeries != null)
            {
                this.HasData = true;
                this.CustomerComicBookSeriesId = customerComicBookSeries.CustomerComicBookSeriesId;
                this.CustomerId = customerComicBookSeries.CustomerId;
                this.EffectiveDate = customerComicBookSeries.EffectiveDate;
                this.ExpiresDate = customerComicBookSeries.ExpiresDate;
            }
        }
    }

    public class Subscriptions : List<Subscription>
    {
        private Guid CustomerId { get; set; }
        private DateTime SearchDate { get; set; }

        private DataLayer.Abstract.ICustomerComicBookSeriesAccess _comicBookSeriesAccess;
        private DataLayer.Abstract.ICustomerComicBookSeriesAccess ComicBookSeriesAccess
        {
            get
            {
                if (this._comicBookSeriesAccess == null)
                {
                    this._comicBookSeriesAccess = new DataLayer.Access.CustomerComicBookAccess();
                }
                return _comicBookSeriesAccess;
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
            var customerComicBookSeries = this.ComicBookSeriesAccess.LoadComicBookSeriesForCustomer(this.CustomerId, this.SearchDate);

            foreach (var comicBookSeries in customerComicBookSeries)
            {
                this.Add(new Subscription(comicBookSeries));
            }
        }


        public Migi.Framework.Models.ChangeResult AddSubscription(Guid comicBookSeriesId, Guid userId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            DataLayer.DataTables.CustomerComicBookSeries temp = new DataLayer.DataTables.CustomerComicBookSeries()
            {
                ChangeDate = DateTime.Now,
                ChangeUserId = userId,
                ComicBookSeriesId = comicBookSeriesId,
                CreateDate = DateTime.Now,
                CreateUserId = userId,
                CustomerComicBookSeriesId = Guid.NewGuid(),
                CustomerId = this.CustomerId,
                DeleteDate = null,
                EffectiveDate = DateTime.Now,
                ExpiresDate = Base.Helper.GetDefaultExpiresDate()
            };



            throw new NotImplementedException();
        }

        public Migi.Framework.Models.ChangeResult RemoveSubscription(Guid comicBookSeriesId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
