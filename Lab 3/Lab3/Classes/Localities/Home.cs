using BLL.Classes.Owners;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Classes.Localities
{
    [Serializable]
    public class Home : Locality
    {
        private int comfort = 0;

        public Home():base() {
            owner = new Man();
        }

        public Home(Owner owner) : base(owner)
        {

        }

        public Home(byte polution, byte foodAmountPercent):this() {
            this.polution = polution;
            this.foodAmountPercent = foodAmountPercent;
        }

        override public void Notify()
        {
            base.Notify();
            CountComfortPercent();
        }

        override public int CountComfortPercent()
        {
            comfort = ((int)(foodAmountPercent - polution));
            return comfort;
        }

        override public int Feeding(Animal animal)
        {
            Random random = new Random();
            int chance = random.Next(50, 70);
            chance += animal.GetAgility() / 15;
            chance += animal.GetEnergy() / 15;
            chance += animal.GetHealth() / 15;
            chance += 10 - animal.GetSatiety() / 15;
            chance += (int)(foodAmountPercent / 15);

            //System.Diagnostics.Debug.WriteLine($"feeding {chance}%");

            if (chance >= 90 && foodAmountPercent >= 10)
            {
                polution += 10;
                foodAmountPercent -= 10;
                return 25;
            }
            if (chance >= 80 && foodAmountPercent >= 5)
            {
                polution += 5;
                foodAmountPercent -= 5;
                return 12;
            }
            if (chance >= 70 && foodAmountPercent >= 1)
            {
                polution += 1;
                foodAmountPercent -= 1;
                return 2;
            }
            CountComfortPercent();
            return 0;
        }

        override public int Sleep()
        {
            CountComfortPercent();
            return (comfort % 100);
        }

        override public int GetPolution()
        {
            return this.polution;
        }

        override public void SetPolution(int polution)
        {
            this.polution = polution;
        }

        override public float GetFoodAmountPercent()
        {
            return this.foodAmountPercent;
        }

        override public void SetFoodAmountPercent(float foodAmount)
        {
            this.foodAmountPercent = (int)foodAmount;
        }

        public override String ToString() { return $"{this.GetType().Name}, Polution - {polution}%, FoodAmount - {foodAmountPercent}%, Comfor - {comfort}   "; }

        override public Owner GetOwner()
        {
            return owner;
        }

    }
}
