using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Controllers
{
    public class ComicBookSeriesController : Controller
    {
        // GET: ComicBookSeries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Series()
        {
            Models.ComicBookSeries.SeriesViewModel viewModel = new Models.ComicBookSeries.SeriesViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult _getCurrentComicBookSeries(Guid? publisherId)
        {
            List<Models.ComicBookSeries.ComicBookSeries> comicBookSeriesViewModel = new List<Models.ComicBookSeries.ComicBookSeries>();

            var listOfSeries = Domain.ComicBookSeriesManagement.Series.GetComicBookSeries(publisherId, true);

            var publishers = new Domain.ComicBookSeriesManagement.Publishers().ToDictionary(x => x.PublisherId);

            foreach (var series in listOfSeries)
            {
                string publisherName = string.Empty;

                if (publishers.ContainsKey(series.PublisherId))
                {
                    publisherName = publishers[series.PublisherId].PublisherName;
                }

                comicBookSeriesViewModel.Add(new Models.ComicBookSeries.ComicBookSeries(series, publisherName));
            }

            return Json(new { data = comicBookSeriesViewModel });
        }

        public ActionResult SeriesSearch()
        {
            return View();
        }
    }
}