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
                    if (pay.PayId!=null)
                    {
                        var payCat = context.PaymentDAL.GetSingle((int)pay.PayId);
                        if (payCat != null)
                        {
                            var allPrevSplitConfigAmount = context.PaymentSplitDAL.GetAllPaymentSplit((int)pay.PayId).Sum(b => b.Amount);

                            float newTotal = (float)allPrevSplitConfigAmount + (float)pay.Amount;
                            if (payCat.TotalAmount >= newTotal)
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
                                float margin = newTotal - (float)payCat.TotalAmount;
                                response.Response = ResponseCode.Error;
                                response.Message = string.Format("The system will not process this Split Amount because it will add an excess of {0} to the original Actual Amount...", margin);
                                response.Result = false;
                            }
                        }
                        else
                        {
                            response.Response = ResponseCode.Error;
                            response.Message = string.Format("The Selected Payment Category Id is not valid...");
                            response.Result = false;
                        }
                    }
                    else
                    {
                        response.Response = ResponseCode.Error;
                        response.Message = string.Format("Payment Category Id is missing");
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

        public BusinessMessage<bool> CreatePaymentItem(PaymentDetail pay)
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

        public BusinessMessage<List<PaymentDetail>> GetAllPayments()
        {
            BusinessMessage<List<PaymentDetail>> response = new BusinessMessage<List<PaymentDetail>>();
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

        public BusinessMessage<List<PaymentDetail>> GetAllPaymentsPerPeriod(int periodId)
        {
            BusinessMessage<List<PaymentDetail>> response = new BusinessMessage<List<PaymentDetail>>();
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

        public BusinessMessage<PaymentDetail> GetAllPreReqPayments(int paymentId)
        {
            BusinessMessage<PaymentDetail> response = new BusinessMessage<PaymentDetail>();
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

        public BusinessMessage<List<PaymentDetail>> GetAllSubPayments(int paymentId)
        {
            BusinessMessage<List<PaymentDetail>> response = new BusinessMessage<List<PaymentDetail>>();
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

        public BusinessMessage<PaymentDetail> GetPayment(string paymentDescription)
        {
            BusinessMessage<PaymentDetail> response = new BusinessMessage<PaymentDetail>();
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

        public BusinessMessage<PaymentDetail> GetPaymentByCode(string paymentCode)
        {
            BusinessMessage<PaymentDetail> response = new BusinessMessage<PaymentDetail>();
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

        public BusinessMessage<bool> CreateNewPaymentEngine(PaymentEngine payEngine)
        {
            BusinessMessage<bool> response = new Utility.BusinessMessage<bool>();
            if (context.PaymentEngineDAL.GetPaymentEngineByCode(payEngine.PaymentCode) == null &&
                (context.PaymentEngineDAL.GetPaymentEngine(payEngine.PaymentDescription) == null))
            {
                context.PaymentEngineDAL.Add(payEngine);
                if(context.SaveChanges()>0)
                {
                    response.Message = string.Format("{0} has been successfully Created", payEngine.PaymentDescription);
                    response.Result = true;
                    response.Response = ResponseCode.OK;
                }
                else
                {
                    response.Message = string.Format("Attempt to create {0} failed", payEngine.PaymentDescription);
                    response.Result = false;
                    response.Response = ResponseCode.Error;
                }
            }
            else
            {
                response.Message = string.Format("Unable to create Payment Details with duplicate parameters");
                response.Result = false;
                response.Response = ResponseCode.Error;
            }
            return response;

        }

        public BusinessMessage<PaymentEngine> GetPaymentEngineByCode(string paymentCode)
        {
            BusinessMessage<PaymentEngine> response = new Utility.BusinessMessage<PaymentEngine>();
            try
            {
                response.Result = context.PaymentEngineDAL.GetPaymentEngineByCode(paymentCode);
                response.Response = ResponseCode.OK;
            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
            
        }

        public BusinessMessage<PaymentEngine> GetPaymentEngine(string description)
        {
            BusinessMessage<PaymentEngine> response = new Utility.BusinessMessage<PaymentEngine>();
            try
            {
                response.Result = context.PaymentEngineDAL.GetPaymentEngine(description);
                response.Response = ResponseCode.OK;
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
        }

        public BusinessMessage<List<PaymentEngine>> GetAllPaymentEngine()
        {
            BusinessMessage<List<PaymentEngine>> response = new Utility.BusinessMessage<List<PaymentEngine>>();
            try
            {
                response.Result = context.PaymentEngineDAL.GetAll().ToList();
                response.Response = ResponseCode.OK;
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
