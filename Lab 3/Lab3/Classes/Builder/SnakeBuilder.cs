using BLL.Classes.Animals;
using BLL.Classes.Localities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Builder
{
    class SnakeBuilder : IBuilder
    {

        public Animal BuildHomeAnimal(String name)
        {
            Snake cat = new Snake(name);
            cat.locality = new Home();
            return cat;
        }

        public Animal BuildWildAnimal(String name)
        {
            Snake cat = new Snake(name);
            cat.locality = new Nature();
            return cat;
        }
    }
}
 