using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.Domain.CustomerManagement;

namespace SubscriptionManager.Domain.Abstract
{
    public interface ICustomer
    {
        List<Customer> GetCustomersForStore(Guid storeId);

        Customer GetCustomer(Guid customerId);

        Migi.Framework.Models.ChangeResult SaveCustomer(CustomerSave customerToSave);

        List<Subscription> GetCustomerLibrary(Guid customerId, DateTime searchDate);

        Migi.Framework.Models.ChangeResult AddCustomerSubscription(SubscriptionSave subscriptionToSave);

        Migi.Framework.Models.ChangeResult RemoveCustomerSubscription(Guid subscriptionId, Guid userId);
    }
}
