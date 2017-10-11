using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Interface
{
    public interface IRepository<T> where T:class
    {
        bool Add(T entry);
        bool AddRange(IEnumerable<T> entries);
        bool Edit(T Item);
        bool Edit(T entry, int Id);
        bool Edit(T entry, long Id);
        T GetSingle(int Id);
        T GetSingle(long Id);
        IEnumerable<T> GetAll();
        bool Delete(T entry);
        void DeleteRange(List<T> entries);
        bool Delete(int Id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

    }
}
