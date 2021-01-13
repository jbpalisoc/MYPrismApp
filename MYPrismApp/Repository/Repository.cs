using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYPrismApp.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MyDbContext _context;
        public Repository(MyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity>GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
    }
}
