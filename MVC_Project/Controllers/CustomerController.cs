using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project.Models.Entity;

namespace MVC_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcStockEntities db = new MvcStockEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.CustomersTable select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler =degerler.Where(m=>m.CUSTOMERNAME.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(CustomersTable p1)
        {
            db.CustomersTable.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var customer = db.CustomersTable.Find(id);
            db.CustomersTable.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        {
            var cust = db.CustomersTable.Find(id);
            return View("GetCustomer",cust);
        }
        public ActionResult Update(CustomersTable p1)
        {
            var cst =db.CustomersTable.Find(p1.CUSTOMERID);
            cst.CUSTOMERNAME = p1.CUSTOMERNAME;
            cst.CUSTOMERSURNAME = p1.CUSTOMERSURNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}