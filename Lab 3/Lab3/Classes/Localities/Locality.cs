using BLL.Classes.Owners;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL.Classes.Localities
{
    [Serializable]
    public abstract class Locality
    {
        
        public Owner owner;

        public int polution = 0;
        public float foodAmountPercent = 0;
        /*        [NonSerialized]
                public delegate void ChangeEventHandler(object source, LocalityEventArgs e);
                public event ChangeEventHandler OnChangeHandler;*/

        public Locality()
        {

        }
        public Locality(Owner owner){
            this.owner = owner;
        }
        abstract public int Sleep();
        abstract public int Feeding(Animal animal);
        abstract public int CountComfortPercent();


        abstract public int GetPolution();
        abstract public void SetPolution(int polution);
        abstract public float GetFoodAmountPercent();
        abstract public void SetFoodAmountPercent(float foodAmount);

        virtual public void Notify() {
            // OnChangeHandler.Invoke(this, new LocalityEventArgs(polution, foodAmountPercent));
            owner.Update(this,new LocalityEventArgs(polution,foodAmountPercent));
        }
        abstract public Owner GetOwner();
    }
}
