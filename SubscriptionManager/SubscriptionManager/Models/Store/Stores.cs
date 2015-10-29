using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models.Store
{
    public class Stores : List<Store>
    {
        public Stores(List<Domain.StoreManagement.Store> stores)
        {
            foreach (var store in stores)
            {
                this.Add(new Store(store));
            }
        }
    }
}