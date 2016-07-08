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
    public class CustomerSubscriptionAccess : BaseAccess, Abstract.ICustomerSubscriptionAccess
    {
        public CustomerSubscriptionAccess(Abstract.IAccess access) : base(access) { }
        public List<CustomerSubscription> LoadSubscriptionsForCustomer(Guid customerId, DateTime searchDate)
        {
            List<CustomerSubscription> subscriptions = new List<CustomerSubscription>();
            using (SqlConnection connection = GetOpenConnection())
            {
                subscriptions = connection.Query<CustomerSubscription>("spCustomerSubscriptionGetCustomerSubscription", new { CustomerId = customerId, SearchDate = searchDate }, commandType: CommandType.StoredProcedure).ToList();
            }

            return subscriptions;
        }

        public CustomerSubscription LoadCustomerSubscription(Guid customerSubscriptionId)
        {
            CustomerSubscription subscription = null;

            using (SqlConnection connection = GetOpenConnection())
            {
                List<CustomerSubscription> customerSubscriptions = connection.Query<CustomerSubscription>("spCustomerSubscriptionGetCustomerSubscription", new { CustomerSubscriptionId = customerSubscriptionId }, commandType: CommandType.StoredProcedure).ToList();

                subscription = customerSubscriptions.FirstOrDefault();
            }

            return subscription;
        }

        public CustomerSubscription LoadCustomerSubscriptionByCustomerAndSeries(Guid customerId, Guid comicBookSeriesId, DateTime searchDate)
        {
            CustomerSubscription subscription = null;

            using (SqlConnection connection = GetOpenConnection())
            {
                subscription = connection.Query<CustomerSubscription>("spCustomerSubscriptionGetCustomerSubscription", new { CustomerId = customerId, ComicBookSeriesId = comicBookSeriesId, SearchDate = searchDate }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return subscription;
        }

        public bool SaveSubscription(CustomerSubscription subscription)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spCustomerSubscriptionSaveSubscription", param: subscription.GetParametersForSave(), commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}
