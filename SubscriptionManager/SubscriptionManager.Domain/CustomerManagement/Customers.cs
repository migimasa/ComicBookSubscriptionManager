using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.DataTables;
using Migi.Framework.Helper;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Customers
    {
        private DataLayer.Abstract.ICustomerAccess _customerAccess;

        public Customers()
        {
            this._customerAccess = new DataLayer.Access.CustomerAccess();
        }

        public List<Customer> GetCustomersForStore(Guid storeId)
        {
            List<Customer> customers = new List<Customer>();

            foreach (var customerDl in _customerAccess.LoadCustomersForStore(storeId))
            {
                customers.Add(new Customer(customerDl));
            }

            return customers;
        }
    }
}
