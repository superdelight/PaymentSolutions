using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class TransactionEntryDTO
    {
        [DataMember]
        public string RefNo { get; set; }
        [DataMember]
        public string PayCode { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string OtherName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
    }
}
