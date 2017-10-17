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

        BusinessMessage<bool> CreatePaymentItem(PaymentDetail pay);
        BusinessMessage<PaymentDetail> GetPaymentByCode(string paymentCode);
        BusinessMessage<PaymentDetail> GetPayment(string paymentDescription);
        BusinessMessage<List<PaymentDetail>> GetAllPayments();
        BusinessMessage<List<PaymentDetail>> GetAllPaymentsPerPeriod(int periodId);
        BusinessMessage<List<PaymentDetail>> GetAllSubPayments(int paymentId);
        BusinessMessage<PaymentDetail> GetAllPreReqPayments(int paymentId);


        BusinessMessage<bool> CreateNewPaymentSplit(SplitPayment pay);

        BusinessMessage<SplitPayment> GetPaymentSplitByCode(string Code);
        BusinessMessage<List<SplitPayment>> GetAllPaymentSplit(int payId);
        BusinessMessage<SplitPayment> GetPaymentSplit(string code);

        BusinessMessage<bool> CreateNewPaymentEngine(PaymentEngine payEngine);
        BusinessMessage<PaymentEngine> GetPaymentEngineByCode(string paymentCode);
        BusinessMessage<PaymentEngine> GetPaymentEngine(string description);
        BusinessMessage<List<PaymentEngine>> GetAllPaymentEngine();

    }
}
