using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPaymentInvoiceRepository : IRepository<PaymentInvoice>
    {
        bool ConfirmInvoice(string refNo,string payCode);
        bool ConfirmInvoice(int refId, int payId);
        PaymentInvoice GetPaymentInvoice(string refNo, string payCode);
        IEnumerable<PaymentInvoice> GetAllPaymentInvoice(string payCode, bool? status);
        IEnumerable<PaymentInvoice> GetAllPaymentInvoiceByRef(string refNo, bool? status);
    }
}
