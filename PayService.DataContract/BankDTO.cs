using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class BankDTO
    {
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string Acronyms { get; set; }
        [DataMember]
        public string BankId { get; set; }
    }
}
