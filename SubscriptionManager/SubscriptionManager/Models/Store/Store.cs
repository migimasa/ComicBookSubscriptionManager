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

        public List<Customer.Customer> Customers { get; set; }

        public Store(Domain.StoreManagement.Store store)
        {
            this.StoreId = store.StoreId;
            this.StoreName = store.StoreName;
            this.AddressOne = store.AddressOne;
            this.AddressTwo = store.AddressTwo;
            this.City = store.City;
            this.State = store.State;
            this.ZipCode = store.ZipCode;
            this.PhoneNumber = store.PhoneNumber;
            this.EmailAddress = store.EmailAddress;

            FillCustomers(store);
        }

        private void FillCustomers(Domain.StoreManagement.Store store)
        {
            this.Customers = new List<Customer.Customer>();
            foreach (var customer in store.Customers)
            {
                this.Customers.Add(new Customer.Customer(customer.StoreId, customer));
            }
        }
    }
}