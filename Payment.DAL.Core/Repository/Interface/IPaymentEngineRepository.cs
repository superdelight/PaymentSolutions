using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPaymentEngineRepository : IRepository<PaymentEngine>
    {

        PaymentEngine GetPaymentEngineByCode(string paymentCode);
        PaymentEngine GetPaymentEngine(string description);
        List<PaymentEngine> GetAllPaymentEngine();
      
    }
}
