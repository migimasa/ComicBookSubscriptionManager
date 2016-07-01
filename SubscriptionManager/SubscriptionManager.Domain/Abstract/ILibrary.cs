using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migi.Framework.Models;

namespace SubscriptionManager.Domain.Abstract
{
    public interface ILibrary
    {
        List<ISubscription> Subscriptions { get; }

        ChangeResult AddSubscription(Guid comicBookSeriesId, Guid userId);
        ISubscription GetSubscription(Guid subscriptionId);
        ChangeResult RemoveSubscription(Guid subscriptionId, Guid userId);
    }
}
