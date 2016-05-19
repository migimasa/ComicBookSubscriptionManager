using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.DataTables;
using Migi.Framework.Helper;


namespace SubscriptionManager.Domain.StoreManagement
{
    public interface IStores
    {
        List<IStore> ActiveStores { get; }

        IStore GetStore(Guid storeId);
    }


    public class Stores : IStores
    {
        private IStoreAccess _storeAccess;

        private List<IStore> _activeStores;
        public List<IStore> ActiveStores
        {
            get
            {
                if (_activeStores == null)
                    FillActiveStores();
                return _activeStores;
            }
        }

        public Stores(IStoreAccess storeAccess)
        {
            _storeAccess = storeAccess;
        }

        private void FillActiveStores()
        {
            _activeStores = new List<IStore>();

            foreach (var storeDl in _storeAccess.LoadAllStores())
                _activeStores.Add(new Store(storeDl));
        }

        public IStore GetStore(Guid storeId)
        {
            IStore store = ActiveStores.Where(x => x.StoreId == storeId).FirstOrDefault();

            return store;
        }
    }
}
