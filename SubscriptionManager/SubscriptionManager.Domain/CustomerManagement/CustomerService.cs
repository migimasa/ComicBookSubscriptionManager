using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class CustomerService : ICustomer
    {
        private ICustomerAccess _customerAccess;
        private ICustomerSubscriptionAccess _subscriptionAccess;

        public CustomerService(ICustomerAccess customerAccess, ICustomerSubscriptionAccess subscriptionAccess)
        {
            _customerAccess = customerAccess;
            _subscriptionAccess = subscriptionAccess;
        }

        public List<Customer> GetCustomersForStore(Guid storeId)
        {
            List<Customer> customers = new List<Customer>();

            foreach (var customerDataLayer in _customerAccess.LoadCustomersForStore(storeId))
                customers.Add(new Customer(customerDataLayer));

            return customers;
        }

        public Customer GetCustomer(Guid customerId)
        {
            return new Customer(_customerAccess.LoadCustomer(customerId));
        }

        public Migi.Framework.Models.ChangeResult SaveCustomer(CustomerSave customerToSave)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (!_customerAccess.SaveCustomer(customerToSave.GetDataTable()))
                result.AddErrorMessage("Could not save customer.");

            return result;
        }



        public List<Subscription> GetCustomerLibrary(Guid customerId, DateTime searchDate)
        {
            List<Subscription> subscription = new List<Subscription>();

            foreach (var subscriptionDataLayer in _subscriptionAccess.LoadSubscriptionsForCustomer(customerId, searchDate))
                subscription.Add(new Subscription(subscriptionDataLayer));

            return subscription;
        }
    }
}
