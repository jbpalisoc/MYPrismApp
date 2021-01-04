using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYPrismApp.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Animal> Animals { get; }
        void Commit();
    }
}
