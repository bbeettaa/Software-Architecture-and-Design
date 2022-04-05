using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.BLL.Context
{
    public interface IRepositoryContext
    {
        List<Content> Read();
        void Write(Content file);
        void Update(Content file);
        void Delete(Content file);

    }
}
