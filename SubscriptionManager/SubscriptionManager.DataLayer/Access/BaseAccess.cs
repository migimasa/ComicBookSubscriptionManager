using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.Access
{
    public class BaseAccess
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
    }
}
