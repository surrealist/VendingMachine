using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JL.VendingMachines.Common {
  public class CoinIsNotAcceptableException 
    : BusinessException {

    public decimal CoinAmount { get; }

    public CoinIsNotAcceptableException(decimal coinAmount)
      : base(errorNumber: 4001) {
      CoinAmount = coinAmount;
    }

    public override string Message {
      get {
        return $"ตู้นี้ไม่รับเหรียญ {CoinAmount} บาท";
      }
    }

  }
}