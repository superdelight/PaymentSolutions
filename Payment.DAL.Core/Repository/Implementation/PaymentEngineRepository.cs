
using Payment.DAL.Core.Model;
using Payment.DAL.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Implementation
{
    public class PaymentEngineRepository : Repository<PaymentEngine>, IPaymentEngineRepository
    {
        private DbContext Context;
        public PaymentEngineRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public List<PaymentEngine> GetAllPaymentEngine()
        {
            return Context.Set<PaymentEngine>().ToList();
        }

        public PaymentEngine GetPaymentEngine(string description)
        {
            return Context.Set<PaymentEngine>().Where(c => c.PaymentDescription.ToLower().Trim() == 
            description.ToLower().Trim()).FirstOrDefault();
        }

        public PaymentEngine GetPaymentEngineByCode(string paymentCode)
        {
            return Context.Set<PaymentEngine>().Where(c => c.PaymentUpdateURL.ToLower().Trim() ==
          paymentCode.ToLower().Trim()).FirstOrDefault();
        }
    }
}