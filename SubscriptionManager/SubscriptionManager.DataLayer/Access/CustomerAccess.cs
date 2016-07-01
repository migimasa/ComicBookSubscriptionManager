using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SubscriptionManager.DataLayer.DataTables;

using Dapper;

namespace SubscriptionManager.DataLayer.Access
{
    public class CustomerAccess : BaseAccess, Abstract.ICustomerAccess
    {
        public CustomerAccess(Abstract.IAccess access) : base(access) { }
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

        //public bool CreateCustomer(Customer customer)
        //{
        //    using (SqlConnection connection = GetOpenConnection())
        //    {
        //        int rowsAffected = connection.Execute("spCustomerCreateCustomer", param: customer.GetParametersForCreate(), commandType: CommandType.StoredProcedure);

        //        return rowsAffected > 0;
        //    }
        //}

        //public bool ModifyCustomer(Customer customer)
        //{
        //    using (SqlConnection connection = GetOpenConnection())
        //    {
        //        int rowsAffected = connection.Execute("spCustomerUpdateCustomer", param: customer.GetParametersForUpdate(), commandType: CommandType.StoredProcedure);

        //        return rowsAffected > 0;
        //    }
        //}
        public bool SaveCustomer(Customer customer)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsEffected = connection.Execute("spCustomerSaveCustomer", param: customer.GetParametersForCreate(), commandType: CommandType.StoredProcedure);

                return rowsEffected > 0;
            }
        }


    }
}
