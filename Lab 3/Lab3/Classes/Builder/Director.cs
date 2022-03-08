using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Builder
{
    public class Director
    {
        public Animal BuildWildAnimal(IBuilder builder, String name) { return builder.BuildWildAnimal( name); }
        public Animal BuildHomeAnimal(IBuilder builder, String name) { return builder.BuildHomeAnimal( name); }
    }
}
