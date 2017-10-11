using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL.Interface
{
    public interface IAdminManager
    {
        bool CreateSchool(string schoolName, string schoolCode);
        School GetSchoolByCode(string schoolCode);

        bool CreateNewBank(Bank bank);
        Bank GetBankByName(string bankName);
        Bank GetBankByCode(string bankCode);
    }
}
