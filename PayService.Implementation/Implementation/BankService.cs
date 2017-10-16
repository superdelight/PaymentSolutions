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
                serviceResponse.Success = true;
                serviceResponse.Response = ResponseCode.OK;
                serviceResponse.Message = response.Message;
            }
            else
            { 
                serviceResponse.Result = false;
                serviceResponse.Success = false;
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
            serviceResponse.Success = true;
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
            serviceResponse.Success = true;
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }

        public ServiceResponse<AccountDetailDTO> GetAccountDetail(string accountNo)
        {
            ServiceResponse<AccountDetailDTO> serviceResponse = new ServiceResponse<AccountDetailDTO>();
            var response = adminLogic.GetAccountDetail(accountNo);
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }

        public ServiceResponse<List<AccountDetailDTO>> GetAllAccountDetails()
        {
            ServiceResponse<List<AccountDetailDTO>> serviceResponse = new ServiceResponse<List<AccountDetailDTO>>();
            var response = adminLogic.GetAllAccountDetail();
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }

        public ServiceResponse<bool> CreateAccountNo(string accountName, string accountNo, int bankId)
        {

            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            var response = adminLogic.CreateNewAccount(accountNo, accountName, bankId);
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

        public ServiceResponse<List<AccountDetailDTO>> GetAllAccountDetailByBank(int bankId)
        {
            ServiceResponse<List<AccountDetailDTO>> serviceResponse = new ServiceResponse<List<AccountDetailDTO>>();
            var response = adminLogic.GetAllAccountDetail(bankId);
            serviceResponse.Result = response.Result.ToDTO();
            serviceResponse.Message = response.Message;
            return serviceResponse;
        }
    }
}
