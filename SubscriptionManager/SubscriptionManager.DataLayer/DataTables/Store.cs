using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class Store : DataTableBase
    {
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public static Store AddNewStore()
        {
            Store newStore = new Store();
            newStore.StoreId = Guid.NewGuid();

            return newStore;
        }
    }
}
