using Payment.DAL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IPayerRepository : IRepository<Payer>
    {
        bool ConfirmPerson(string refNo);
        Payer GetPayer(string refNo);
        IEnumerable<Payer> GetAllPayers(int schId);
    }
}
