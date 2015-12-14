using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace SubscriptionManager.DataLayer.DataTables
{
    public class ComicBookSeries : DataTableBase
    {
        public Guid ComicBookSeriesId { get; set; }
        public Guid PublisherId { get; set; }
        public string ComicBookSeriesTitle { get; set; }
        public bool IsActive { get; set; }


        public DynamicParameters GetParametersForCreate()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@SeriesId", this.ComicBookSeriesId, dbType: DbType.Guid);
            parameters.Add("@PublisherId", this.PublisherId, dbType: DbType.Guid);
            parameters.Add("@SeriesTitle", this.ComicBookSeriesTitle, dbType: DbType.String);
            parameters.Add("@IsActive", this.IsActive, dbType: DbType.Boolean);
            parameters.Add("@CreateDate", this.CreateDate, dbType: DbType.DateTime);
            parameters.Add("@UserId", this.CreateUserId, dbType: DbType.Guid);

            return parameters;
        }

        public DynamicParameters GetParametersForUpdate()
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@SeriesId", this.ComicBookSeriesId, dbType: DbType.Guid);
            parameters.Add("@SeriesTitle", this.PublisherId, dbType: DbType.String);
            parameters.Add("@IsActive", this.IsActive, dbType: DbType.Boolean);
            parameters.Add("@ChangeDate", this.ChangeDate, dbType: DbType.DateTime);
            parameters.Add("@UserId", this.CreateUserId, dbType: DbType.Guid);

            return parameters;
        }
    }
}
