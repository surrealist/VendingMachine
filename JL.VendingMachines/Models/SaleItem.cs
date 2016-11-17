using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JL.VendingMachines.Models {
  public class SaleItem {

    public int Id { get; set; }

    public DateTime Date { get; set; }

    [Required]
    public virtual Product Product { get; set; }

    [Required] 
    public virtual Slot Slot { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

  }
}