using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYPrismApp.Repository
{
    public class AnimalRepository: Repository<Animal>, IAnimalRepository  
    {
        public AnimalRepository(MyDbContext context) : base(context)
        {

        }

       /* public MyDbContext MyDbContext
        {
            get { return _context as MyDbContext; }
        }*/
    }
}
