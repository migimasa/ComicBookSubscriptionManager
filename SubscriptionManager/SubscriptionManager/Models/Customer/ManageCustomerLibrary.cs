using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Models.Customer
{
    public class ManageCustomerLibrary
    {
        public Guid CustomerId { get; private set; }
        [Display(Name = "Publisher:")]
        public List<SelectListItem> PublisherSelectList { get; private set; }

        public ManageCustomerLibrary(Guid customerId, List<Domain.ComicBookSeriesManagement.Publisher> publishers)
        {
            this.CustomerId = customerId;
            FillPublisherSelectList(publishers);
        }

        private void FillPublisherSelectList(List<Domain.ComicBookSeriesManagement.Publisher> publishers)
        {
            this.PublisherSelectList = new List<SelectListItem>();

            foreach (var publisher in publishers.OrderBy(x => x.PublisherName))
                this.PublisherSelectList.Add(new SelectListItem() { Selected = false, Text = publisher.PublisherName, Value = publisher.PublisherId.ToString() });
        }
    }
}