using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL.Utility
{
    public class BusinessMessage
    {
    }
    public class BusinessBaseResponse
    {
        public ResponseCode Response { get; set; }

        public string Message { get; set; }
    }
   public class BusinessMessage<T>: BusinessBaseResponse
    {
      public  T Result { get; set; }
    }
    public enum ResponseCode
    {
        OK = 0,
        ValidationError = 1,
        Error = 2,
        ServerException = 3
    }
}
