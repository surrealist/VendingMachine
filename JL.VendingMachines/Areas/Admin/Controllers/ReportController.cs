using JL.VendingMachines.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JL.VendingMachines.Areas.Admin.Controllers {
  public class ReportController : Controller {
    
    private MachineDb db = new MachineDb();

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    public ActionResult Sales(int? ProductId) {
      var q = from item in db.SaleItems
              select item;
      if (ProductId != null) {
        q = q.Where(i => i.Product.Id == ProductId);
      }

      ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
      ViewBag.CurrentProductId = ProductId;
      return View(q.ToList());
    }
  }
}