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
    public class CustomerComicBookAccess : BaseAccess, Abstract.ICustomerComicBookSeriesAccess
    {

        public List<CustomerComicBookSeries> LoadComicBookSeriesForCustomer(Guid customerId, DateTime searchDate)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<CustomerComicBookSeries>("", new { CustomerId = customerId, SearchDate = searchDate }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public CustomerComicBookSeries LoadCustomerComicBookSeries(Guid customerComicBookSeriesId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<CustomerComicBookSeries>("", new { CustomerComicBookSeriesId = customerComicBookSeriesId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool AddCustomerComicBookSeries(CustomerComicBookSeries customerSeries)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomerComicBookSeries(CustomerComicBookSeries customerSeries)
        {
            throw new NotImplementedException();
        }
    }
}
