using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPaymentCoreContext : IDisposable
    {
        ISchoolRepository SchoolDAL { get; }
        IBankRepository BankDAL { get; }
        IAccountDetailRepository AccountDetailDAL { get;}
        IPaymentSplitRepository PaymentSplitDAL { get; }
        IPaymentRepository PaymentDAL { get; }
        int SaveChanges();
    }
}
