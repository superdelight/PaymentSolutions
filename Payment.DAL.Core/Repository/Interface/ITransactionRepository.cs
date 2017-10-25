using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface ITransactionRepository : IRepository<TransactionLog>
    {
        bool ConfirmTransaction(string transRef);
        TransactionLog GetTransaction(string transRef);
        IEnumerable<TransactionLog> GetAllTransactions(string payCode);
    }
}
