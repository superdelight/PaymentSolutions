using Microsoft.Practices.Unity;
using Payment.DAL.Core.Repository.Implementation;
using Payment.DAL.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Service
{
    public class PaymentCoreContext: IPaymentCoreContext
    {
           private readonly PaymentContext _context;
        public PaymentCoreContext()
        {
            _context = new PaymentContext();
            SchoolDAL = new SchoolRepository(_context);
            AccountDetailDAL = new AccountDetailRepository(_context);
            BankDAL = new BankRepository(_context);
            PaymentSplitDAL = new PaymentSplitRepository(_context);
            PaymentDAL = new PaymentRepository(_context);
        }
        public IAccountDetailRepository AccountDetailDAL { get; private set; }
        public IBankRepository BankDAL { get; private set; }

        public IPaymentRepository PaymentDAL { get; private set; }
       

        public IPaymentSplitRepository PaymentSplitDAL { get; private set; }
       

        public ISchoolRepository SchoolDAL { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int SaveChanges()
        {
            try
            {
                var rsp= _context.SaveChanges();
                return rsp;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
