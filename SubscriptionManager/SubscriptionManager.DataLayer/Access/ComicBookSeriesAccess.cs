using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Migi.Framework.Sql;
using SubscriptionManager.DataLayer.DataTables;

using Dapper;

namespace SubscriptionManager.DataLayer.Access
{
    public class ComicBookSeriesAccess : BaseAccess, Abstract.ISeriesAccess
    {
        public List<ComicBookSeries> LoadAllSeries(bool? isActive)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<ComicBookSeries>("spComicBookSeriesGetComicBookSeries", new { IsActive = isActive }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public ComicBookSeries LoadSeriesById(Guid seriesId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<ComicBookSeries>("spComicBookSeriesGetComicBookSeries", new { SeriesId = seriesId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<ComicBookSeries> LoadSeriesForCustomerAndSearchDate(Guid customerId, DateTime searchDate)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<ComicBookSeries>("spComicBookSeriesGetComicBookSeriesForCustomer", new { CustomerId = customerId, SearchDate = searchDate }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<ComicBookSeries> LoadSeriesForPublisher(Guid publisherId, bool? isActive)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<ComicBookSeries>("spComicBookSeriesGetComicBookSeries", new { PublisherId = publisherId, IsActive = isActive }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public bool CreateSeries(ComicBookSeries series)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spComicBookSeriesCreateComicBookSeries", param: series.GetParametersForCreate(), commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
        public bool ModifySeries(ComicBookSeries series)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spComicBookSeriesUpdateComicBookSeries", param: series.GetParametersForUpdate(), commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
