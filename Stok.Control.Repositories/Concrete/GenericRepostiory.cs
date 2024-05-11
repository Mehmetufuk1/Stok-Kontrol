using Microsoft.EntityFrameworkCore;
using Stok.Control.Entities.Entities;
using Stok.Control.Repositories.Abstract;
using Stok.Control.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Stok.Control.Repositories.Concrete
{
    public class GenericRepostiory<T> : IGenericRepositories<T> where T : BaseEntity
    {
        private readonly StockControlContext context;

        public GenericRepostiory(StockControlContext context)
        {
            this.context = context;
        }

        public bool Activate(int id)
        {
            T item = GetById(id);
            item.isActive = true;
            return Update(item);
        }

        public bool Add(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Add(List<T> items)
        {
            try
            {
                using(TransactionScope ts = new TransactionScope()) 
                {
                    foreach (var item in items)
                    {
                        context.Set<T>().Add(item);
                    }
                    ts.Complete();
                    return Save() > 0;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp) => context.Set<T>().Any(exp);
       

        public List<T> GetActive()=>context.Set<T>().Where(x=>x.isActive==true).ToList();                                            
                  
       
        public IQueryable<T> GetActive(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().Where(x => x.isActive == true);
            if (includes!=null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public List<T> GetAll() =>context.Set<T>().ToList();
        

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            if (includes!=null)
            {
                query = includes.Aggregate(query,(current,includes) => current.Include(includes));
            }
            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().Where(exp);
            if (includes!=null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id) => context.Set<T>().Find(id);
        
       

        public IQueryable<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T entity)
        {
            entity.isActive= false;
            return Update(entity);
        }

        public bool Remove(int id)
        {
            try
            {
                T item = GetById(id);
                return Remove(item);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Update(T entity)
        {
            try
            {
                entity.ModifiedDate = DateTime.Now;
                context.Set<T>().Update(entity);
                return Save() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
