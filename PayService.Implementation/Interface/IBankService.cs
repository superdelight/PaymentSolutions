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
   public interface IBankService
    {
        [OperationContract]
        ServiceResponse<bool> CreateBank(string bankName, string bankCode, string bankId);
        [OperationContract]
        ServiceResponse<List<BankDTO>> GetAllBanks();
        [OperationContract]
        ServiceResponse<BankDTO> GetBankById(string bankId);
        [OperationContract]
        ServiceResponse<BankDTO> GetBankByCode(string code);
        [OperationContract]
        ServiceResponse<AccountDetailDTO> GetAccountDetail(string accountNo);
        [OperationContract]
        ServiceResponse<List<AccountDetailDTO>> GetAllAccountDetails();
        [OperationContract]
        ServiceResponse<bool> CreateAccountNo(string accountName, string accountNo, int bankId);
        [OperationContract]
        ServiceResponse<List<AccountDetailDTO>> GetAllAccountDetailByBank(int bankId);
    }
}
