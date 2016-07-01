using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.Domain.Abstract;

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

        public Store(DataLayer.DataTables.Store store)
        {
            FillProperties(store);
        }

        private void FillProperties(SubscriptionManager.DataLayer.DataTables.Store store)
        {
            HasData = true;

            if (store != null)
            {
                StoreId = store.StoreId;
                StoreName = store.StoreName;
                AddressOne = store.AddressOne;
                AddressTwo = store.AddressTwo;
                City = store.City;
                State = store.State;
                ZipCode = store.ZipCode;
                PhoneNumber = store.PhoneNumber;
                EmailAddress = store.EmailAddress;
            }
        }
    }
}
