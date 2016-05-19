using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubscriptionManager.Domain.StoreManagement;
using SubscriptionManager.DataLayer.Abstract;

namespace SubscriptionManager.Controllers
{
    public class StoreController : Controller
    {
        private IStores _stores;

        public StoreController(IStores stores)
        {
            _stores = stores;
        }

        // GET: Store
        public ActionResult Index()
        {
            return RedirectToAction("Stores");
        }

        public ActionResult Stores()
        {
            Models.Store.Stores storesViewModel = new Models.Store.Stores(_stores.ActiveStores);
            return View(storesViewModel);
        }

        public ActionResult Home(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (storeId.HasValue)
            {
                IStore store = _stores.GetStore(storeId.Value);

                Models.Store.Store storeViewModel = new Models.Store.Store(store);
                return View(storeViewModel);
            }
            return new HttpNotFoundResult();
        }

        //[HttpGet]
        //public ActionResult ModifyStore(string id)
        //{
        //    Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

        //    IStore store = null;

        //    if (storeId.HasValue)
        //    {
        //        store = _stores.GetStore(storeId.Value);
        //    }

        //    Models.Store.ModifyStore model = new Models.Store.ModifyStore(store);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult ModifyStore(Models.Store.ModifyStore storeModify)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    throw new NotImplementedException();
        //}
    }
}