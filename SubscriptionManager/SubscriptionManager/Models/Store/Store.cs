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
            FillProperties(store, new List<Domain.CustomerManagement.Customer>());
        }
        public Store(Domain.StoreManagement.Store store, List<Domain.CustomerManagement.Customer> customers)
        {
            FillProperties(store, customers);
        }

        private void FillProperties(Domain.StoreManagement.Store store, List<Domain.CustomerManagement.Customer> customers)
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

            this.Customers = new List<Customer.Customer>();

            FillCustomers(customers);
        }

        private void FillCustomers(List<Domain.CustomerManagement.Customer> customers)
        {
            foreach (var customer in customers)
                Customers.Add(new Customer.Customer(customer));
            //_customers = new List<Customer.Customer>();
            //foreach (var customer in store.Customers)
            //    _customers.Add(new Customer.Customer(customer.StoreId, customer));
        }
    }
}