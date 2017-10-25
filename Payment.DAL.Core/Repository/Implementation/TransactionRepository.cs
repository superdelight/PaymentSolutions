
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
    public class TransactionRepository : Repository<TransactionLog>, ITransactionRepository
    {
        private DbContext Context;
        public TransactionRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }
        public bool ConfirmTransaction(string transRef)
        {
            return Context.Set<TransactionLog>().Where(c => c.TransactionRefNo.ToLower().Trim() == transRef.ToLower().Trim()).Any();
        }
        public IEnumerable<TransactionLog> GetAllTransactions(string payCode)
        {
            return Context.Set<TransactionLog>().Where(c => c.PaymentInvoice.Payment.PaymentCode.ToLower().Trim() == payCode.ToLower()).ToList();
        }
        public TransactionLog GetTransaction(string transRef)
        {
            return Context.Set<TransactionLog>().Where(c => c.TransactionRefNo.ToLower().Trim() == transRef.ToLower().Trim()).FirstOrDefault();
        }
    }
}