using BLL.Classes.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Localities
{
    public interface ILocality
    {
        public int Sleep();
        public int Feeding(Animal animal);
        public int CountComfortPercent();


        public int GetPolution();
        public void SetPolution(int polution);
        public float GetFoodAmountPercent();
            public void SetFoodAmountPercent(float foodAmount);

        public void Notify();
        public Owner GetOwner();
    }
}
