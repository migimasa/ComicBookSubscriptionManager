﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class Customer : DataTableBase
    {
        public Guid CustomerId { get; set; }
        public Guid StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
