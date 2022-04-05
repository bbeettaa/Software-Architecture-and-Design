using BLL.Classes.Localities;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Owners
{
    [Serializable]
    public abstract class Owner
    {
        protected float foodIncreasePercent;
        protected int polutionClean;
        protected int comfort = 0;
        [NonSerialized]
        protected Random random;


        public Owner() {
            random = new Random(0);
        }

        abstract public void Update(object source, LocalityEventArgs e);
        }
}
