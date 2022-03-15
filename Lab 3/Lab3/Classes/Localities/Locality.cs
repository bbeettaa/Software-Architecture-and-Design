using BLL.Classes.Owners;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Localities
{
    public abstract class Locality
    {
        protected int polution = 0;
        protected float foodAmountPercent = 0;

        public delegate void ChangeEventHandler(object source, LocalityEventArgs e);
        public event ChangeEventHandler OnChangeHandler;
        

        abstract public int Sleep();
        abstract public int Feeding(Animal animal);
        abstract public int CountComfortPercent();


        abstract public int GetPolution();
        abstract public void SetPolution(int polution);
        abstract public float GetFoodAmountPercent();
        abstract public void SetFoodAmountPercent(float foodAmount);

        virtual public void Notify() {
            OnChangeHandler.Invoke(this, new LocalityEventArgs(polution, foodAmountPercent));
        }
        abstract public Owner GetOwner();
    }
}
