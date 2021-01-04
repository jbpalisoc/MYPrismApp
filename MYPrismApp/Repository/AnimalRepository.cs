using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using static MYPrismApp.Model.MyDbContext;

namespace MYPrismApp.Repository
{
    class AnimalRepository : IAnimalRepository
    {
        public ICommand SaveAnimal { get; private set; }
        private MyDbContext DbContext;
        public AnimalRepository()
        {
        }

        public AnimalRepository(MyDbContext context)
            {
                DbContext = context;
            }

            

            public ObservableCollection<Animal> Get()
            {
                return DbContext.Animals.Local.ToObservableCollection();
            }
    }
}
