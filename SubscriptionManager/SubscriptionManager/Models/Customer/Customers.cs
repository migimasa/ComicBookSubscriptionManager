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

        public Customers(List<Domain.CustomerManagement.Customer> list)
        {
            
        }
    }
}