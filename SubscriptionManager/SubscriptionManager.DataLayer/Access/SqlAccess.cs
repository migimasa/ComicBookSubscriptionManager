using System.Configuration;
using System.Data.SqlClient;
using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.DataLayer.Access
{
    public class SqlAccess : IAccess
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SubscriptionManagerConnectionString"].ConnectionString;
            }
        }

        public SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);

            connection.Open();

            return connection;
        }
    }
}
