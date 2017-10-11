using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IAccountDetailRepository : IRepository<AccountDetail>
    {
        bool ConfirmAccountDetail(string accountNumber);
        AccountDetail GetAccountDetail(string accountNumber);
    }
}
