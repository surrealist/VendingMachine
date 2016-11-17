using JL.VendingMachines.Data;
using JL.VendingMachines.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JL.VendingMachines.Controllers {
  public class HomeController : Controller {

    private MachineDb db = new MachineDb();

    public ActionResult Index() { 
      ViewBag.Count = db.Machines.Count();
      return View();
    }

    public async Task<ActionResult> About() {
      var m = new Machine();

      m.Name = "Machine " + DateTime.Now.Millisecond;
      m.AcceptableCoinsText = "1,5,10";

      db.Machines.Add(m);
      await db.SaveChangesAsync();

      TempData["NewId"] = m.Id;
      return RedirectToAction("Index");
    }

    public ActionResult Contact() {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}