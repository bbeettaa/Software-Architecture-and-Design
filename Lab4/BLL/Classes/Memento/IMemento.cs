using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Memento
{
    public interface IMemento
    {
        Content GetContent();
    }
}
