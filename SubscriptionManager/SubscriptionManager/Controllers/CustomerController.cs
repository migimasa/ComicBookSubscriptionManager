using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubscriptionManager.Domain.CustomerManagement;

namespace SubscriptionManager.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("Customers");
        }

        public ActionResult Customers(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (storeId.HasValue)
            {
                Customers customersLoader = new Domain.CustomerManagement.Customers();

                Models.Customer.Customers customersViewModel = new Models.Customer.Customers(customersLoader.GetCustomersForStore(storeId.Value));
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        public ActionResult ModifyCustomer(string id)
        {
            Guid? customerId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            throw new NotImplementedException();
        }
    }
}