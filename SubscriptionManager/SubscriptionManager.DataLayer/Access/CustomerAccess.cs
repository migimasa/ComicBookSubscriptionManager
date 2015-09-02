using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.DataTables;

using Dapper;

namespace SubscriptionManager.DataLayer.Access
{
    public class CustomerAccess : Abstract.ICustomerAccess
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SubscriptionManagerConnectionString"].ConnectionString;
            }
        }

        public System.Data.SqlClient.SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);

            connection.Open();

            return connection;
        }
        public List<Customer> LoadCustomersForStore(Guid storeId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<Customer>("spCustomerGetCustomer", new { StoreId = storeId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Customer LoadCustomer(Guid customerId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<Customer>("spCustomerGetCustomer", new { CustomerId = customerId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool CreateCustomer(Customer customer)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spCustomerInsertCustomer", customer);

                return rowsAffected > 0;
            }
        }

        public bool ModifyCustomer(Customer customer)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spCustomerUpdateCustomer", customer);

                return rowsAffected > 0;
            }
        }


    }
}
