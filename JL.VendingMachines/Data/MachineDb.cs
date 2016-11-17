using System.Data.Entity;
using JL.VendingMachines.Models;

namespace JL.VendingMachines.Data {
  public class MachineDb : DbContext {

    public DbSet<Machine> Machines { get; set; }
    public DbSet<Product> Products { get; set; }

  }
}