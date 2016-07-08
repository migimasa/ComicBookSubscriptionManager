using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.DataTables;
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

        public Migi.Framework.Models.ChangeResult AddCustomerSubscription(SubscriptionSave subscriptionToSave)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (_subscriptionAccess.LoadCustomerSubscriptionByCustomerAndSeries(subscriptionToSave.CustomerId, subscriptionToSave.ComicBookSeriesId, DateTime.UtcNow) != null)
                result.AddErrorMessage("Customer is already subscribed to series");

            if (result.IsSuccess)
                _subscriptionAccess.SaveSubscription(subscriptionToSave.GetSubscriptionDataLayer());

            return result;
        }

        public Migi.Framework.Models.ChangeResult RemoveCustomerSubscription(Guid subscriptionId, Guid userId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            CustomerSubscription subscription = _subscriptionAccess.LoadCustomerSubscription(subscriptionId);

            if (subscription == null)
                result.AddErrorMessage("Could not load subscription");
            else if (subscription.IsExpiredSubscription)
                result.AddErrorMessage("Subscription is already removed");
            
            if (result.IsSuccess)
            {
                subscription.ExpiresDate = DateTime.UtcNow;
                subscription.DeleteDate = DateTime.UtcNow;
                subscription.ChangeDate = DateTime.UtcNow;
                subscription.ChangeUserId = userId;

                if (!_subscriptionAccess.SaveSubscription(subscription))
                    result.AddErrorMessage("Could not save subscription");
            }
            return result;
        }
    }
}
