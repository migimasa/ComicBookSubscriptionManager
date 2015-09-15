using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migi.Framework.Sql;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface ICustomerAccess : IAccessLayerBase
    {
        List<Customer> LoadCustomersForStore(Guid storeId);
        Customer LoadCustomer(Guid customerId);
        bool CreateCustomer(Customer customer);
        bool ModifyCustomer(Customer customer);
    }
}
