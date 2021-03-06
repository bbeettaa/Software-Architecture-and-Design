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
    public class Nature : Locality
    {
        private int comfort = 0;

        public Nature() : base()
        {
            owner = new MotherNature();
        }

        public Nature(Owner owner) : base(owner) { }

        public Nature(byte polution, byte foodAmountPercent):this()
        {
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
            int chance = random.Next(39, 44);
            chance += animal.GetAgility() / 10;
            chance += animal.GetEnergy() / 10;
            chance += animal.GetHealth() / 10;
            chance += 10 - animal.GetSatiety() / 10;
            chance += (int)(chance + foodAmountPercent)/5;

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
            this.foodAmountPercent = foodAmount;
        }


        public override String ToString() { 
            String str = $"{this.GetType().Name}, Polution - {polution}%, FoodAmount - {string.Format("{0:N2}", foodAmountPercent)}%, Comfor - {comfort}   ";
            return str;
        }

        override public Owner GetOwner()
        {
            return owner;
        }

    }
}
