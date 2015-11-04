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

        [HttpGet]
        public ActionResult ModifyCustomer(Guid storeId, Guid? customerId)
        {
            Customer customer = null;

            if (customerId.HasValue)
            {
                customer = new Customer(customerId.Value);
            }

            Models.Customer.Customer model = new Models.Customer.Customer(storeId, customer);
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifyCustomer(Models.Customer.Customer model)
        {
            if (ModelState.IsValid)
            {
                //save customer
                if (model.CustomerId.HasValue)
                {
                    //create new
                    Customers customers = new Customers();

                    var result = Customer.CreateNewCustomer(new Customer.CustomerCreate()
                    {
                        City = model.City,
                        EmailAddress = model.EmailAddress,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        State = model.State,
                        StoreId = model.StoreId,
                        ZipCode = model.ZipCode,
                        UserId = new Guid("BC6B99B4-AC2A-4DD6-B183-73F52E26C44A")
                    });
                }
                else
                {
                    //update
                }
            }
            return View(model);
        }
    }
}