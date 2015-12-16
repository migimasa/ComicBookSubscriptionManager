using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class CustomerComicBookSeries : DataTableBase
    {
        public Guid CustomerComicBookSeriesId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ComicBookSeriesId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiresDate { get; set; }

        public DynamicParameters GetParametersForAdd()
        {
            throw new NotImplementedException();
        }

        public DynamicParameters GetParametersForRemove()
        {
            throw new NotImplementedException();
        }
    }
}
