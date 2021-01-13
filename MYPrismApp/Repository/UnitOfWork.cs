using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYPrismApp.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MyDbContext _context;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            Animals = new AnimalRepository(_context);
        }

        public IAnimalRepository Animals { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
