using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class PaymentEngineDTO
    {
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string PaymentDescription { get; set; }
        [DataMember]
        public string MacKey { get; set; }
        [DataMember]
        public string PaymentId { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string PaymentCode { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string PaymentUpdateURL { get; set; }
        [DataMember]
        public string PaymentURL { get; set; }
        [DataMember]
        public Nullable<int> SchId { get; set; }
    }
}
