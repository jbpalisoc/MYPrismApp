using System;
using System.Collections.Generic;
using System.Text;

namespace MYPrismApp.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
    }
}
