using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;

using DapperWrapper;

namespace SubscriptionManager.Domain.CustomerManagement
{
    public class Customer : Base.TransactionBase
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

        private ICustomerAccess _customerLoader;
        private ICustomerAccess CustomerLoader
        {
            get
            {
                if (_customerLoader == null)
                {
                    _customerLoader = new DataLayer.Access.CustomerAccess();
                }
                return _customerLoader;
            }
        }

        public Customer(SubscriptionManager.DataLayer.DataTables.Customer customer)
        {
            this.FillProperties(customer);
        }
        public Customer(Guid customerId)
        {
            var customer = CustomerLoader.LoadCustomer(customerId);

            if (customer != null)
            {
                this.FillProperties(customer);
            }
        }

        private void FillProperties(SubscriptionManager.DataLayer.DataTables.Customer customer)
        {
            this.HasData = true;
            this.CustomerId = customer.CustomerId;
            this.StoreId = customer.StoreId;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.PhoneNumber = customer.PhoneNumber;
            this.EmailAddress = customer.EmailAddress;
            this.City = customer.City;
            this.State = customer.State;
            this.ZipCode = customer.ZipCode;
            this.CreateDate = customer.CreateDate;
            this.CreateUserId = customer.CreateUserId;
            this.ChangeUserId = customer.ChangeUserId;
            this.ChangeDate = customer.ChangeDate;
            this.DeleteDate = customer.DeleteDate;
        }

        public Migi.Framework.Models.ChangeResult SaveCustomer(Guid changeUserId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (string.IsNullOrWhiteSpace(this.FirstName))
            {
                result.AddErrorMessage("Customer requires a first name.");
            }
            if (string.IsNullOrWhiteSpace(this.LastName))
            {
                result.AddErrorMessage("Customer requires a last name.");
            }
            if (string.IsNullOrWhiteSpace(this.PhoneNumber))
            {
                result.AddErrorMessage("Customer requires a phone number.");
            }
            if (string.IsNullOrWhiteSpace(this.City))
            {
                result.AddErrorMessage("Customer requires a city.");
            }

            if (result.IsSuccess)
            {
                using (ITransactionScope scope = this.TransactionScopeWrapper)
                {
                    DataLayer.DataTables.Customer createCustomerDl = new DataLayer.DataTables.Customer()
                    {
                        ChangeDate = DateTime.UtcNow,
                        ChangeUserId = changeUserId,
                        City = this.City,
                        CreateDate = this.CreateDate,
                        CreateUserId = this.CreateUserId,
                        CustomerId = this.CustomerId,
                        DeleteDate = this.DeleteDate,
                        EmailAddress = this.EmailAddress,
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        PhoneNumber = this.PhoneNumber,
                        State = this.State,
                        StoreId = this.StoreId,
                        ZipCode = this.ZipCode
                    };

                    if (!this.CustomerLoader.ModifyCustomer(createCustomerDl))
                    {
                        result.AddErrorMessage("Could not save Customer.");
                    }

                    scope.Complete();
                }
            }
            return result;
        }

        #region Create Customer
        public class CustomerCreate
        {
            public Guid StoreId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; }
            public Guid UserId { get; set; }

            public CreateCustomerResult ValidateCustomer()
            {
                CreateCustomerResult result = new CreateCustomerResult();

                if (string.IsNullOrWhiteSpace(this.FirstName))
                {
                    result.AddErrorMessage("Customer must have a first name.");
                }
                if (string.IsNullOrWhiteSpace(this.LastName))
                {
                    result.AddErrorMessage("Customer must have a last name.");
                }
                if (string.IsNullOrWhiteSpace(this.City))
                {
                    result.AddErrorMessage("Customer must have a city.");
                }
                if (string.IsNullOrWhiteSpace(this.PhoneNumber))
                {
                    result.AddErrorMessage("Customer must have a phone number.");
                }

                return result;
            }
        }

        public class CreateCustomerResult : Migi.Framework.Models.ChangeResult
        {
            public Guid? CustomerId { get; set; }
        }

        public static CreateCustomerResult CreateNewCustomer(CustomerCreate customerToCreate)
        {
            CreateCustomerResult result = customerToCreate.ValidateCustomer();

            if (result.IsSuccess)
            {
                using (ITransactionScope scope = new TransactionScopeWrapper(new System.Transactions.TransactionScope()))
                {
                    ICustomerAccess customerDl = new DataLayer.Access.CustomerAccess();

                    Guid newCustomerId = Guid.NewGuid();

                    var createCustomerDl = new DataLayer.DataTables.Customer()
                    {
                        ChangeDate = DateTime.UtcNow,
                        ChangeUserId = customerToCreate.UserId,
                        City = customerToCreate.City,
                        CreateDate = DateTime.UtcNow,
                        CreateUserId = customerToCreate.UserId,
                        CustomerId = newCustomerId,
                        DeleteDate = null,
                        EmailAddress = customerToCreate.EmailAddress,
                        FirstName = customerToCreate.FirstName,
                        LastName = customerToCreate.LastName,
                        PhoneNumber = customerToCreate.PhoneNumber,
                        State = customerToCreate.State,
                        StoreId = customerToCreate.StoreId,
                        ZipCode = customerToCreate.ZipCode
                    };

                    if (customerDl.CreateCustomer(createCustomerDl))
                    {
                        result.CustomerId = newCustomerId;
                    }
                    else
                    {
                        result.AddErrorMessage("Could not save Customer.");
                    }

                    scope.Complete();
                }
            }
            return result;
        }
        #endregion
    }
}
