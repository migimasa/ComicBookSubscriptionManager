using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriptionManager.DataLayer.Abstract;
using DapperWrapper;

namespace SubscriptionManager.Domain.ComicBookSeriesManagement
{
    public class Series : Base.TransactionBase
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
        private ISeriesAccess SeriesLoader
        {
            get
            {
                if (_seriesLoader == null)
                {
                    _seriesLoader = new DataLayer.Access.ComicBookSeriesAccess();
                }
                return _seriesLoader;
            }
        }

        public Series(SubscriptionManager.DataLayer.DataTables.ComicBookSeries series)
        {
            this.FillProperties(series);
        }
        public Series(Guid comicBookSeriesId)
        {
            var series = SeriesLoader.LoadSeriesById(comicBookSeriesId);

            if (series != null)
            {
                this.FillProperties(series);
            }
        }

        private void FillProperties(SubscriptionManager.DataLayer.DataTables.ComicBookSeries series)
        {
            this.HasData = true;

            this.ComicBookSeriesId = series.ComicBookSeriesId;
            this.PublisherId = series.PublisherId;
            this.ComicBookSeriesTitle = series.ComicBookSeriesTitle;
            this.IsActive = series.IsActive;
            this.CreateDate = series.CreateDate;
            this.CreateUserId = series.CreateUserId;
            this.ChangeUserId = series.ChangeUserId;
            this.ChangeDate = series.ChangeDate;
            this.DeleteDate = series.DeleteDate;
        }

        public Migi.Framework.Models.ChangeResult SaveComicBookSeries(Guid changeUserId)
        {
            Migi.Framework.Models.ChangeResult result = new Migi.Framework.Models.ChangeResult();

            if (string.IsNullOrWhiteSpace(ComicBookSeriesTitle))
            {
                result.AddErrorMessage("Comic Book Series requires a title.");
            }

            if (result.IsSuccess)
            {
                using (ITransactionScope scope = this.TransactionScopeWrapper)
                {
                    DataLayer.DataTables.ComicBookSeries createSeriesDl = new DataLayer.DataTables.ComicBookSeries()
                    {
                        ChangeDate = DateTime.UtcNow,
                        ChangeUserId = changeUserId,
                        ComicBookSeriesId = this.ComicBookSeriesId,
                        ComicBookSeriesTitle = Migi.Framework.Helper.StringHelper.TrimStringReplaceNulls(this.ComicBookSeriesTitle),
                        CreateDate = this.CreateDate,
                        CreateUserId = this.CreateUserId,
                        DeleteDate = this.DeleteDate,
                        IsActive = this.IsActive,
                        PublisherId = this.PublisherId
                    };

                    if (!this.SeriesLoader.ModifySeries(createSeriesDl))
                    {
                        result.AddErrorMessage("Could not save series.");
                    }

                    scope.Complete();
                }
            }
            return result;
        }

        #region Create Series
        public class ComicBookSeriesCreate
        {
            public Guid PublisherId { get; set; }
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public Guid UserId { get; set; }

            public CreateComicBookSeriesResult ValidateSeries()
            {
                CreateComicBookSeriesResult result = new CreateComicBookSeriesResult();

                if (string.IsNullOrWhiteSpace(this.Title))
                {
                    result.AddErrorMessage("Comic Book Series must have a title");
                }

                return result;
            }
        }

        public class CreateComicBookSeriesResult : Migi.Framework.Models.ChangeResult
        {
            public Guid ComicBookSeriesId { get; set; }
        }

        public static CreateComicBookSeriesResult CreateNewComicBookSeries(ComicBookSeriesCreate seriesToCreate)
        {
            CreateComicBookSeriesResult result = seriesToCreate.ValidateSeries();

            if (result.IsSuccess)
            {
                ISeriesAccess seriesDl = new DataLayer.Access.ComicBookSeriesAccess();

                Guid newSeriesId = Guid.NewGuid();

                var createSeriesDataLayer = new DataLayer.DataTables.ComicBookSeries()
                {
                    ChangeDate = DateTime.UtcNow,
                    ChangeUserId = seriesToCreate.UserId,
                    ComicBookSeriesId = newSeriesId,
                    ComicBookSeriesTitle = seriesToCreate.Title,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = seriesToCreate.UserId,
                    DeleteDate = null,
                    IsActive = seriesToCreate.IsActive,
                    PublisherId = seriesToCreate.PublisherId
                };

                if (seriesDl.CreateSeries(createSeriesDataLayer))
                {
                    result.ComicBookSeriesId = newSeriesId;
                }
                else
                {
                    result.AddErrorMessage("Could not save Series.");
                }
            }
            return result;
        }
        #endregion

        public static List<Series> GetComicBookSeries(Guid? publisherId, bool? isActive)
        {
            List<Series> allSeries = new List<Series>();
            ISeriesAccess seriesLoader = new DataLayer.Access.ComicBookSeriesAccess();

            List<DataLayer.DataTables.ComicBookSeries> comicBookSeriesDls = new List<DataLayer.DataTables.ComicBookSeries>();

            if (publisherId.HasValue)
            {
                comicBookSeriesDls = seriesLoader.LoadSeriesForPublisher(publisherId.Value, isActive);
            }
            else
            {
                comicBookSeriesDls = seriesLoader.LoadAllSeries(isActive);
            }


            foreach (var series in comicBookSeriesDls)
            {
                allSeries.Add(new Series(series));
            }
            return allSeries;
        }
    }
}
