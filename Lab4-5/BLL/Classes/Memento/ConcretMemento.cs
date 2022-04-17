using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Memento
{
    public class ConcretMemento : IMemento
    {
        private Content content;
        public ConcretMemento(Content content) {
            this.content = content;
        }
        public Content GetContent()
        {
            return content;
        }
    }
}
