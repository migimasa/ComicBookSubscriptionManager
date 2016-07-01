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

        public Customers(Guid storeId, List<Domain.CustomerManagement.Customer> customers)
        {
            this.StoreId = storeId;
            foreach (var cust in customers)
                this.Add(new Customer(cust));
        }
    }
}