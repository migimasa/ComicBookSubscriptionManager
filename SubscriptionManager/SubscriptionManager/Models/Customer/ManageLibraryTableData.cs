using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubscriptionManager.Domain.ComicBookSeriesManagement;
using SubscriptionManager.Domain.Abstract;


namespace SubscriptionManager.Models.Customer
{
    public class ManageLibraryTableData
    {
        private readonly IComicBookSeries _seriesManagement;
        private readonly ICustomer _customerManagement;

        private Guid CustomerId { get; set; }
        private Guid? PublisherId { get; set; }
        private DateTime SearchDate { get; set; }

        public List<LibraryRow> Series { get; set; }

        private Dictionary<Guid, Series> AllSeriesDictionary { get; set; }
        private Dictionary<Guid, Domain.CustomerManagement.Subscription> CustomerSubscriptionsDictionary { get; set; }

        public ManageLibraryTableData(Guid customerId, Guid? publisherId, DateTime searchDate, ICustomer customerManagement, IComicBookSeries seriesManagement)
        {
            this.CustomerId = customerId;
            this.PublisherId = publisherId;
            this.SearchDate = searchDate;
            this.Series = new List<LibraryRow>();
            this._customerManagement = customerManagement;
            this._seriesManagement = seriesManagement;

            FillDictionaries();
            FillComicBookSeriesRows();
        }

        private void FillDictionaries()
        {
            FillAllSeriesDictionary();
            FillCustomerSubscriptionsDictionary();
        }

        private void FillAllSeriesDictionary()
        {
            AllSeriesDictionary = _seriesManagement.GetAllComicBookSeries(PublisherId).ToDictionary(x => x.ComicBookSeriesId);
            
        }

        private void FillCustomerSubscriptionsDictionary()
        {
            CustomerSubscriptionsDictionary = _customerManagement.GetCustomerLibrary(CustomerId,
                Migi.Framework.Helper.Search.GetUTCEndOfDaySearchDate(SearchDate)).ToDictionary(x => x.ComicBookSeriesId);
        }

        private void FillComicBookSeriesRows()
        {
            foreach (Domain.ComicBookSeriesManagement.Series series in AllSeriesDictionary.Values)
                this.Series.Add(new LibraryRow(series, GetCustomerSubscriptionId(series.ComicBookSeriesId)));
        }

        private Guid? GetCustomerSubscriptionId(Guid comicBookSeriesId)
        {
            Guid? subscriptionId = null;

            if (CustomerSubscriptionsDictionary.ContainsKey(comicBookSeriesId))
                subscriptionId = CustomerSubscriptionsDictionary[comicBookSeriesId].SubscriptionId;

            return subscriptionId;
        }


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