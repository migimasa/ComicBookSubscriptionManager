using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface IDataTable
    {
        DateTime CreateDate { get; set; }
        Guid CreateUserId { get; set; }
        Guid ChangeUserId { get; set; }
        DateTime ChangeDate { get; set; }
        DateTime? DeleteDate { get; set; }
    }
}
