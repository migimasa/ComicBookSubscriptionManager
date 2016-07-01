using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using DapperWrapper;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Domain.ComicBookSeriesManagement
{
    public class Series
    {
        public bool HasData { get; set; }
        public Guid ComicBookSeriesId { get; set; }
        public Guid PublisherId { get; set; }
        public string ComicBookSeriesTitle { get; set; }
        public bool IsActive { get; set; }
        private DateTime CreateDate { get; set; }
        private Guid CreateUserId { get; set; }
        private Guid ChangeUserId { get; set; }
        private DateTime ChangeDate { get; set; }
        private DateTime? DeleteDate { get; set; }

        private ISeriesAccess _seriesLoader;

        public Series(ISeriesAccess seriesLoader)
        {
            _seriesLoader = seriesLoader;
        }

        private void FillProperties(SubscriptionManager.DataLayer.DataTables.ComicBookSeries series)
        {
            HasData = true;

            ComicBookSeriesId = series.ComicBookSeriesId;
            PublisherId = series.PublisherId;
            ComicBookSeriesTitle = series.ComicBookSeriesTitle;
            IsActive = series.IsActive;
            CreateDate = series.CreateDate;
            CreateUserId = series.CreateUserId;
            ChangeUserId = series.ChangeUserId;
            ChangeDate = series.ChangeDate;
            DeleteDate = series.DeleteDate;
        }
    }
}
