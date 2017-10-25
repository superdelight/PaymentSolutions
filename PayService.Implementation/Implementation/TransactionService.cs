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
using System.Xml.Linq;
using System.Security.Cryptography;

namespace PayService.Implementation.Implementation
{
    
    public class TransactionService : ITransactionService
    {

        ITransactionManagement transLogic;
        IPaymentManagement payLogic;
        IAdminManager adminLogic;

        public TransactionService(ITransactionManagement transLogic, IPaymentManagement payLogic, IAdminManager adminLogic)
        {
            this.transLogic = transLogic;
            this.payLogic = payLogic;
            this.adminLogic = adminLogic;
        }

        private XDocument GetRoot(string refNo,string schoolCode)
        {
            try
            {
                XDocument doc = new XDocument();
                XElement xRoot = new XElement("payment_item_detail");
                XElement det = new XElement("item_details");
                XAttribute refAtt = new XAttribute("detail_ref", refNo);
                XAttribute coll = new XAttribute("college",schoolCode);
                det.Add(refAtt);
                det.Add(coll);
                xRoot.Add(det);
                doc.Add(xRoot);
                return doc;
            }
            catch
            {
                return null;
            }
        }
   
        private string GetInvoiceCode()
        {
            DateTime dt = DateTime.Now;
            return string.Format("{0}{1:D3}{2:D2}{3:D2}", "INV", dt.Hour, dt.Month, dt.Second);

        }
        private string GetTransactionCode(string payCode)
        {
            DateTime dt = DateTime.Now;
            return "TESTING";// string.Format("{0}{1:D3}{2:D2}{3:D2}", payCode.ToUpper(), dt.Hour, dt.Month, dt.Second);
        }

        private string GetHash(string transRef, string productId, string paymentId, string amount, string redirect, string macKey)
        {
            string combineKey = string.Format("{0}{1}{2}{3}{4}{5}",transRef,productId,paymentId,amount,redirect,macKey);
            return GetSHA512(combineKey);
        }
        private string GetSHA512(string val)
        {
            var alg = SHA512.Create();
            alg.ComputeHash(Encoding.UTF8.GetBytes(val));
            return BitConverter.ToString(alg.Hash).Replace("-", "");
        }
        public ServiceResponse<TransactionDTO> CreateNewTransaction(TransactionEntryDTO trans)
        {
            ServiceResponse<TransactionDTO> response = new ServiceResponse<TransactionDTO>();
            var payer = transLogic.GetPayer(trans.RefNo);
            var sch = adminLogic.GetSchoolDefault();
            if (payer.Result == null)
            {
                try
                {
                   
                    payer.Result = new Payer();
                    payer.Result.DateCreated = DateTime.Now;
                    payer.Result.EmailAddress = trans.Email;
                    payer.Result.PhoneNo = trans.PhoneNo;
                    payer.Result.Surname = trans.Surname;
                    payer.Result.Othername = trans.OtherName;
                    payer.Result.RefNo = trans.RefNo;
                    payer.Result.SchId = sch.Result.Id;
                    transLogic.CreatePayer(payer.Result);
                    payer = transLogic.GetPayer(trans.RefNo);
                }
                catch (Exception ex)
                {
                    response.Message = string.Format("{0} occurred when creating Payer", ex.Message);
                    response.Response = ResponseCode.ServerException;
                    response.Result = null;
                }
            }

            if (payer != null)
            {
                string paymentCode = "";
                string transRef = "";
                var payment = payLogic.GetPaymentByCode(trans.PayCode);
                paymentCode = payment.Result.TotalAmount.Value.ToString();
                if (payment != null)
                {
                    try
                    {
                        var invoice = transLogic.GetPaymentInvoice(trans.PayCode, trans.RefNo);

                        if (invoice.Result == null)
                        {
                            try
                            {
                                invoice.Result = new PaymentInvoice();
                                invoice.Result.DateCreated = DateTime.Now;
                                invoice.Result.InvoiceNo = GetInvoiceCode();
                                invoice.Result.PayerId = payer.Result.Id;
                                invoice.Result.PayId = payment.Result.Id;
                                invoice.Result.RevenueCode = invoice.Result.InvoiceNo;

                                transLogic.CreateInvoice(invoice.Result);

                                invoice = transLogic.GetPaymentInvoice(trans.PayCode, trans.RefNo);
                                response.Message = invoice.Message;

                            }
                            catch (Exception ex)
                            {
                                response.Message = string.Format("{0} occurred when creating Invoice", ex.Message);
                                response.Response = ResponseCode.ServerException;
                                response.Result = null;
                            }

                        }


                        try
                        {

                            transRef = GetTransactionCode(payment.Result.PaymentCode);
                            PaymentBLL.Utility.BusinessMessage<PaymentEngine> payEngine = new PaymentBLL.Utility.BusinessMessage<PaymentEngine>();
                            try
                            {
                                payEngine = payLogic.GetPaymentEngine((int)payment.Result.PayEngineId);
                            }
                            catch (Exception ex)
                            {

                            }

                          
                            string macKey = payEngine.Result.MacKey;
                            string currency = payEngine.Result.Currency;
                            string description = payEngine.Result.PaymentDescription;
                            string paymentURL = payEngine.Result.PaymentURL;
                            string paymentUpdateURL = payEngine.Result.PaymentUpdateURL;
                            string productId = payEngine.Result.ProductId;
                            string paymentItem = payEngine.Result.PaymentId;
                            double amt =  double.Parse(payment.Result.TotalAmount.Value.ToString());
                            string TotalAmount = ((amt + 300) * 100).ToString();
                            string hashKey = GetHash(transRef, productId, paymentItem, TotalAmount, paymentUpdateURL, macKey);

                            if (invoice.Result != null)
                            {
                                TransactionLog transLog = new TransactionLog();
                                transLog.DateCreated = DateTime.Now;
                                transLog.Description = payment.Result.PaymentDescription;
                                transLog.InvoiceId = invoice.Result.Id;

                                var resp = transLogic.LogNewTransaction(transLog);
                                response.Message = resp.Message;


                            }
                            else
                            {
                                response.Message = "INVOICE WAS NOT CREATED";// ex.Message;
                                response.Response = ResponseCode.NotFound;
                                response.Result = null;
                            }

                            XDocument doc = GetRoot(transRef, sch.Result.SchoolCode);
                            var paySplits = payLogic.GetAllPaymentSplit((int)payment.Result.Id);
                            int count = 0;
                           // paymentCode = paySplits.Result.Count().ToString();
                            foreach (var det in paySplits.Result)
                           {
                                try
                                {
                                    count++;
                                    double ammt = double.Parse(det.Amount.Value.ToString()) * 100;
                                    XElement itemDet = new XElement("item_detail", new XAttribute("item_id", count), new XAttribute("item_name", det.Description), new XAttribute("item_amt", det.Amount),
                                        new XAttribute("bank_id", det.AccountDetail.Bank.BankNo.Value), new XAttribute("acct_num", det.AccountDetail.AccountNo));
                                    doc.Element("payment_item_detail").Element("item_details").Add(itemDet);//.Where(c => c.Name == "payment_item_detail").FirstOrDefault();
                                }
                                catch (Exception ex)
                                {
                                    response.Message = "eRROR IS FROM HERE";// ex.Message;
                                    response.Response = ResponseCode.ServerException;
                                    response.Result = null;
                                }
                            }
                            // paymentCode = hashKey;
                            float amtTotal =(float)payment.Result.TotalAmount;
                            response.Result = new TransactionDTO();
                            TransactionDTO rss = new TransactionDTO();
                            rss.Amount = "50000"; //string.Format("=N={0:D2}", amtTotal);
                            rss.TransactionAmount = "50,300";// string.Format("=N={0:D2}", amtTotal + 300);
                            rss.PaymentDescription = description;
                            rss.PaymentId = paymentItem;
                            rss.PaymentParameter = "college_split";
                            rss.ProductId = productId;
                            rss.SiteRedirectUrl = paymentUpdateURL;
                            rss.TransactionRef = transRef;
                            rss.HashKey = hashKey;
                            rss.OperationalURL = paymentURL;
                            rss.XML = doc.ToString();
                            response.Result = rss;
                            response.Success = true;
                            response.Message = "OK";
                            response.Response = ResponseCode.OK;
                           
                        }
                        catch (Exception ex)
                        {
                            response.Message = string.Format("{0} occurred when creating transaction", ex.InnerException.Message);
                            response.Response = ResponseCode.ValidationError;
                            response.Result = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        response.Message = ex.Message;// sch.Result.SchoolCode + " " + paymentCode;//ex.Message;///payment.Result.TotalAmount.Value.ToString();
                    }
                }
                else
                {
                    response.Message = string.Format("Unable to retrieve Payment with the given parameters");
                    response.Response = ResponseCode.ServerException;
                    response.Result = null;
                }
            }
            else
            {
                response.Message = "Unable to retrieve Personal Details";
                response.Response = ResponseCode.NotFound;
                response.Result = null;

            }

            return response;
        }
        
        public ServiceResponse<bool> UpdateTransaction(string transRefNo, string response, string bankRef, string merchantRef, string dateProcessed)
        {
            throw new NotImplementedException();
        }
    }
}
