using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return RedirectToAction("Stores");
        }

        public ActionResult Stores()
        {
            throw new NotImplementedException();
        }

        public ActionResult ModifyStore(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (storeId.HasValue)
            {
                //get store
            }

            //Create view model
            throw new NotImplementedException();
        }
    }
}