using DItest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DItest.ViewModel;

namespace DItest.Controllers
{
    public class CustomerController : Controller
    {
        DItestContext context = new DItestContext();

        // GET: Customer
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entry(Customer modelCustomer)
        {
            Customer obj = new Customer();

            obj.CustomerName = modelCustomer.CustomerName;
            obj.CustomerAddress = modelCustomer.CustomerAddress;
            
            context.Customers.Add(obj);
            context.SaveChanges();

            return View();
        }
        public ActionResult List()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.Customers = context.Customers.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            var customer = context.Customers.Where(c => c.Id == Id).FirstOrDefault();

            context.Customers.Remove(customer);
            context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}