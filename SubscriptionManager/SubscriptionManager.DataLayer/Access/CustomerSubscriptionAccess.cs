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

        public bool AddSubscription(CustomerSubscription subscription)
        {
            bool addSuccessful = false;

            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spCustomerSubscriptionAddSubscription", param: subscription.GetParametersForAdd(), commandType: CommandType.StoredProcedure);

                addSuccessful = (rowsAffected == 1);
            }

            return addSuccessful;
        }

        public bool RemoveSubscription(CustomerSubscription subscription)
        {
            bool removeSuccessful = false;

            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spCustomerSubscriptionRemoveSubscription", param: subscription.GetParametersForRemove(), commandType: CommandType.StoredProcedure);

                removeSuccessful = (rowsAffected == 1);
            }

            return removeSuccessful;
        }
    }
}
