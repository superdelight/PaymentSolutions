using Payment.DAL.Core.Model;
using PaymentBLL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL.Interface
{
    public interface IAdminManager
    {
        BusinessMessage<bool> CreateNewAccount(string AccountNo, string AccountNam, int bankId);
        BusinessMessage<AccountDetail> GetAccountDetail(string AccountNo);
        BusinessMessage<List<AccountDetail>> GetAllAccountDetail();
        BusinessMessage<List<AccountDetail>> GetAllAccountDetail(int bankId);
        BusinessMessage<bool> CreateNewBank(string bankName, string bankCode, string bankId);
        BusinessMessage<bool> CreateSchool(string schoolName, string schoolCode);
        BusinessMessage<School> GetSchoolByCode(string schoolCode);

        BusinessMessage<List<Bank>> GetAllBanks();
        BusinessMessage<Bank> GetBankByName(string bankName);
        BusinessMessage<Bank> GetBankByCode(string bankCode);
        BusinessMessage<Bank> GetBankById(string Id);
        BusinessMessage<List<School>> GetAllSchools();

    }
}
