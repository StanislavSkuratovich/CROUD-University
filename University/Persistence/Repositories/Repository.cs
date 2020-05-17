using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace University.DI.Repositories
{
    public abstract class Repository <TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Get(string name)
        {
            return _context.Set<TEntity>().Find(name);
        }



        public IEnumerable<TEntity> GetAll()//instead of using Iquerryable (there should be just a collection) 
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }


    }
}