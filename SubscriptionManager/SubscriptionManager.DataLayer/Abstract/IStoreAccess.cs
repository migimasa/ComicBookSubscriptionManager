using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface IStoreAccess
    {
        Store LoadStoreById(Guid storeId);
        List<Store> LoadAllStores();
        bool CreateStore(Store store);
        bool UpdateStore(Store store);
    }
}
