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
    
    public class BankService : IBankService
    {

        IAdminManager adminLogic;
        public BankService(IAdminManager adminLogic)
        {
            this.adminLogic = adminLogic;
        }
        public ServiceResponse<bool> CreateBank(string bankName, string bankCode,string bankId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
           var response= adminLogic.CreateNewBank(bankName, bankCode, bankId);
            if(response.Result==true)
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
        public ServiceResponse<BankDTO> GetBankByCode(string code)
        {
            ServiceResponse<BankDTO> serviceResponse = new ServiceResponse<BankDTO>();
            var response = adminLogic.GetBankByCode(code);
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }

        public ServiceResponse<BankDTO> GetBankById(string bankId)
        {
            ServiceResponse<BankDTO> serviceResponse = new ServiceResponse<BankDTO>();
            var response = adminLogic.GetBankById(bankId);
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }
        public ServiceResponse<List<BankDTO>> GetAllBanks()
        {
            ServiceResponse<List<BankDTO>> serviceResponse = new ServiceResponse<List<BankDTO>>();
            var response = adminLogic.GetAllBanks();
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }
    }
}
