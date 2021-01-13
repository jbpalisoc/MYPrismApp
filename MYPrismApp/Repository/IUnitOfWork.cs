using System;
using System.Collections.Generic;
using System.Text;

namespace MYPrismApp.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalRepository Animals { get; }
        int Complete();
    }
}
