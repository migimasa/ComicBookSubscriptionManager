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
        public Guid StoreId { get; private set; }
        public string StoreName { get; private set; }
        public string AddressOne { get; private set; }
        public string AddressTwo { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }

        private IStoreAccess StoreLoader;

        




        public void Save()
        {

        }
    }
}
