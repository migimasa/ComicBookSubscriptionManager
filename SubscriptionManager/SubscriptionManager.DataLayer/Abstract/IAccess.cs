using System.Data.SqlClient;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface IAccess
    {
        string ConnectionString { get; }
        SqlConnection GetOpenConnection();
    }
}
