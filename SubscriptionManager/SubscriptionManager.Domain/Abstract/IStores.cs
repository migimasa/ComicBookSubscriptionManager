using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.Domain.StoreManagement;

namespace SubscriptionManager.Domain.Abstract
{
    public interface IStores
    {
        List<Store> ActiveStores { get; }

        Store GetStore(Guid storeId);
    }
}
