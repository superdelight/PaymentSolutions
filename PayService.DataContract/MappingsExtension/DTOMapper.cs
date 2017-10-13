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

    }
}
