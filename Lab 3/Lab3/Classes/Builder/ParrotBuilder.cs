using BLL.Classes.Animals;
using BLL.Classes.Localities;
using BLL.Новая_папка;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Builder
{
    class ParrotBuilder : IBuilder
    {

        public Animal BuildHomeAnimal(String name)
        {
            Parrot parrot = new Parrot(name);
            parrot.locality = new Home();
            return parrot;
        }

        public Animal BuildWildAnimal(String name)
        {
            Parrot parrot = new Parrot(name);
            parrot.locality = new Nature();
            return parrot;
        }
    }
}

