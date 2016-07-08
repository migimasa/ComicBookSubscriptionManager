using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubscriptionManager.DataLayer.DataTables;
using Migi.Framework.Sql;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface ICustomerSubscriptionAccess : IAccessLayerBase
    {
        List<CustomerSubscription> LoadSubscriptionsForCustomer(Guid customerId, DateTime searchDate);
        CustomerSubscription LoadCustomerSubscription(Guid customerSubscriptionId);
        CustomerSubscription LoadCustomerSubscriptionByCustomerAndSeries(Guid customerId, Guid comicBookSeriesId, DateTime searchDate);
        bool SaveSubscription(CustomerSubscription subscription);
    }
}
