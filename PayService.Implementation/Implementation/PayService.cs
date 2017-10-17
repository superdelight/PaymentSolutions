using PayService.Implementation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayService.DataContract;
using PaymentBLL.Interface;
using Payment.DAL.Core.Model;
using PayService.DataContract.MappingsExtension;

namespace PayService.Implementation.Implementation
{
    
    public class PayService : IPayService
    {

        IPaymentManagement payLogic;
        public PayService(IPaymentManagement payLogic)
        {
            this.payLogic = payLogic;
        }
  
        private  ServiceResponse<bool> GetMessage(PaymentBLL.Utility.BusinessMessage<bool> response)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            if (response.Result == true)
            {
                serviceResponse.Result = true;
                serviceResponse.Response = ResponseCode.OK;
                serviceResponse.Message = response.Message;
            }
            else
            {
                serviceResponse.Result = false;
                serviceResponse.Response = ResponseCode.ValidationError;
                serviceResponse.Message = response.Message;
            }
            return serviceResponse;
        }
       
        public ServiceResponse<bool> CreatePaymentItem(PaymentDTO pay)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            PaymentDetail payment = new PaymentDetail()
            {
                PaymentDescription = pay.PaymentDescription,
                PayEngineId = pay.PayEngineId,
                PaymentCode = pay.PaymentCode,
                SchId = pay.SchId,
                ReqId = pay.ReqId,
                PeriodId = pay.PeriodId,
                TotalAmount = pay.TotalAmount,
                DateCreated = pay.DateCreated,
                IsActive = pay.IsActive
            };
            var response = payLogic.CreatePaymentItem(payment);
            if (response.Result == true)
            {
                serviceResponse.Result = true;
                serviceResponse.Success = true;
                serviceResponse.Response = ResponseCode.OK;
                serviceResponse.Message = response.Message;
            }
            else
            {
                serviceResponse.Result = false;
                serviceResponse.Success = false;
                serviceResponse.Response = ResponseCode.ValidationError;
                serviceResponse.Message = response.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<PaymentDTO> GetPaymentByCode(string paymentCode)
        {
            ServiceResponse<PaymentDTO> serviceResponse = new ServiceResponse<PaymentDTO>();
            try
            {
                serviceResponse.Result = payLogic.GetPaymentByCode(paymentCode).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<PaymentDTO> GetPayment(string paymentDescription)
        {
            ServiceResponse<PaymentDTO> serviceResponse = new ServiceResponse<PaymentDTO>();
            try
            {
                serviceResponse.Result = payLogic.GetPayment(paymentDescription).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<PaymentDTO>> GetAllPayments()
        {
            ServiceResponse<List<PaymentDTO>> serviceResponse = new ServiceResponse<List<PaymentDTO>>();
            try
            {
                serviceResponse.Result = payLogic.GetAllPayments().Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<PaymentDTO>> GetAllPaymentsPerPeriod(int periodId)
        {
            ServiceResponse<List<PaymentDTO>> serviceResponse = new ServiceResponse<List<PaymentDTO>>();
            try
            {
                serviceResponse.Result = payLogic.GetAllPaymentsPerPeriod(periodId).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<PaymentDTO>> GetAllSubPayments(int paymentId)
        {
            ServiceResponse<List<PaymentDTO>> serviceResponse = new ServiceResponse<List<PaymentDTO>>();
            try
            {
                serviceResponse.Result = payLogic.GetAllSubPayments(paymentId).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<PaymentDTO> GetAllPreReqPayments(int paymentId)
        {
            ServiceResponse<PaymentDTO> serviceResponse = new ServiceResponse<PaymentDTO>();
            try
            {
                serviceResponse.Result = payLogic.GetAllPreReqPayments(paymentId).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> CreateNewPaymentSplit(SplitPaymentDTO pay)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            SplitPayment paySplit = new SplitPayment()
            {
                PaymentCode = pay.PaymentCode,
                Description = pay.Description,
                Amount = pay.Amount,
                PayId = pay.PayId,
                AccId = pay.AccId,
                DateCreated = pay.DateCreated
            };

            var response = payLogic.CreateNewPaymentSplit(paySplit);
            if (response.Result == true)
            {
                serviceResponse.Result = true;
                serviceResponse.Success = true;
                serviceResponse.Response = ResponseCode.OK;
                serviceResponse.Message = response.Message;
            }
            else
            {
                serviceResponse.Result = false;
                serviceResponse.Success = false;
                serviceResponse.Response = ResponseCode.ValidationError;
                serviceResponse.Message = response.Message;
            }
            return serviceResponse;
        }

        public ServiceResponse<SplitPaymentDTO> GetPaymentSplitByCode(string Code)
        {
            ServiceResponse<SplitPaymentDTO> serviceResponse = new ServiceResponse<SplitPaymentDTO>();
            try
            {
                serviceResponse.Result = payLogic.GetPaymentSplitByCode(Code).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<List<SplitPaymentDTO>> GetAllPaymentSplit(int payId)
        {
            ServiceResponse<List<SplitPaymentDTO>> serviceResponse = new ServiceResponse<List<SplitPaymentDTO>>();
            try
            {
                serviceResponse.Result = payLogic.GetAllPaymentSplit(payId).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<SplitPaymentDTO> GetPaymentSplit(string code)
        {
            ServiceResponse<SplitPaymentDTO> serviceResponse = new ServiceResponse<SplitPaymentDTO>();
            try
            {
                serviceResponse.Result = payLogic.GetPaymentSplit(code).Result.ToDTO();
                serviceResponse.Response = ResponseCode.OK;
            }
            catch
            {
                serviceResponse.Result = null;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<bool> CreateNewPaymentEngine(PaymentEngineDTO payEngine)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            try
            {
                PaymentEngine pay = new PaymentEngine()
                {
                    PaymentCode = payEngine.PaymentCode,
                    Currency = payEngine.Currency,
                    MacKey = payEngine.MacKey,
                    PaymentDescription = payEngine.PaymentDescription,
                    PaymentId = payEngine.PaymentId,
                    PaymentURL = payEngine.PaymentURL,
                    PaymentUpdateURL = payEngine.PaymentUpdateURL,
                    SchId = payEngine.SchId,
                    DateCreated = DateTime.Now

                };
              var response= payLogic.CreateNewPaymentEngine(pay);
                serviceResponse.Result = response.Result;
                serviceResponse.Response = (ResponseCode)response.Response;
                serviceResponse.Message = response.Message;
            }
            catch
            {
                serviceResponse.Result = false; ;
                serviceResponse.Response = ResponseCode.NotFound;
            }
            return serviceResponse;
        }

        public ServiceResponse<PaymentEngineDTO> GetPaymentEngineByCode(string paymentCode)
        {
            ServiceResponse<PaymentEngineDTO> response = new ServiceResponse<PaymentEngineDTO>();
            try
            {
               var reply= payLogic.GetPaymentEngineByCode(paymentCode);
                response.Result = reply.Result.ToDTO();
                response.Response = (ResponseCode)reply.Response;
                response.Message = reply.Message;
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
        }

        public ServiceResponse<PaymentEngineDTO> GetPaymentEngine(string description)
        {

            ServiceResponse<PaymentEngineDTO> response = new ServiceResponse<PaymentEngineDTO>();
            try
            {
                var reply = payLogic.GetPaymentEngine(description);
                response.Result = reply.Result.ToDTO();
                response.Response = (ResponseCode)reply.Response;
                response.Message = reply.Message;
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Response = ResponseCode.ServerException;
                response.Message = ex.Message;
            }
            return response;
        }

        public ServiceResponse<List<PaymentEngineDTO>> GetAllPaymentEngine()
        {

            ServiceResponse<List<PaymentEngineDTO>> response = new ServiceResponse<List<PaymentEngineDTO>>();
            try
            {
                var reply = payLogic.GetAllPaymentEngine();
                response.Result = reply.Result.ToDTO();
                response.Response = (ResponseCode)reply.Response;
                response.Message = reply.Message;
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
