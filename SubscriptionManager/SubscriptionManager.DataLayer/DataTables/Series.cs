using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class Series
    {
        public Guid SeriesId { get; set; }
        public Guid PublisherId { get; set; }
        public string SeriesName { get; set; }
        public bool IsActive { get; set; }
    }
}
