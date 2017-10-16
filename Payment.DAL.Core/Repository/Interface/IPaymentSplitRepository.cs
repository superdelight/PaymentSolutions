using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPaymentSplitRepository : IRepository<SplitPayment>
    {
        SplitPayment GetPaymentSplitByCode(string Code);
        List<SplitPayment> GetAllPaymentSplit(int payId);
        SplitPayment GetPaymentSplit(string code);
    }
}
