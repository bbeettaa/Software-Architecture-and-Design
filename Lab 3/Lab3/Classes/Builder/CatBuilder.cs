using BLL.Classes.Animals;
using BLL.Classes.Localities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Builder
{
    class CatBuilder : IBuilder
    {
        public Animal BuildHomeAnimal(String name)
        {
            Cat cat = new Cat(name);
            cat.locality = new Home();
            return cat;
        }

        public Animal BuildWildAnimal(String name)
        {
            Cat cat = new Cat(name);
            cat.locality = new Nature();
            return cat;
        }
    }
}
