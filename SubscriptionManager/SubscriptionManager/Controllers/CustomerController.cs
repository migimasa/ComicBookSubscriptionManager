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

        [HttpGet]
        public ActionResult Home(string id)
        {
            Guid? customerId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (customerId.HasValue)
            {
                Customer customer = new Customer(customerId.Value);

                if (customer.HasData)
                {
                    Models.Customer.Customer customerViewModel = new Models.Customer.Customer(customer.StoreId, customer);
                    return View(customerViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpGet]
        public ActionResult Customers(string id)
        {
            Guid? storeId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (storeId.HasValue)
            {
                Customers customersLoader = new Domain.CustomerManagement.Customers();

                Models.Customer.Customers customersViewModel = new Models.Customer.Customers(storeId.Value, customersLoader.GetCustomersForStore(storeId.Value));
                return View(customersViewModel);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult ModifyCustomer(Guid storeId, string id)
        {
            Guid? customerId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            Customer customer = null;

            if (customerId.HasValue)
            {
                customer = new Customer(customerId.Value);
            }

            Models.Customer.Customer model = new Models.Customer.Customer(storeId, customer);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyCustomer(Models.Customer.Customer model)
        {
            if (ModelState.IsValid)
            {
                //save customer
                if (model.CustomerId.HasValue)
                {
                    //update
                    Customer customer = new Customer(model.CustomerId.Value);

                    if (customer.HasData)
                    {
                        customer.FirstName = model.FirstName;
                        customer.LastName = model.LastName;
                        customer.PhoneNumber = model.PhoneNumber;
                        customer.EmailAddress = model.EmailAddress;
                        customer.City = model.City;
                        customer.State = model.State;
                        customer.ZipCode = model.ZipCode;


                        var result = customer.SaveCustomer(new Guid("BC6B99B4-AC2A-4DD6-B183-73F52E26C44A"));

                        if (result.IsSuccess)
                        {
                            return RedirectToAction("Customers", new { id = model.StoreId });
                        }
                    }
                    else
                    {
                        return new HttpNotFoundResult();
                    }
                }
                else
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


                    if (result.IsSuccess)
                    {
                        return RedirectToAction("Customers", new { id = model.StoreId });
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Library(string id)
        {
            Guid? customerId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (customerId.HasValue)
            {
                Models.Customer.Library customerLibrary = new Models.Customer.Library(customerId.Value, DateTime.UtcNow);
                return View(customerLibrary);
            }
            return new HttpNotFoundResult();
        }

        [HttpGet]
        public ActionResult ManageLibrary(string id)
        {
            Guid? customerId = Migi.Framework.Helper.Types.GetNullableGuid(id);

            if (customerId.HasValue)
            {
                Models.Customer.ManageCustomerLibrary viewModel = new Models.Customer.ManageCustomerLibrary(customerId.Value);
                return View(viewModel);
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult _getManageLibraryData(Guid customerId, Guid? publisherId)
        {
            Models.Customer.ManageLibraryTableData tableData = new Models.Customer.ManageLibraryTableData(customerId, publisherId, DateTime.Today);

            return Json(new { data = tableData.Series });
        }

        [HttpPost]
        public ActionResult AddSubscription(Guid customerId, Guid comicBookSeriesId)
        {
            var customerLibrary = new Domain.CustomerManagement.Library(customerId, DateTime.UtcNow);

            var addResult = customerLibrary.AddSubscription(comicBookSeriesId, Guid.Empty);

            return Json(new { IsSuccess = addResult.IsSuccess, ErrorMessages = addResult.ErrorMessages });
        }

        [HttpPost]
        public ActionResult RemoveSubscription(Guid customerId, Guid subscriptionId)
        {
            var customerLibrary = new Domain.CustomerManagement.Library(customerId, DateTime.UtcNow);

            var removeResult = customerLibrary.RemoveSubscription(subscriptionId, Guid.Empty);

            return Json(new { IsSuccess = removeResult.IsSuccess, ErrorMessages = removeResult.ErrorMessages });
        }
    }
}