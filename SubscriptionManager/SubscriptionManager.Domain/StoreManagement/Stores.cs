using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.DataTables;
using Migi.Framework.Helper;
using SubscriptionManager.Domain.Abstract;


namespace SubscriptionManager.Domain.StoreManagement
{
    public class Stores
    {
        //private IStoreAccess _storeAccess;

        //private List<Store> _activeStores;
        //public List<Store> ActiveStores
        //{
        //    get
        //    {
        //        if (_activeStores == null)
        //            FillActiveStores();
        //        return _activeStores;
        //    }
        //}

        //public Stores(IStoreAccess storeAccess)
        //{
        //    _storeAccess = storeAccess;
        //}

        //private void FillActiveStores()
        //{
        //    _activeStores = new List<Store>();

        //    foreach (var storeDl in _storeAccess.LoadAllStores())
        //        _activeStores.Add(new Store(storeDl));
        //}

        //public Store GetStore(Guid storeId)
        //{
        //    Store store = ActiveStores.Where(x => x.StoreId == storeId).FirstOrDefault();

        //    return store;
        //}
    }
}
