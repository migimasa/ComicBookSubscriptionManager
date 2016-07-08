using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.DataTables;
using SubscriptionManager.Domain.Base;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class SubscriptionSave
    {
        public Guid? SubscriptionId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ComicBookSeriesId { get; set; }
        public Guid UserId { get; set; }


        internal CustomerSubscription GetSubscriptionDataLayer()
        {
            return new CustomerSubscription()
            {
                ChangeDate = DateTime.UtcNow,
                ChangeUserId = UserId,
                ComicBookSeriesId = ComicBookSeriesId,
                CreateDate = DateTime.UtcNow,
                CreateUserId = UserId,
                CustomerId = CustomerId,
                CustomerSubscriptionId = SubscriptionId.HasValue ? SubscriptionId.Value : Guid.NewGuid(),
                DeleteDate = null,
                EffectiveDate = DateTime.UtcNow,
                ExpiresDate = Helper.GetDefaultExpiresDate()
            };
        }
    }
}
