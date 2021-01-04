using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYPrismApp.Repository
{
    class UnitOfWork
    {
        private MyDbContext _dbContext;
        private BaseRepository<Animal> _animals;

        public UnitOfWork(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Animal> Animals
        {
            get
            {
                return _animals ??
                    (_animals = new BaseRepository<Animal>(_dbContext));
            }
        }


        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
