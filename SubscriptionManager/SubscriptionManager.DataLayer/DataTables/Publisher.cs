﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class Publisher : DataTableBase
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public bool IsActive { get; set; }
    }
}
