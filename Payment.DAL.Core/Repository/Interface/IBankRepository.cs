using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IBankRepository : IRepository<Bank>
    {
        bool ConfirmBank(string bankName, string bankCode);
        Bank GetBank(string bankName, string bankCode);
    }
}
