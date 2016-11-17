using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JL.VendingMachines.Common;


namespace JL.VendingMachines.Models {
  public class Machine {

    public Machine() {
      AcceptableCoinsText = "1, 5, 10";
      Slots = new HashSet<Slot>();
      SaleItems = new HashSet<SaleItem>();
      Amount = TotalAmount = 0m;
    }

    private decimal _amount = 0m;
    private decimal[] _acceptableCoins;
    private string _acceptableCoinsText;

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal TotalAmount { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; }
    public virtual ICollection<Slot> Slots { get; set; }

    /// <summary>
    /// ระบุเหรียญที่ตู้นี้รับได้ ในรูปแบบคั่นด้วยคอมม่า
    /// เช่น "1, 5, 10" หรือ "5,10"
    /// ถ้าข้อความไม่ถูกต้อง เช่น "5,10,X" จะเกิด error 
    /// โดยค่า AcceptableCoinsText จะไม่เปลี่ยนแปลงไปจากเดิม
    /// </summary>
    public string AcceptableCoinsText {
      get { return _acceptableCoinsText; }
      set {
        // TODO: convert string ---> decimal array
        string[] parts = value.Split(new char[] { ',', ' ' },
          StringSplitOptions.RemoveEmptyEntries);

        _acceptableCoins = new decimal[parts.Length];
        for (int i = 0; i < parts.Length; i++) {
          if (!decimal.TryParse(parts[i], out _acceptableCoins[i])) {
            _acceptableCoins = new decimal[0];
            throw new ArgumentException("Invalid data", nameof(value));
          }
        }
        _acceptableCoinsText = value;
      }
    }

    public decimal Amount {
      get {
        return _amount;
      }
      private set {
        _amount = value;
      }
    }

    public void AddCoin(decimal coinAmount) {
      if (!_acceptableCoins.Contains(coinAmount)) { // coinAmount == 1) {
        throw new CoinIsNotAcceptableException(coinAmount);
      }

      _amount += coinAmount;
    }

    public void RemoveCoins() {
      _amount = 0m;
    }

    public bool Sellable(int slotId) {
      var slot = Slots.SingleOrDefault(s => s.Id == slotId);

      return (slot != null
              && Amount >= slot.Product.Price
              && slot.Quantity > 0);
    }

    public decimal Sell(int slotId) {
      if (!Sellable(slotId)) throw new Exception();
      var slot = Slots.SingleOrDefault(x => x.Id == slotId);
      if (slot == null) throw new Exception();

      decimal returnAmount;
      slot.Quantity--;
      if (slot.Quantity == 0) {
        slot.Quantity = 5;
      }
      returnAmount = Amount - slot.Product.Price;
      TotalAmount += slot.Product.Price;
      Amount = 0m;

      AddSaleItem(slot);

      return returnAmount; 
    }

    private void AddSaleItem(Slot slot) {
      var item = new SaleItem();
      item.Date = DateTime.Now;
      item.Product = slot.Product;
      item.Slot = slot;
      item.ProductName = slot.Product.Name;
      item.Price = slot.Product.Price;
      item.Quantity = 1;
      SaleItems.Add(item);
    }
  }
}