using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JL.VendingMachines.Models {
  public class Product {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Range(0, 999)]
    public decimal Price { get; set; }

    [StringLength(500)]
    [DataType(DataType.Url)]
    public string PictureUrl { get; set; }

    public bool IsFeatured { get; set; }

    public double WeightGrams { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }
  }
}