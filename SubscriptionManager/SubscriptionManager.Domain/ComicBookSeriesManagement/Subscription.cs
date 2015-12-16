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



        public static Migi.Framework.Models.ChangeResult AddSubscription()
        {
            throw new NotImplementedException();        
        }

        public Migi.Framework.Models.ChangeResult RemoveSubscription()
        {
            throw new NotImplementedException();
        }
    }
}
