namespace JL.VendingMachines.Migrations {
  using Models;
  using System;
  using System.Collections.Generic;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<JL.VendingMachines.Data.MachineDb> {
    public Configuration() {
      AutomaticMigrationsEnabled = false;
      ContextKey = "JL.VendingMachines.Data.MachineDb";
    }

    protected override void Seed(Data.MachineDb context) {

      var p1 = new Product { Name = "Water", Price = 10m };
      var p2 = new Product { Name = "Pepsi", Price = 20m };
      var p3 = new Product { Name = "Coke", Price = 30m };
      var p4 = new Product { Name = "Singha", Price = 40m };
      var p5 = new Product { Name = "Redbull", Price = 50m };

      //context.Products.AddOrUpdate(
      //  p => p.Name,
      //  p1, p2, p3, p4, p5
      //);

      context.Machines.AddOrUpdate(
        m => m.Name,
        new Machine {
          Name = "M1",
          Slots = new HashSet<Slot> {
            new Slot {  Product = p1, Quantity=2 },
            new Slot {  Product = p2, Quantity=2 },
            new Slot {  Product = p2, Quantity=2 },
            new Slot {  Product = p3, Quantity=2 },
            new Slot {  Product = p4, Quantity=2 },
            new Slot {  Product = p5, Quantity=2 },
            new Slot {  Product = null  },
            new Slot {  Product = null  },
          }
        });
    }
  }
}
