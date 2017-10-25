using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class TransactionDTO
    {
        [DataMember]
        public string TransactionRef { get; set; }
        [DataMember]
        public string Amount { get; set; }
        [DataMember]
        public string TransactionAmount { get; set; }
        [DataMember]
        public string HashKey { get; set; }
        [DataMember]
        public string PaymentDescription { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public string OperationalURL { get; set; }
        [DataMember]
        public string PaymentId { get; set; }
        [DataMember]
        public string SiteRedirectUrl { get; set; }
        [DataMember]
        public string PaymentParameter { get; set; }
        [DataMember]
        public string XML { get; set; }
    }
}
