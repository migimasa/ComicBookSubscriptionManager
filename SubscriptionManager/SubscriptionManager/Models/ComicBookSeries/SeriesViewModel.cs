using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Models.ComicBookSeries
{
    public class SeriesViewModel
    {
        //private List<SelectListItem> _publisherSelectList;
        //[Display(Name = "Publisher:")]
        //public List<SelectListItem> PublisherSelectList
        //{
        //    get
        //    {
        //        if (_publisherSelectList == null)
        //        {
        //            FillPublisherSelectList();
        //        }
        //        return _publisherSelectList;
        //    }
        //}

        //public SeriesViewModel()
        //{

        //}

        //private void FillPublisherSelectList()
        //{
        //    Domain.ComicBookSeriesManagement.Publishers publishers = new Domain.ComicBookSeriesManagement.Publishers();

        //    this._publisherSelectList = new List<SelectListItem>();

        //    foreach (var publisher in publishers.OrderBy(x => x.PublisherName))
        //    {
        //        this._publisherSelectList.Add(new SelectListItem() { Selected = false, Text = publisher.PublisherName, Value = publisher.PublisherId.ToString() });
        //    }
        //}

    }
}