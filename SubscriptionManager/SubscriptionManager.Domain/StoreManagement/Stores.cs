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
    public class Stores
    {
        private DataLayer.Abstract.IStoreAccess _storeAccess;

        public Stores()
        {
            this._storeAccess = new DataLayer.Access.StoreAccess();
        }

        public List<Store> GetActiveStores()
        {
            List<Store> stores = new List<Store>();

            List<DataLayer.DataTables.Store> loadedStores  = _storeAccess.LoadAllStores();

            foreach (var storeDl in loadedStores)
            {
                stores.Add(new Store(storeDl));
            }

            return stores;
        }

        public class AddStore
        {
            public string Name { get; set; }
            public string AddressOne { get; set; }
            public string AddressTwo { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; }
            public Guid UserId { get; set; }
        }

        public Migi.Framework.Models.ChangeResult CreateNewStore(AddStore store)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            DataLayer.DataTables.Store addStore = DataLayer.DataTables.Store.AddNewStore();
            addStore.AddressOne = StringHelper.TrimStringForSaving(store.AddressOne);
            addStore.AddressTwo = StringHelper.TrimStringForSaving(store.AddressTwo);
            addStore.ChangeDate = DateTime.UtcNow;
            addStore.ChangeUserId = store.UserId;
            addStore.City = StringHelper.TrimStringForSaving(store.City);
            addStore.CreateDate = DateTime.UtcNow;
            addStore.CreateUserId = store.UserId;
            addStore.DeleteDate = null;
            addStore.EmailAddress = StringHelper.TrimStringForSaving(store.EmailAddress);
            addStore.PhoneNumber = StringHelper.TrimStringForSaving(store.PhoneNumber);
            addStore.State = StringHelper.TrimStringForSaving(store.State);
            addStore.StoreName = StringHelper.TrimStringForSaving(store.Name);
            addStore.ZipCode = StringHelper.TrimStringForSaving(store.ZipCode);

            if (_storeAccess.CreateStore(addStore))
            {
                result.IsSuccess = true;
            }
            else
            {
                result.AddErrorMessage("Unable to Create Store");
            }

            return result;
        }
    }
}
