using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubscriptionManager.Controllers
{
    public class SubscriptionController : Controller
    {
        // GET: Subscription
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerSubscriptions(string id)
        {
            Guid? customerId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (customerId.HasValue)
            {
                //get subscriptions for customer
            }

            return new HttpNotFoundResult();
        }

        public ActionResult AddSubscriptionToCustomer()
        {
            throw new NotImplementedException();    
        }

        public ActionResult RemoveSubscriptionFromCustomer()
        {
            throw new NotImplementedException();
        }
    }
}