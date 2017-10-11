
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
    public class AccountDetailRepository : Repository<AccountDetail>, IAccountDetailRepository
    {
        private DbContext Context;
        public AccountDetailRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public bool ConfirmAccountDetail(string accountNumber)
        {
            return Context.Set<AccountDetail>().Any(c => c.AccountNo.Trim().ToLower() == accountNumber.Trim().ToLower());
        }

        public AccountDetail GetAccountDetail(string accountNumber)
        {
            return Context.Set<AccountDetail>().Where(c => c.AccountNo.Trim().ToLower() == accountNumber.Trim().ToLower()).FirstOrDefault();
        }
    }
}