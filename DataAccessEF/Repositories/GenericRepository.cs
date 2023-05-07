using DataAccessEF.Data;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessEF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly asp_tablesContext _dbContext;
        public GenericRepository(asp_tablesContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Create(T item)
        {
            this._dbContext.Set<T>().Add(item);
            this._dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T t = this._dbContext.Set<T>().Find(id);
            if (t != null)
            {
                this._dbContext.Set<T>().Remove(t);
                this._dbContext.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll() => _dbContext.Set<T>().ToList();


        public T GetId(int id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            this._dbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._dbContext.SaveChanges();
        }
    }
}
