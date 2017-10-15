using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{

    //[DataContract]
    public class BaseResponse
    {
        [DataMember]
        public ResponseCode Response { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
    public enum ResponseCode
    {
        OK = 0,
        ValidationError = 1,
        NotFound = 2,
        ServerException = 3
    }
}