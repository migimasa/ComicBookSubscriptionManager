using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models.Customer
{
    public class Customers : List<Customer>
    {
        public Customers()
        {

        }

        public Customers(Guid storeId, List<Domain.CustomerManagement.Customer> list)
        {
            foreach (var cust in list)
            {
                this.Add(new Customer(storeId, cust));
            }
        }
    }
}