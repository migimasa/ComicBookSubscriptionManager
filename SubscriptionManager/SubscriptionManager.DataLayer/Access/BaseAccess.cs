using System.Data.SqlClient;
using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.DataLayer.Access
{
    public class BaseAccess
    {
        private IAccess _access;

        public BaseAccess(IAccess access)
        {
            _access = access;
        }

        public string ConnectionString { get { return _access.ConnectionString; } }

        public SqlConnection GetOpenConnection() { return _access.GetOpenConnection(); }
    }
}
