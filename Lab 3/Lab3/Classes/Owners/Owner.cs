using BLL.Classes.Localities;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Owners
{
    public interface Owner
    {
        public void Update(object source, LocalityEventArgs e);
        }
}
