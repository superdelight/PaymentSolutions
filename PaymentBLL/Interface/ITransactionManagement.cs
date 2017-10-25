using Payment.DAL.Core.Model;
using PaymentBLL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL.Interface
{
    public interface ITransactionManagement
    {

        BusinessMessage<bool> LogNewTransaction(TransactionLog transLog);
        BusinessMessage<bool> UpdateTransaction(TransactionLog transLog);
        BusinessMessage<TransactionLog> GetTransaction(string transLog);
        BusinessMessage<bool> CreatePayer(Payer pay);
        BusinessMessage<Payer> GetPayer(string refNo);
        BusinessMessage<bool> CreateInvoice(PaymentInvoice invoice);
        BusinessMessage<bool> UpdateInvoice(PaymentInvoice invoice);
        BusinessMessage<PaymentInvoice> GetPaymentInvoice(string payCode,string refNo);
        
    }
}
