using Payment.DAL.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.DAL.Core.Repository.Implementation
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext Context)
        {

            this.Context = Context;
        }
        public bool Add(T Entry)
        {
            try
            {
                Context.Set<T>().Add(Entry);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddRange(IEnumerable<T> Entries)
        {
            try
            {
                Context.Set<T>().AddRange(Entries);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(T Entry)
        {
            if (Context.Entry(Entry).State == EntityState.Detached)
            {
                Context.Set<T>().Attach(Entry);
            }
            Context.Set<T>().Remove(Entry);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();

        }

        public T GetSingle(int Id)
        {
            var instance = Context.Set<T>().Find(Id);
            return instance;
        }
        public T GetSingle(long Id)
        {
            var instance = Context.Set<T>().Find(Id);
            return instance;
        }
        public bool Edit(T Item)
        {
            try
            {
                Context.Set<T>().Attach(Item);
                Context.Entry(Item).State = EntityState.Modified;
                //Context.Entry(Item).State = System.Data.Entity.EntityState.Detached;
                //Context.Entry(Item).State = System.Data.Entity.EntityState.Modified;
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            var ent = Context.Set<T>().Find(Id);
            Context.Set<T>().Remove(ent);
            return true;
        }
        public bool Edit(T Item, int Id)
        {
            try
            {
                var inst = Item;
                var ent = Context.Set<T>().Find(Id);

                Context.Entry(ent).State = System.Data.Entity.EntityState.Detached;
                ent = inst;

                Context.Entry(ent).State = System.Data.Entity.EntityState.Modified;

                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool Edit(T entry, long Id)
        {
            try
            {
                var inst = entry;
                var ent = Context.Set<T>().Find(Id);

                Context.Entry(ent).State = System.Data.Entity.EntityState.Detached;
                ent = inst;

                Context.Entry(ent).State = System.Data.Entity.EntityState.Modified;

                return true;

            }
            catch
            {
                return false;
            }
        }
        public  IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,  string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public void DeleteRange(List<T> entries)
        {
              Context.Set<T>().RemoveRange(entries);
        }

     
    }
}

