using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPaymentRepository : IRepository<Payment.DAL.Core.Model.Payment>
    {

        Payment.DAL.Core.Model.Payment GetPaymentByCode(string paymentCode);
        Payment.DAL.Core.Model.Payment GetPayment(string paymentDescription);
        List<Payment.DAL.Core.Model.Payment> GetAllPayments();
        List<Payment.DAL.Core.Model.Payment> GetAllPaymentsPerPeriod(int periodId);
        List<Payment.DAL.Core.Model.Payment> GetAllSubPayments(int paymentId);
        Payment.DAL.Core.Model.Payment GetAllPreReqPayments(int paymentId);
    }
}
