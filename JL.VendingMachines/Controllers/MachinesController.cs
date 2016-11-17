using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using JL.VendingMachines.Models;
using JL.VendingMachines.Data;

namespace JL.VendingMachines.Controllers {
  public class MachinesController : Controller {

    private MachineDb db = new MachineDb();

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    public ActionResult Index(int id = 1) {
      ViewBag.MachineId = new SelectList(db.Machines, "Id", "Name", id);

      var m = db.Machines.Find(id); // _machines.SingleOrDefault(x => x.Id == id);
      if (m == null) {
        //return HttpNotFound();
        m = db.Machines.FirstOrDefault();
      }
      return View(m);
    }

    [HttpPost]
    public ActionResult InsertCoin(int id, decimal amt) {
      try {
        var m = db.Machines.Find(id);
        m.AddCoin(amt);
        db.SaveChanges();
      }
      catch (Exception ex) {
        TempData["Error"] = ex.Message;
      }
      return RedirectToAction("Index", new { id = id });
    }

    [HttpPost]
    public ActionResult RemoveCoins(int id) {
      var m = db.Machines.Find(id);
      m.RemoveCoins();
      db.SaveChanges();
      return RedirectToAction("Index", new { id = id });
    }

    public ActionResult Create() {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine item) {
      if (ModelState.IsValid) {
        db.Machines.Add(item);
        db.SaveChanges();

        return RedirectToAction("Index", new { id = item.Id });
      }
      return View(item);
    }


    public ActionResult Init(int id) {


      return View();
    }
  }
}