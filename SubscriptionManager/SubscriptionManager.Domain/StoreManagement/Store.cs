using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.Domain.StoreManagement
{
    public class Store
    {
        public bool HasData { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        private IStoreAccess _storeLoader;
        private IStoreAccess StoreLoader
        {
            get
            {
                if (_storeLoader == null)
                {
                    _storeLoader = new DataLayer.Access.StoreAccess();
                }
                return _storeLoader;
            }
        }

        public Store(SubscriptionManager.DataLayer.DataTables.Store store)
        {
            this.FillProperties(store);
        }
        public Store(Guid storeId)
        {
            var store = StoreLoader.LoadStoreById(storeId);

            if (store != null)
            {
                this.FillProperties(store);
            }
        }

        private void FillProperties(SubscriptionManager.DataLayer.DataTables.Store store)
        {
            this.HasData = true;
            this.StoreId = store.StoreId;
            this.StoreName = store.StoreName;
            this.AddressOne = store.AddressOne;
            this.AddressTwo = store.AddressTwo;
            this.City = store.City;
            this.State = store.State;
            this.ZipCode = store.ZipCode;
            this.PhoneNumber = store.PhoneNumber;
            this.EmailAddress = store.EmailAddress;
        }

        public Migi.Framework.Models.ChangeResult Save()
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            throw new NotImplementedException();

            //return result;
        }

        public class CreateStore
        {
            public string Name { get; set; }
            public string AddressOne { get; set; }
            public string AddressTwo { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; } 
        }

        public static Migi.Framework.Models.ChangeResult CreateNewStore(CreateStore storeToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
