using Payment.DAL.Core.Model;
using PaymentBLL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL.Interface
{
    public interface IPaymentManagement
    {

        BusinessMessage<bool> CreatePaymentItem(Payment.DAL.Core.Model.Payment pay);
        BusinessMessage<Payment.DAL.Core.Model.Payment> GetPaymentByCode(string paymentCode);
        BusinessMessage<Payment.DAL.Core.Model.Payment> GetPayment(string paymentDescription);
        BusinessMessage<List<Payment.DAL.Core.Model.Payment>> GetAllPayments();
        BusinessMessage<List<Payment.DAL.Core.Model.Payment>> GetAllPaymentsPerPeriod(int periodId);
        BusinessMessage<List<Payment.DAL.Core.Model.Payment>> GetAllSubPayments(int paymentId);
        BusinessMessage<Payment.DAL.Core.Model.Payment> GetAllPreReqPayments(int paymentId);


        BusinessMessage<bool> CreateNewPaymentSplit(SplitPayment pay);

        BusinessMessage<SplitPayment> GetPaymentSplitByCode(string Code);
        BusinessMessage<List<SplitPayment>> GetAllPaymentSplit(int payId);
        BusinessMessage<SplitPayment> GetPaymentSplit(string code);

    

    }
}
