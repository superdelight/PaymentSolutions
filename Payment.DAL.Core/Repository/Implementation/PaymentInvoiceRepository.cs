
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
    public class PaymentInvoiceRepository : Repository<PaymentInvoice>, IPaymentInvoiceRepository
    {
        private DbContext Context;
        public PaymentInvoiceRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public bool ConfirmInvoice(string refNo, string payCode)
        {
            return Context.Set<PaymentInvoice>().Where(c => c.Payer.RefNo.ToLower().Trim() ==refNo.ToLower().Trim() && 
            c.Payment.PaymentCode.ToLower().Trim() == payCode.ToLower().Trim()).Any();
        }
        public bool ConfirmInvoice(int refId, int payId)
        {
            return Context.Set<PaymentInvoice>().Where(c => c.PayerId == refId &&
            c.PayId == payId).Any();
        }
        public IEnumerable<PaymentInvoice> GetAllPaymentInvoice(string payCode, bool? status)
        {
            if(status==null)
            {
                return Context.Set<PaymentInvoice>().Where(c => c.Payment.PaymentCode.ToLower().Trim() == payCode.ToLower().Trim()).ToList();
            }
            else if(status==true)
            {
                return (from c in Context.Set<PaymentInvoice>()  where c.Payment.PaymentCode.ToLower().Trim() == payCode.ToLower().Trim() && c.TransactionLogs.Where(m=>m.ResponseCode=="00").Any()==true select c).ToList();
            }
            else
            {
                return (from c in Context.Set<PaymentInvoice>() where c.Payment.PaymentCode.ToLower().Trim() == payCode.ToLower().Trim() && c.TransactionLogs.All(m => m.ResponseCode != "00") select c).ToList();
            }
        }

        public IEnumerable<PaymentInvoice> GetAllPaymentInvoiceByRef(string refNo, bool? status)
        {
            if (status == null)
            {
                return Context.Set<PaymentInvoice>().Where(c => c.Payer.RefNo.ToLower().Trim() == refNo.ToLower().Trim()).ToList();
            }
            else if (status == true)
            {
                return (from c in Context.Set<PaymentInvoice>() where c.Payer.RefNo.ToLower().Trim() == refNo.ToLower().Trim() && c.TransactionLogs.Where(m => m.ResponseCode == "00").Any() == true select c).ToList();
            }
            else
            {
                return (from c in Context.Set<PaymentInvoice>() where c.Payer.RefNo.ToLower().Trim() == refNo.ToLower().Trim() && c.TransactionLogs.All(m => m.ResponseCode != "00") select c).ToList();
            }
        }

        public PaymentInvoice GetPaymentInvoice(string refNo, string payCode)
        {
            return Context.Set<PaymentInvoice>().Where(c => c.Payer.RefNo.ToLower().Trim() == refNo.ToLower().Trim() &&
            c.Payment.PaymentCode.ToLower().Trim() == payCode.ToLower().Trim()).FirstOrDefault();
        }
    }
}