using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class StoreUser : DataTableBase
    {
        public Guid StoreUserId { get; set; }
        public Guid StoreId { get; set; }
        public Guid UserId { get; set; }
        public byte StoreRole { get; set; }
    }
}
