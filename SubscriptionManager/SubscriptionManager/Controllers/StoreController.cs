using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubscriptionManager.Domain.StoreManagement;

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
            Stores storesLoader = new Stores();

            Models.Store.Stores storesViewModel = new Models.Store.Stores(storesLoader.GetActiveStores());
            return View(storesViewModel);
        }

        public ActionResult Home(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (storeId.HasValue)
            {
                Store store = new Store(storeId.Value);
                return View(new Models.Store.Store(store));
            }
            return new HttpNotFoundResult();
        }

        [HttpGet]
        public ActionResult ModifyStore(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            Store store = null;

            if (storeId.HasValue)
            {
                store = new Store(storeId.Value);
            }

            Models.Store.ModifyStore model = new Models.Store.ModifyStore(store);
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifyStore(Models.Store.ModifyStore storeModify)
        {
            if (ModelState.IsValid)
            {

            }
            throw new NotImplementedException();
        }
    }
}