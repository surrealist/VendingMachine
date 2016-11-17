using JL.VendingMachines.Data;
using JL.VendingMachines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JL.VendingMachines.Controllers {
  public class ProductsController : Controller {

    private MachineDb db = new MachineDb();

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    public ActionResult Index() { 
      var products = db.Products.ToList();
      return View(products);
    }

    public ActionResult Create() {
      var p = new Product();
      return View(p);
    }

    [HttpPost]
    public ActionResult Create(Product item) {
      if (ModelState.IsValid) {

        db.Products.Add(item);
        db.SaveChanges(); 

        return RedirectToAction("Index");
      }

      return View(item);
    }
  }
}