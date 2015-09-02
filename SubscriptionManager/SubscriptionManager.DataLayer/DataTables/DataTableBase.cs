using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class DataTableBase : IDataTable
    {
        public DateTime CreateDate { get; set; }
        public Guid CreateUserId { get; set; }
        public Guid ChangeUserId { get; set; }
        public DateTime ChangeDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
