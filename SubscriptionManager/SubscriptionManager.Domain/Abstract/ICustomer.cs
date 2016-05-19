using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Abstract
{
    public interface ICustomer
    {
        bool HasData { get; }
        Guid CustomerId { get; }
        Guid StoreId { get; }
        string FirstName { get; }
        string LastName { get; }
        string PhoneNumber { get; }
        string EmailAddress { get; }
        string City { get; }
        string State { get; }
        string ZipCode { get; }
        List<CustomerManagement.Subscription> Subscriptions { get; }

    }
}
