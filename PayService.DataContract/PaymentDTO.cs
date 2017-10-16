using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class PaymentDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PaymentDescription { get; set; }
        [DataMember]
        public string PaymentCode { get; set; }
        [DataMember]
        public Nullable<float> TotalAmount { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DateCreated { get; set; }
        [DataMember]
        public Nullable<int> SchId { get; set; }
        [DataMember]
        public Nullable<int> PayEngineId { get; set; }
        [DataMember]
        public Nullable<int> ReqId { get; set; }
        [DataMember]
        public Nullable<long> PeriodId { get; set; }
        [DataMember]
        public Nullable<bool> IsActive { get; set; }

    }
}
