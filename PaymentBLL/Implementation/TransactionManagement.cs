using PaymentBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.DAL.Core.Model;
using Payment.DAL.Core.Repository.Interface;
using Microsoft.Practices.Unity;
using Payment.DAL.Core.Service;
using PaymentBLL.Utility;

namespace PaymentBLL.Implementation
{
    public class TransactionManagement : ITransactionManagement
    {

        IPaymentCoreContext context;
        public TransactionManagement(PaymentCoreContext context)
        {
            this.context = context;
        }

        public BusinessMessage<bool> CreateInvoice(PaymentInvoice invoice)
        {
            BusinessMessage<bool> response = new Utility.BusinessMessage<bool>();
            response.Result = false;
            if (!context.PaymentInvoiceDAL.ConfirmInvoice((int)invoice.PayerId, (int)invoice.PayId))
            {
                context.PaymentInvoiceDAL.Add(invoice);
                if(context.SaveChanges()>0)
                {
                    response.Result = true;
                    response.Message = "Entry of Payment Invoice was successful...";
                    response.Response = ResponseCode.OK;
                }
                else
                {
                    response.Message = "Unable to  proceed...";
                    response.Response = ResponseCode.Error;
                }
            }
            else
            {
                response.Message = "Duplicate Entry Cannot be made";
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<bool> CreatePayer(Payer pay)
        {
            BusinessMessage<bool> response = new Utility.BusinessMessage<bool>();
            response.Result = false;
            response.Response = ResponseCode.Error;
            if (!context.PayerDAL.ConfirmPerson(pay.RefNo))
            {
                context.PayerDAL.Add(pay);
                if (context.SaveChanges() > 0)
                {
                    response.Result = true;
                    response.Message = "You have successfully created new person...";
                    response.Response = ResponseCode.OK;
                }
                else
                {
                    response.Message = "Unable to make proceed...";
                    response.Response = ResponseCode.Error;
                }
            }
            else
            {
                response.Message = "Duplicate Entry Cannot be made";
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<Payer> GetPayer(string refNo)
        {
            BusinessMessage<Payer> response = new BusinessMessage<Payer>();
            try
            {
                response.Result = context.PayerDAL.GetPayer(refNo);
                response.Response = ResponseCode.OK;
            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Message = ex.Message;
                response.Response = ResponseCode.Error;
            }
            return response;
        }
        public BusinessMessage<PaymentInvoice> GetPaymentInvoice(string payCode, string refNo)
        {
            BusinessMessage<PaymentInvoice> response = new BusinessMessage<PaymentInvoice>();
            response.Response = ResponseCode.OK;
            try
            {
                response.Result = context.PaymentInvoiceDAL.GetPaymentInvoice(refNo, payCode);
            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
        }

        public BusinessMessage<TransactionLog> GetTransaction(string transLog)
        {
            BusinessMessage<TransactionLog> response = new BusinessMessage<TransactionLog>();
            response.Response = ResponseCode.OK;
            try
            {
                response.Result = context.TransactionDAL.GetTransaction(transLog);
                
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Response = ResponseCode.ServerException;
            }
            return response;
        }

        public BusinessMessage<bool> LogNewTransaction(TransactionLog transLog)
        {
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            response.Response = ResponseCode.OK;
            try
            {
               context.TransactionDAL.Add(transLog);
                if(context.SaveChanges()>0)
                {
                    response.Message = "You have successfully created new Transaction Log";
                    response.Result = true;
                }
                else
                {
                    response.Message = "Unable to proceed..";
                    response.Result = false;

                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Result = false;
            }
            return response;
        }

        public BusinessMessage<bool> UpdateInvoice(PaymentInvoice invoice)
        {
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            response.Response = ResponseCode.OK;
            try
            {
                response.Result = context.PaymentInvoiceDAL.Edit(invoice,invoice.Id);
            }
            catch (Exception ex)
            {
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
        }

        public BusinessMessage<bool> UpdateTransaction(TransactionLog transLog)
        {
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            response.Response = ResponseCode.OK;
            try
            {
                context.TransactionDAL.Edit(transLog, transLog.Id);
                if (context.SaveChanges() > 0)
                {
                    response.Result = true;
                    response.Message = "Transaction Updated";
                    response.Response = ResponseCode.OK;
                }
                else
                {
                    response.Result = false;
                    response.Message = "Update failed ";
                    response.Response = ResponseCode.Error;
                }
            }
            catch(Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
                response.Response = ResponseCode.ServerException;
            }
            return response;
        }
    }
}
