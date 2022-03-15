using BLL.Новая_папка;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Builder
{
    public interface IBuilder
    {
        Animal BuildWildAnimal(String name);
        Animal BuildHomeAnimal(String name);

    }
}
