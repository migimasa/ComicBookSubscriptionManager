using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Abstract
{
    public interface ISubscription
    {
        bool HasData { get; }
        Guid SubscriptionId { get; }
        Guid CustomerId { get; }
        Guid ComicBookSeriesId { get; }
        string PublisherName { get; }
        string SeriesTitle { get; }
        DateTime EffectiveDate { get; }
        DateTime ExpiresDate { get; }

        Migi.Framework.Models.ChangeResult Remove(Guid changeUserId);

        Migi.Framework.Models.ChangeResult Save();
    }
}
