using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Project.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_Project.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcStockEntities db = new MvcStockEntities();   
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.CategoriesTable.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(CategoriesTable p1)
        {
            if(!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.CategoriesTable.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var ccategory = db.CategoriesTable.Find(id);
            db.CategoriesTable.Remove(ccategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var ctgr = db.CategoriesTable.Find(id);
            return View("GetCategory", ctgr);
        }
        public ActionResult Update(CategoriesTable p1)
        {
            var ctg = db.CategoriesTable.Find(p1.CATEGORYID);
            ctg.CATEGORYNAME = p1.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}