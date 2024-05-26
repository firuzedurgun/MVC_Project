using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project.Models.Entity;

namespace MVC_Project.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        MvcStockEntities db = new MvcStockEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesTable p)
        {
            db.SalesTable.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}