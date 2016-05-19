using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SubscriptionManager.Domain.StoreManagement;

namespace SubscriptionManager.Models.Store
{
    public class ModifyStore
    {
        public Guid? StoreId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage="Store Name Required", AllowEmptyStrings=false)]
        public string StoreName { get; set; }
        [Display(Name = "Address One")]
        public string AddressOne { get; set; }
        [Display(Name = "Address Two")]
        public string AddressTwo { get; set; }
        [Display(Name = "City")]    
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }


        public ModifyStore(Domain.StoreManagement.IStore store)
        {
            if (store != null && store.HasData)
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
            }
            else
            {
                this.StoreId = null;
                this.StoreName = string.Empty;
                this.AddressOne = string.Empty;
                this.AddressTwo = string.Empty;
                this.City = string.Empty;
                this.State = string.Empty;
                this.ZipCode = string.Empty;
                this.PhoneNumber = string.Empty;
                this.EmailAddress = string.Empty;
            }
        }
    }
}