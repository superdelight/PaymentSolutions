
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
    public class PayerRepository : Repository<Payer>, IPayerRepository
    {
        private DbContext Context;
        public PayerRepository(DbContext Context)
            : base(Context)
        {
            this.Context = Context;
        }

        public bool ConfirmPerson(string refNo)
        {
            return Context.Set<Payer>().Any(c => c.RefNo.ToLower().Trim() == refNo.ToLower().Trim());
        }

        public IEnumerable<Payer> GetAllPayers(int schId)
        {
            return Context.Set<Payer>().Where(c => c.SchId == schId);
        }

        public Payer GetPayer(string refNo)
        {
            return Context.Set<Payer>().Where(c => c.RefNo.ToLower().Trim() == refNo.ToLower().Trim()).FirstOrDefault();
        }
    }
}