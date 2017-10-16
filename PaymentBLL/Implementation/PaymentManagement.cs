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
    public class PaymentManagement : IPaymentManagement
    {

        IPaymentCoreContext context;
        public PaymentManagement(PaymentCoreContext context)
        {
            this.context = context;
        }

        public BusinessMessage<bool> CreateNewPaymentSplit(SplitPayment pay)
        {
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            try
            {
                if (context.PaymentSplitDAL.GetPaymentSplit(pay.PaymentCode)==null)
                {
                    context.PaymentSplitDAL.Add(pay);
                    if (context.SaveChanges() > 0)
                    {
                        response.Response = ResponseCode.OK;
                        response.Message = string.Format("You have successfully created new payment");
                        response.Result = true;
                        
                    }
                    else
                    {
                        response.Response = ResponseCode.Error;
                        response.Message = string.Format("The system was unable to complete the operation");
                        response.Result = false;
                    }
                }
                else
                {
                    response.Response = ResponseCode.Error;
                    response.Message = string.Format("Duplicate entry is not allowed ");
                    response.Result = false;
                }
            }
            catch (Exception ex)
            {
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
                response.Result = false;
            }
            return response;
        }

        public BusinessMessage<bool> CreatePaymentItem(Payment.DAL.Core.Model.Payment pay)
        {
            BusinessMessage<bool> response = new BusinessMessage<bool>();
            try
            {
                if (context.PaymentDAL.GetPaymentByCode(pay.PaymentCode) == null)
                {
                    context.PaymentDAL.Add(pay);
                    if (context.SaveChanges() > 0)
                    {
                        response.Response = ResponseCode.OK;
                        response.Message = string.Format("You have successfully created new payment");
                        response.Result = true;

                    }
                    else
                    {
                        response.Response = ResponseCode.Error;
                        response.Message = string.Format("The system was unable to complete the operation");
                        response.Result = false;
                    }
                }
                else
                {
                    response.Response = ResponseCode.Error;
                    response.Message = string.Format("Duplicate entry is not allowed ");
                    response.Result = false;
                }
            }
            catch (Exception ex)
            {
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
                response.Result = false;
            }
            return response;
        }

        public BusinessMessage<List<Payment.DAL.Core.Model.Payment>> GetAllPayments()
        {
            BusinessMessage<List<Payment.DAL.Core.Model.Payment>> response = new BusinessMessage<List<Payment.DAL.Core.Model.Payment>>();
            try
            {
                response.Result = context.PaymentDAL.GetAll().ToList();
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<List<Payment.DAL.Core.Model.Payment>> GetAllPaymentsPerPeriod(int periodId)
        {
            BusinessMessage<List<Payment.DAL.Core.Model.Payment>> response = new BusinessMessage<List<Payment.DAL.Core.Model.Payment>>();
            try
            {
                response.Result = context.PaymentDAL.GetAllPaymentsPerPeriod(periodId).ToList();
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<SplitPayment> GetPaymentSplit(string code)
        {
            BusinessMessage<SplitPayment> response = new BusinessMessage<SplitPayment>();
            try
            {
                response.Result = context.PaymentSplitDAL.GetPaymentSplit(code);
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<List<SplitPayment>> GetAllPaymentSplit(int payId)
        {
            BusinessMessage<List<SplitPayment>> response = new BusinessMessage<List<SplitPayment>>();
            try
            {
                response.Result = context.PaymentSplitDAL.GetAllPaymentSplit(payId).ToList();
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<Payment.DAL.Core.Model.Payment> GetAllPreReqPayments(int paymentId)
        {
            BusinessMessage<Payment.DAL.Core.Model.Payment> response = new BusinessMessage<Payment.DAL.Core.Model.Payment>();
            try
            {
                response.Result = context.PaymentDAL.GetAllPreReqPayments(paymentId);
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<List<Payment.DAL.Core.Model.Payment>> GetAllSubPayments(int paymentId)
        {
            BusinessMessage<List<Payment.DAL.Core.Model.Payment>> response = new BusinessMessage<List<Payment.DAL.Core.Model.Payment>>();
            try
            {
                response.Result = context.PaymentDAL.GetAllSubPayments(paymentId).ToList();
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<Payment.DAL.Core.Model.Payment> GetPayment(string paymentDescription)
        {
            BusinessMessage<Payment.DAL.Core.Model.Payment> response = new BusinessMessage<Payment.DAL.Core.Model.Payment>();
            try
            {
                response.Result = context.PaymentDAL.GetPayment(paymentDescription);
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<Payment.DAL.Core.Model.Payment> GetPaymentByCode(string paymentCode)
        {
            BusinessMessage<Payment.DAL.Core.Model.Payment> response = new BusinessMessage<Payment.DAL.Core.Model.Payment>();
            try
            {
                response.Result = context.PaymentDAL.GetPayment(paymentCode);
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

        public BusinessMessage<SplitPayment> GetPaymentSplitByCode(string Code)
        {
            BusinessMessage<SplitPayment> response = new BusinessMessage<SplitPayment>();
            try
            {
                response.Result = context.PaymentSplitDAL.GetPaymentSplitByCode(Code);
                response.Response = ResponseCode.OK;
            }
            catch
            {
                response.Result = null;
                response.Response = ResponseCode.Error;
            }
            return response;
        }

       
    }
}
