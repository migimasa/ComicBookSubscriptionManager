using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.ComicBookSeriesManagement
{
    public class ComicBookSeriesService : IComicBookSeries
    {
        IPublisherAccess _publishers;
        ISeriesAccess _series;

        public ComicBookSeriesService(IPublisherAccess publishers, ISeriesAccess series)
        {
            _publishers = publishers;
            _series = series;
        }


        public List<Series> GetAllComicBookSeries(Guid? publisherId)
        {
            List<Series> comicBookSeries = new List<Series>();

            foreach (var seriesDl in GetComicBookSeriesDataLayers(publisherId))
                comicBookSeries.Add(new Series(seriesDl));

            return comicBookSeries;
        }

        private List<DataLayer.DataTables.ComicBookSeries> GetComicBookSeriesDataLayers(Guid? publisherId)
        {
            List<DataLayer.DataTables.ComicBookSeries> seriesDataLayers = new List<DataLayer.DataTables.ComicBookSeries>();

            if (publisherId.HasValue)
                seriesDataLayers = _series.LoadSeriesForPublisher(publisherId.Value, isActive:true);
            else
                seriesDataLayers = _series.LoadAllSeries(isActive:true);

            return seriesDataLayers;
        }

        public List<Publisher> GetAllPublishers()
        {
            List<Publisher> publishers = new List<Publisher>();

            foreach (var pubDl in _publishers.LoadPublishers())
                publishers.Add(new Publisher(pubDl));

            return publishers;
        }

        public Series GetComicBookSeries(Guid comicBookSeriesId)
        {
            return new Series(_series.LoadSeriesById(comicBookSeriesId));
        }

        public Publisher GetPublisher(Guid publisherId)
        {
            return new Publisher(_publishers.LoadPublisherById(publisherId));
        }
    }
}
