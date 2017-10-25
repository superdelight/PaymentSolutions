using PayService.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PayService.Implementation.Interface
{

    
    [ServiceContract]
   public interface ITransactionService
    {
        [OperationContract]
        ServiceResponse<TransactionDTO> CreateNewTransaction(TransactionEntryDTO transDet);
        [OperationContract]
        ServiceResponse<bool> UpdateTransaction(string transRefNo, string response,string bankRef,string merchantRef,string dateProcessed);
    }
}
