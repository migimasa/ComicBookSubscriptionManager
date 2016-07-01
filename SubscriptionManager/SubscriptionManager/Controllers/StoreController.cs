using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubscriptionManager.Domain.StoreManagement;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.Domain.Abstract;

namespace SubscriptionManager.Controllers
{
    public class StoreController : Controller
    {
        private IStore _stores;
        private ICustomer _customers;

        public StoreController(IStore stores, ICustomer customers)
        {
            _stores = stores;
            _customers = customers;
        }

        // GET: Store
        public ActionResult Index()
        {
            return RedirectToAction("Stores");
        }

        public ActionResult Stores()
        {
            Models.Store.Stores storesViewModel = new Models.Store.Stores(_stores.GetAllStores());
            return View(storesViewModel);
        }

        public ActionResult Home(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (storeId.HasValue)
            {
                Models.Store.Store storeViewModel = new Models.Store.Store(_stores.GetStore(storeId.Value), _customers.GetCustomersForStore(storeId.Value));
                return View(storeViewModel);
            }
            return new HttpNotFoundResult();
        }
    }
}