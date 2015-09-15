using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migi.Framework.Sql;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface ICustomerSeriesAccess : IAccessLayerBase
    {
        List<CustomerSeries> LoadSeriesForCustomerAndSearchDate(Guid customerId, DateTime searchDate);
        List<CustomerSeries> LoadCustomersForSeries(Guid seriesId, DateTime searchDate);
        CustomerSeries LoadCustomerSeriesById(Guid customerSeriesId);
        bool AssignCustomerSeries(CustomerSeries series);
    }
}
