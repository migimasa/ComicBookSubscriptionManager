using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class CustomerSeries : DataTableBase
    {
        public Guid CustomerSeriesId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SeriesId { get; set; }
    }
}
