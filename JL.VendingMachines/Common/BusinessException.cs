using System; 

namespace JL.VendingMachines.Common {
  public class BusinessException
    : ApplicationException {

    public int ErrorNumber { get; }

    public BusinessException() : this(0) {
      //
    }

    public BusinessException(int errorNumber) {
      ErrorNumber = errorNumber;
    }
  }
}