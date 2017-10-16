
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
    public class PaymentRepository : Repository<Payment.DAL.Core.Model.Payment>, IPaymentRepository
    {
        private DbContext Context;
        public PaymentRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public List<Model.Payment> GetAllPayments()
        {
            return Context.Set<Model.Payment>().ToList();
        }

        public List<Model.Payment> GetAllPaymentsPerPeriod(int periodId)
        {
            return Context.Set<Model.Payment>().Where(c=>c.PeriodId==periodId).ToList();
        }

        public Model.Payment GetAllPreReqPayments(int paymentId)
        {
            return Context.Set<Model.Payment>().Where(c => c.ReqId == paymentId).FirstOrDefault();
        }

        public List<Model.Payment> GetAllSubPayments(int paymentId)
        {
            return Context.Set<Model.Payment>().Where(c => c.Id == paymentId).ToList();
        }

        public Model.Payment GetPayment(string paymentDescription)
        {
            return Context.Set<Model.Payment>().Where(c => c.PaymentDescription.ToLower() == paymentDescription.ToLower()).FirstOrDefault();
        }
        public Model.Payment GetPaymentByCode(string paymentCode)
        {
            return Context.Set<Model.Payment>().Where(c => c.PaymentCode.ToLower() == paymentCode.ToLower()).FirstOrDefault();
        }

       
    }
}