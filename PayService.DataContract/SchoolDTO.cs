using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract
{
    [DataContract]
    public class SchoolDTO
    {
        [DataMember]
        public string SchoolName { get; set; }
        [DataMember]
        public string SchoolCode { get; set; }
     
    }
}
