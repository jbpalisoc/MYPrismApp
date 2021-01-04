using MYPrismApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MYPrismApp.Repository
{
    public interface IAnimalRepository 
    {
        ObservableCollection<Animal> Get();
    }
}
