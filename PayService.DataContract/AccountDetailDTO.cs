using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class AccountDetailDTO
    {
        [DataMember]
        public string AccountCode { get; set; }
        [DataMember]
        public string AccountName { get; set; }
     
    }
}
