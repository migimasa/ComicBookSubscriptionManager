using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models.Customer
{
    public class Customers : List<Customer>
    {
        public Guid StoreId { get; private set; }

        public Customers()
        {

        }

        public Customers(Guid storeId, List<Domain.Abstract.ICustomer> list)
        {
            this.StoreId = storeId;
            foreach (var cust in list)
            {
                this.Add(new Customer(storeId, cust));
            }
        }
    }
}