using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class CustomerSubscription : DataTableBase
    {
        public Guid CustomerSubscriptionId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ComicBookSeriesId { get; set; }

        public string PublisherName { get; set; }
        public string SeriesTitle { get; set; }

        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiresDate { get; set; }

        public DynamicParameters GetParametersForAdd()
        {
            throw new NotImplementedException();
        }

        public DynamicParameters GetParametersForRemove()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@CustomerSubscriptionId", this.CustomerSubscriptionId, dbType: DbType.Guid);
            parameters.Add("@ExpiresDate", this.ExpiresDate, dbType: DbType.DateTime);
            parameters.Add("@DeleteDate", this.DeleteDate, dbType: DbType.DateTime);
            parameters.Add("@UserId", this.ChangeUserId, dbType: DbType.Guid);
            parameters.Add("@ChangeDate", this.ChangeDate, dbType: DbType.DateTime);

            return parameters;
        }
    }
}
