using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubscriptionManager.Models.Store
{
    public class Store
    {
        public Guid StoreId { get; private set; }
        public string StoreName { get; private set; }
        public string AddressOne { get; private set; }
        public string AddressTwo { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }

        private List<Customer.Customer> _customers;
        public List<Customer.Customer> Customers { get
            {
                if (_customers == null)
                    FillCustomers(StoreInformation);
                return _customers;
            }
        }

        private Domain.StoreManagement.IStore StoreInformation { get; set; }

        public Store(Domain.StoreManagement.IStore store)
        {
            StoreId = store.StoreId;
            StoreName = store.StoreName;
            AddressOne = store.AddressOne;
            AddressTwo = store.AddressTwo;
            City = store.City;
            State = store.State;
            ZipCode = store.ZipCode;
            PhoneNumber = store.PhoneNumber;
            EmailAddress = store.EmailAddress;

            StoreInformation = store;
        }

        private void FillCustomers(Domain.StoreManagement.IStore store)
        {
            _customers = new List<Customer.Customer>();
            foreach (var customer in store.Customers)
                _customers.Add(new Customer.Customer(customer.StoreId, customer));
        }
    }
}