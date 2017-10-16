using PayService.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PayService.Implementation.Interface
{

    
    [ServiceContract]
   public interface ISchoolService
    {
        [OperationContract]
        ServiceResponse<bool> CreateSchool(string schoolName, string schCode);
        [OperationContract]
        ServiceResponse<List<SchoolDTO>> GetAllSchools();
        [OperationContract]
        ServiceResponse<SchoolDTO> GetSchoolByCode(string code);
    }
}
