using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;

using DapperWrapper;
using System.Transactions;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Customer
    {
        public bool HasData { get; set; }
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        private DateTime CreateDate { get; set; }
        private Guid CreateUserId { get; set; }
        private Guid ChangeUserId { get; set; }
        private DateTime ChangeDate { get; set; }
        private DateTime? DeleteDate { get; set; }


        private DateTime SearchDate { get; set; }

        public Customer(SubscriptionManager.DataLayer.DataTables.Customer customer)
        {
            FillProperties(customer);
        }

        private void FillProperties(SubscriptionManager.DataLayer.DataTables.Customer customer)
        {
            HasData = true;

            if (customer != null)
            {
                CustomerId = customer.CustomerId;
                StoreId = customer.StoreId;
                FirstName = customer.FirstName;
                LastName = customer.LastName;
                PhoneNumber = customer.PhoneNumber;
                EmailAddress = customer.EmailAddress;
                City = customer.City;
                State = customer.State;
                ZipCode = customer.ZipCode;
                CreateDate = customer.CreateDate;
                CreateUserId = customer.CreateUserId;
                ChangeUserId = customer.ChangeUserId;
                ChangeDate = customer.ChangeDate;
                DeleteDate = customer.DeleteDate;
            }
        }
    }
}
