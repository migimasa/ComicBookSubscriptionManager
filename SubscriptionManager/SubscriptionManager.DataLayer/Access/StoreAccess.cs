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
    public class StoreAccess : BaseAccess, Abstract.IStoreAccess
    {
        
        public Store LoadStoreById(Guid storeId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<Store>("spStoreGetStore", new { StoreId = storeId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<Store> LoadAllStores()
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<Store>("spStoreGetStore", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public bool CreateStore(Store store)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spStoreCreateStore", store);

                return rowsAffected > 0;
            }
        }
        public bool UpdateStore(Store store)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spStoreUpdateStore", store);

                return rowsAffected > 0;
            }
        }
    }
}
