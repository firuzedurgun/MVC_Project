using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project.Models.Entity;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcStockEntities db = new MvcStockEntities();
        public ActionResult Index()
        {
            var degerler = db.ProductsTable.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> degerler = (from i in db.CategoriesTable.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CATEGORYNAME,
                                                 Value = i.CATEGORYID.ToString()
                                             }).ToList();
            ViewBag.deger = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(ProductsTable p1)
        {
            var category = db.CategoriesTable.Where(m => m.CATEGORYID == p1.CategoriesTable.CATEGORYID).FirstOrDefault();
            p1.CategoriesTable = category;
            db.ProductsTable.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var urun = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            var urun = db.ProductsTable.Find(id);
            List<SelectListItem> degerler = (from i in db.CategoriesTable.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CATEGORYNAME,
                                                 Value = i.CATEGORYID.ToString()
                                             }).ToList();
            ViewBag.degerler = degerler;
           
            return View("GetProduct",urun);
        }
        public ActionResult Update(ProductsTable p)
        {
            var product = db.ProductsTable.Find(p.PRODUCTID);
            product.PRODUCTNAME = p.PRODUCTNAME;
            product.PRODUCTID = p.PRODUCTID;
            product.BRAND = p.BRAND;
            product.STOCK = p.STOCK;
            product.PRICE= p.PRICE;
            var category = db.CategoriesTable.Where(m => m.CATEGORYID == p.CategoriesTable.CATEGORYID).FirstOrDefault();
            product.PROCATEGORY = category.CATEGORYID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}