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
            throw new NotImplementedException();
        }

        public ActionResult SeriesSearch()
        {
            throw new NotImplementedException();
        }
    }
}