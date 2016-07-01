using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.DataTables;

using Dapper;

namespace SubscriptionManager.DataLayer.Access
{
    public class PublisherAccess : BaseAccess, Abstract.IPublisherAccess
    {
        public PublisherAccess(Abstract.IAccess access) : base(access) { }
        public List<Publisher> LoadPublishers()
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<Publisher>("spPublisherGetPublisher").ToList();
            }
        }
        public Publisher LoadPublisherById(Guid publisherId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<Publisher>("spPublisherGetPublisher").FirstOrDefault();
            }
        }
        public bool CreatePublisher(Publisher publisher)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spPublisherInsertPublisher");

                return rowsAffected > 0;
            }
        }
        public bool ModifyPublisher(Publisher publisher)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                int rowsAffected = connection.Execute("spPublisherUpdatePublisher");

                return rowsAffected > 0;
            }
        }
    }
}
