
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
    public class PaymentRepository : Repository<PaymentDetail>, IPaymentRepository
    {
        private DbContext Context;
        public PaymentRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public List<PaymentDetail> GetAllPayments()
        {
            return Context.Set<PaymentDetail>().ToList();
        }

        public List<PaymentDetail> GetAllPaymentsPerPeriod(int periodId)
        {
            return Context.Set<PaymentDetail>().Where(c=>c.PeriodId==periodId).ToList();
        }

        public PaymentDetail GetAllPreReqPayments(int paymentId)
        {
            return Context.Set<PaymentDetail>().Where(c => c.ReqId == paymentId).FirstOrDefault();
        }

        public List<PaymentDetail> GetAllSubPayments(int paymentId)
        {
            return Context.Set<PaymentDetail>().Where(c => c.Id == paymentId).ToList();
        }

        public PaymentDetail GetPayment(string paymentDescription)
        {
            return Context.Set<PaymentDetail>().Where(c => c.PaymentDescription.ToLower() == paymentDescription.ToLower()).FirstOrDefault();
        }
        public PaymentDetail GetPaymentByCode(string paymentCode)
        {
            return Context.Set<PaymentDetail>().Where(c => c.PaymentCode.ToLower() == paymentCode.ToLower()).FirstOrDefault();
        }

       
    }
}