using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.StoreManagement
{
    public class StoreService : IStore
    {
        private IStoreAccess _storeAccess;

        public StoreService(IStoreAccess storeAccess)
        {
            this._storeAccess = storeAccess;
        }

        public List<Store> GetAllStores()
        {
            List<Store> activeStores = new List<Store>();

            foreach (var storeDataLayer in _storeAccess.LoadAllStores())
                activeStores.Add(new Store(storeDataLayer));

            return activeStores;
        }

        public Store GetStore(Guid storeId)
        {
            return new Store(_storeAccess.LoadStoreById(storeId));
        }
    }
}
