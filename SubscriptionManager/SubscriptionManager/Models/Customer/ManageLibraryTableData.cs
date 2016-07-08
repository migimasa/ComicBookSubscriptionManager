using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubscriptionManager.Domain.ComicBookSeriesManagement;


namespace SubscriptionManager.Models.Customer
{
    public class ManageLibraryTableData
    {
        //private Guid CustomerId { get; set; }
        //private Guid? PublisherId { get; set; }
        //private DateTime SearchDate { get; set; }

        //public List<LibraryRow> Series { get; set; }

        //private Dictionary<Guid, Series> AllSeriesDictionary { get; set; }
        //private Dictionary<Guid, Domain.Abstract.ISubscription> CustomerSubscriptionsDictionary { get; set; }

        //public ManageLibraryTableData(Guid customerId, Guid? publisherId, DateTime searchDate)
        //{
        //    this.CustomerId = customerId;
        //    this.PublisherId = publisherId;
        //    this.SearchDate = searchDate;
        //    this.Series = new List<LibraryRow>();

        //    FillDictionaries();
        //    FillComicBookSeriesRows();
        //}

        //private void FillDictionaries()
        //{
        //    FillAllSeriesDictionary();
        //    FillCustomerSubscriptionsDictionary();
        //}

        //private void FillAllSeriesDictionary()
        //{
        //    AllSeriesDictionary = Domain.ComicBookSeriesManagement.Series.GetComicBookSeries(PublisherId, true).ToDictionary(x => x.ComicBookSeriesId);
        //}

        //private void FillCustomerSubscriptionsDictionary()
        //{
        //    Domain.CustomerManagement.Library customerLibrary = new Domain.CustomerManagement.Library(CustomerId, Migi.Framework.Helper.Search.GetUTCEndOfDaySearchDate(SearchDate));

        //    CustomerSubscriptionsDictionary = customerLibrary.Subscriptions.ToDictionary(x => x.ComicBookSeriesId);
        //}

        //private void FillComicBookSeriesRows()
        //{
        //    foreach (Domain.ComicBookSeriesManagement.Series series in AllSeriesDictionary.Values)
        //        this.Series.Add(new LibraryRow(series, GetCustomerSubscriptionId(series.ComicBookSeriesId)));
        //}

        //private Guid? GetCustomerSubscriptionId(Guid comicBookSeriesId)
        //{
        //    Guid? subscriptionId = null;

        //    if (CustomerSubscriptionsDictionary.ContainsKey(comicBookSeriesId))
        //        subscriptionId = CustomerSubscriptionsDictionary[comicBookSeriesId].SubscriptionId;

        //    return subscriptionId;
        //}


        public class LibraryRow
        {
            [JsonProperty(PropertyName = "comicBookSeriesId")]
            public Guid SeriesId { get; set; }
            [JsonProperty(PropertyName = "subscriptionId")]
            public Guid? SubscriptionId { get; set; }
            [JsonProperty(PropertyName = "seriesTitle")]
            public string SeriesTitle { get; set; }
            [JsonProperty(PropertyName = "isSubscribed")]
            public bool IsSubscribed { get { return this.SubscriptionId.HasValue; } }

            public LibraryRow(Domain.ComicBookSeriesManagement.Series series, Guid? subscriptionId)
            {
                this.SeriesId = series.ComicBookSeriesId;
                this.SubscriptionId = subscriptionId;
                this.SeriesTitle = series.ComicBookSeriesTitle;
            }
        }
    }
}