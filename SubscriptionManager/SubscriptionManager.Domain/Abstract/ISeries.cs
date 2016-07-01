using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SubscriptionManager.Domain.ComicBookSeriesManagement.Series;

namespace SubscriptionManager.Domain.Abstract
{
    public interface ISeries
    {
        bool HasData { get; }
        Guid ComicBookSeriesId { get; }
        Guid PublisherId { get; }
        string ComicBookSeriesTitle { get; }
        bool IsActive { get; }
        Migi.Framework.Models.ChangeResult SaveComicBookSeries(Guid changeUserId);
        List<ISeries> GetAllComicBookSeries(Guid? publisherId, bool? isActive);
        ISeries GetSeriesForDataLayer(DataLayer.DataTables.ComicBookSeries series);
    }
}
