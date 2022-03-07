﻿using BLL.Classes.Animals;
using BLL.Classes.Localities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Builder
{
    class ParrotBuilder : IBuilder {
        
            public Animal BuildHomeAnimal(String name)
            {
        Parrot cat = new Parrot(name);
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

