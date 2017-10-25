
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
    public class PaymentSplitRepository : Repository<SplitPayment>, IPaymentSplitRepository
    {
        private DbContext Context;
        public PaymentSplitRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public SplitPayment GetPaymentSplit(string code)
        {
            return Context.Set<SplitPayment>().Where(c => c.Description.ToLower() == code.ToLower()).FirstOrDefault();
        }

        public List<SplitPayment> GetAllPaymentSplit(int payId)
        {
            return Context.Set<SplitPayment>().Where(c => c.PayId == payId).ToList();
        }

        public SplitPayment GetPaymentSplitByCode(string Code)
        {
            return Context.Set<SplitPayment>().Where(c => c.PaymentCode.ToLower() == Code.ToLower()).FirstOrDefault();
        }
    }
}