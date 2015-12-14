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
        List<ComicBookSeries> LoadAllSeries(bool? isActive);
        ComicBookSeries LoadSeriesById(Guid seriesId);
        List<ComicBookSeries> LoadSeriesForCustomerAndSearchDate(Guid customerId, DateTime searchDate);
        bool CreateSeries(ComicBookSeries series);
        bool ModifySeries(ComicBookSeries series);
    }
}
