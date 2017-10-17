using Payment.DAL.Core.Model;
using PayService.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PayService.Implementation.Interface
{

    
    [ServiceContract]
   public interface IPayService
    {
   
        [OperationContract]
        ServiceResponse<bool> CreatePaymentItem(PaymentDTO pay);
        [OperationContract]
        ServiceResponse<PaymentDTO> GetPaymentByCode(string paymentCode);
        [OperationContract]
        ServiceResponse<PaymentDTO> GetPayment(string paymentDescription);
        [OperationContract]
        ServiceResponse<List<PaymentDTO>> GetAllPayments();
        [OperationContract]
        ServiceResponse<List<PaymentDTO>> GetAllPaymentsPerPeriod(int periodId);
        [OperationContract]
        ServiceResponse<List<PaymentDTO>> GetAllSubPayments(int paymentId);
        [OperationContract]
        ServiceResponse<PaymentDTO> GetAllPreReqPayments(int paymentId);

        [OperationContract]
        ServiceResponse<bool> CreateNewPaymentSplit(SplitPaymentDTO pay);
        [OperationContract]
        ServiceResponse<SplitPaymentDTO> GetPaymentSplitByCode(string Code);
        [OperationContract]
        ServiceResponse<List<SplitPaymentDTO>> GetAllPaymentSplit(int payId);
        [OperationContract]
        ServiceResponse<SplitPaymentDTO> GetPaymentSplit(string code);

        [OperationContract]
        ServiceResponse<bool> CreateNewPaymentEngine(PaymentEngineDTO payEngine);
        [OperationContract]
        ServiceResponse<PaymentEngineDTO> GetPaymentEngineByCode(string paymentCode);
        [OperationContract]
        ServiceResponse<PaymentEngineDTO> GetPaymentEngine(string description);
        [OperationContract]
        ServiceResponse<List<PaymentEngineDTO>> GetAllPaymentEngine();

    }
}
