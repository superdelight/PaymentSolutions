using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class SplitPaymentDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string PaymentCode { get; set; }
        [DataMember]
        public Nullable<float> Amount { get; set; }
        [DataMember]
        public Nullable<int> PayId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateCreated { get; set; }
        [DataMember]
        public Nullable<int> AccId { get; set; }
    }
}
