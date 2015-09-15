using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migi.Framework.Sql;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface IStoreUserAccess : IAccessLayerBase
    {
        List<StoreUser> LoadUsersForStore(Guid storeId);
        StoreUser LoadStoreUserByStoreUserId(Guid userId);
        bool CreateStoreUser(StoreUser storeUser);
        bool ModifyStoreUser(StoreUser storeUser);
    }
}
