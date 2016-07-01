using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.DataTables;
using Migi.Framework.Helper;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Customers
    {
        //private ICustomerAccess _customerAccess;

        //public Customers(ICustomerAccess customerAccess)
        //{
        //    _customerAccess = customerAccess;
        //}

        //public List<ICustomer> GetCustomersForStore(Guid storeId)
        //{
        //    List<ICustomer> customers = new List<ICustomer>();

        //    foreach (var customerDl in _customerAccess.LoadCustomersForStore(storeId))
        //        customers.Add(new Customer(customerDl));

        //    return customers;
        //}
    }
}
