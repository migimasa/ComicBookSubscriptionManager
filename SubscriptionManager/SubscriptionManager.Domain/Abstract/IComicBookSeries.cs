using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.Domain.ComicBookSeriesManagement;

namespace SubscriptionManager.Domain.Abstract
{
    public interface IComicBookSeries
    {
        List<Publisher> GetAllPublishers();

        Publisher GetPublisher(Guid publisherId);

        Series GetComicBookSeries(Guid comicBookSeriesId);

        List<Series> GetAllComicBookSeries(Guid? publisherId);
    }
}
