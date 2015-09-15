using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.DataTables;
using Migi.Framework.Sql;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface IPublisherAccess : IAccessLayerBase
    {
        List<Publisher> LoadPublishers();
        Publisher LoadPublisherById(Guid publisherId);
        bool CreatePublisher(Publisher publisher);
        bool ModifyPublisher(Publisher publisher);
    }
}
