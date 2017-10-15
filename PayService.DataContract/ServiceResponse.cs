using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    //[KnownType(typeof(BaseResponse))]
    //[DataContract]
    public class ServiceResponse<T>:BaseResponse
    {
        public T Result { get; set; }
        public bool Success { get; set; }
    }
}
