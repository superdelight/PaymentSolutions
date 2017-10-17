using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayService.DataContract.MappingsExtension
{
    public static class DTOMapper
    {
        public static BankDTO ToDTO(this Bank source)
        {
            if (source == null) return null;
            return new BankDTO()
            {
                BankName = source.BankName,
                BankId = source.BankNo.ToString(),
                Acronyms = source.Acronyms
            };
        }


        public static List<BankDTO> ToDTO(this List<Bank> source)
        {
            if (source == null) return new List<BankDTO>();
            List<BankDTO> banks = new List<BankDTO>();
            source.ForEach(o => banks.Add(o.ToDTO()));
            return banks;
        }

        public static SchoolDTO ToDTO(this School source)
        {
            if (source == null) return null;
            return new SchoolDTO()
            {
                SchoolName = source.SchoolName,
                SchoolCode = source.SchoolCode
              
            };
        }

        public static List<SchoolDTO> ToDTO(this List<School> source)
        {
            if (source == null) return new List<SchoolDTO>();
            List<SchoolDTO> sch = new List<SchoolDTO>();
            source.ForEach(o => sch.Add(o.ToDTO()));
            return sch;
        }
        public static AccountDetailDTO ToDTO(this AccountDetail source)
        {
            if (source == null) return null;
            return new AccountDetailDTO()
            {
                AccountName = source.AccountName,
                AccountCode = source.AccountNo

            };
        }

        public static List<AccountDetailDTO> ToDTO(this List<AccountDetail> source)
        {
            if (source == null) return new List<AccountDetailDTO>();
            List<AccountDetailDTO> sch = new List<AccountDetailDTO>();
            source.ForEach(o => sch.Add(o.ToDTO()));
            return sch;
        }

        public static PaymentEngineDTO ToDTO(this PaymentEngine source)
        {
            if (source == null) return null;
            return new PaymentEngineDTO()
            {
                PaymentId = source.PaymentId,
                PaymentUpdateURL = source.PaymentUpdateURL,
                PaymentURL = source.PaymentURL,
                ProductId = source.ProductId,
                PaymentDescription = source.PaymentDescription,
                Currency=source.Currency,
                MacKey = source.MacKey,
                SchId = source.SchId,
                PaymentCode=source.PaymentCode
            };
        }

        public static List<PaymentEngineDTO> ToDTO(this List<PaymentEngine> source)
        {
            if (source == null) return new List<PaymentEngineDTO>();
            List<PaymentEngineDTO> sch = new List<PaymentEngineDTO>();
            source.ForEach(o => sch.Add(o.ToDTO()));
            return sch;
        }

        public static PaymentDTO ToDTO(this PaymentDetail source)
        {
            if (source == null) return null;
            return new PaymentDTO()
            {
                IsActive = source.IsActive,
                DateCreated = source.DateCreated,
                PaymentCode=source.PaymentCode,
                PayEngineId=source.PayEngineId,
                PaymentDescription=source.PaymentDescription,
                PeriodId=source.PeriodId,
                ReqId=source.ReqId,
                SchId=source.SchId,
                TotalAmount=source.TotalAmount
            };
        }

        public static List<PaymentDTO> ToDTO(this List<PaymentDetail> source)
        {
            if (source == null) return new List<PaymentDTO>();
            List<PaymentDTO> sch = new List<PaymentDTO>();
            source.ForEach(o => sch.Add(o.ToDTO()));
            return sch;
        }


        public static SplitPaymentDTO ToDTO(this SplitPayment source)
        {
            if (source == null) return null;
            return new SplitPaymentDTO()
            {
                AccId = source.AccId,
                DateCreated = source.DateCreated,
                Description = source.Description,
                PayId = source.PayId,
                PaymentCode = source.PaymentCode,
                Amount = source.Amount
                 
            };
        }
        public static List<SplitPaymentDTO> ToDTO(this List<SplitPayment> source)
        {
            if (source == null) return new List<SplitPaymentDTO>();
            List<SplitPaymentDTO> sch = new List<SplitPaymentDTO>();
            source.ForEach(o => sch.Add(o.ToDTO()));
            return sch;
        }
    }


}
