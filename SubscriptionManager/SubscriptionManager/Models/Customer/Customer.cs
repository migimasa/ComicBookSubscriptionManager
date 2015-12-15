using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Models.Customer
{
    public class Customer
    {
        [HiddenInput(DisplayValue = false)]
        public Guid? CustomerId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Guid StoreId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage="A first name is required.")]
        [StringLength(500, MinimumLength=1, ErrorMessage="A first name must be less than 500 characters long.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage="A last name is required.")]
        [StringLength(500, ErrorMessage = "A last name must be less than 500 characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone #")]   
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "City")]
        [Required(AllowEmptyStrings=false, ErrorMessage = "A city is required.")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage="A state is required.")]
        public string State { get; set; }

        public string CityState
        {
            get
            {
                return string.Format("{0}, {1}", this.City, this.State);
            }
        }

        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")] 
        public string ZipCode { get; set; }

        public Customer() { }

        public Customer(Guid storeId, SubscriptionManager.Domain.CustomerManagement.Customer customer)
        {
            this.StoreId = storeId;
            if (customer != null && customer.HasData)
            {
                FillCustomerProperties(customer);
            }
            else
            {
                FillDefaultProperties();
            }
        }

        private void FillCustomerProperties(SubscriptionManager.Domain.CustomerManagement.Customer customer)
        {
            this.CustomerId = customer.CustomerId;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.PhoneNumber = customer.PhoneNumber;
            this.EmailAddress = customer.EmailAddress;
            this.City = customer.City;
            this.State = customer.State;
            this.ZipCode = customer.ZipCode;
        }

        private void FillDefaultProperties()
        {
            this.CustomerId = null;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.PhoneNumber = string.Empty;
            this.EmailAddress = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.ZipCode = string.Empty;
        }
        

    }
}