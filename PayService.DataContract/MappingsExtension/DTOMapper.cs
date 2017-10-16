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

    }


}
