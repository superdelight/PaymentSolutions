using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPaymentRepository : IRepository<PaymentDetail>
    {

        PaymentDetail GetPaymentByCode(string paymentCode);
        PaymentDetail GetPayment(string paymentDescription);
        List<PaymentDetail> GetAllPayments();
        List<PaymentDetail> GetAllPaymentsPerPeriod(int periodId);
        List<PaymentDetail> GetAllSubPayments(int paymentId);
        PaymentDetail GetAllPreReqPayments(int paymentId);
    }
}
