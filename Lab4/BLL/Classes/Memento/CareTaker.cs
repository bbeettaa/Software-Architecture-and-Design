using BLL.Classes.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Memento
{
    public class CareTaker
    {
        List<IMemento> mementos;
        public CareTaker() {
            mementos = new List<IMemento>();
        }

        public void Save(Content content) {
            mementos.Add(new ConcretMemento(content));
        }

        public Content Ubdo() {
            if (mementos.Count == 0) return null;

            try {
                IMemento m = mementos.Last();
                mementos.Remove(m);
                return m.GetContent();
            } catch (Exception ex) { 
                this.Ubdo(); 
            }

            return null;
        }
    }
}
