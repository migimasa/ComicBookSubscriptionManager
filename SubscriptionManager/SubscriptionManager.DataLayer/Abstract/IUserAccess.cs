using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migi.Framework.Sql;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface IUserAccess : IAccessLayerBase
    {
        List<User> LoadAllUsers();
        User LoadUserById(Guid userId);
        bool CreateUser(User user);
        bool ModifyUser(User user);
    }
}
