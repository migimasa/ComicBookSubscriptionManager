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
            throw new NotImplementedException();
        }

        public ActionResult _getCurrentComicBookSeries(Guid? publisherId)
        {
            List<Models.ComicBookSeries.ComicBookSeries> comicBookSeriesViewModel = new List<Models.ComicBookSeries.ComicBookSeries>();

            var listOfSeries = Domain.ComicBookSeriesManagement.Series.GetComicBookSeries(publisherId, true);

            foreach (var series in listOfSeries)
            {
                comicBookSeriesViewModel.Add(new Models.ComicBookSeries.ComicBookSeries(series));
            }

            return Json(comicBookSeriesViewModel);
        }

        public ActionResult SeriesSearch()
        {
            return View();
        }
    }
}