using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migi.Framework.Sql;
using SubscriptionManager.DataLayer.DataTables;

namespace SubscriptionManager.DataLayer.Abstract
{
    public interface ISeriesAccess : IAccessLayerBase
    {
        List<Series> LoadAllSeries();
        Series LoadSeriesById(Guid seriesId);
        bool CreateSeries(Series series);
        bool ModifySeries(Series series);
    }
}
