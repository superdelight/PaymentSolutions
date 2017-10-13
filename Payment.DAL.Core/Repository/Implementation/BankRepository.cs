
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
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        private DbContext Context;
        public BankRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public bool ConfirmBank(string bankName, string bankCode)
        {
            try
            {
                return Context.Set<Bank>().Where(c => c.BankName.Trim().ToLower() == bankName.Trim().ToLower() ||
                c.Acronyms.Trim().ToLower() == bankCode.Trim().ToLower()).Any();
            }
            catch(Exception ex)
            {
                var m = ex.Message;
                return false;
            }
        }
       
        public Bank GetBank(string bankName, string bankCode)
        {
            return Context.Set<Bank>().Where(c => c.BankName.Trim().ToLower() == bankName.Trim().ToLower() ||
           c.Acronyms.Trim().ToLower() == bankCode.Trim().ToLower()).FirstOrDefault();
        }
        public Bank GetBankById(string Id)
        {
            return Context.Set<Bank>().Where(c => c.BankNo.ToString()==Id).FirstOrDefault();
        }
    }
}