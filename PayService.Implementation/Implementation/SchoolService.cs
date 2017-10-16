using PayService.Implementation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayService.DataContract;
using PaymentBLL.Interface;
using Payment.DAL.Core.Model;
using PayService.DataContract.MappingsExtension;

namespace PayService.Implementation.Implementation
{
    
    public class SchoolService : ISchoolService
    {

        IAdminManager adminLogic;
        public SchoolService(IAdminManager adminLogic)
        {
            this.adminLogic = adminLogic;
        }
       
        public ServiceResponse<bool> CreateSchool(string schoolName, string schCode)
        {
            var response = adminLogic.CreateSchool(schoolName, schCode);
            return GetMessage(response);
            
        }
        private  ServiceResponse<bool> GetMessage(PaymentBLL.Utility.BusinessMessage<bool> response)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            if (response.Result == true)
            {
                serviceResponse.Result = true;
                serviceResponse.Response = ResponseCode.OK;
                serviceResponse.Message = response.Message;
            }
            else
            {
                serviceResponse.Result = false;
                serviceResponse.Response = ResponseCode.ValidationError;
                serviceResponse.Message = response.Message;
            }
            return serviceResponse;
        }
        public ServiceResponse<List<SchoolDTO>> GetAllSchools()
        {
            ServiceResponse<List<SchoolDTO>> serviceResponse = new ServiceResponse<List<SchoolDTO>>();
            var response = adminLogic.GetAllSchools();
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }
        public ServiceResponse<SchoolDTO> GetSchoolByCode(string code)
        {
            ServiceResponse<SchoolDTO> serviceResponse = new ServiceResponse<SchoolDTO>();
            var response = adminLogic.GetSchoolByCode(code);
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }
    }
}
