using BLL.Classes.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Localities
{
    class Home : ILocality
    {
        public Man owner = new Man();
        private int polution = 0;
        private int foodAmountPercent = 0;
        private int comfort = 0;

        public Home() { }
        public Home(byte polution, byte foodAmountPercent) {
            this.polution = polution;
            this.foodAmountPercent = foodAmountPercent;
        }

        public int CountComfortPercent()
        {
            comfort = (foodAmountPercent-polution );
            return comfort;
        }

        public int Feeding(Animal animal)
        {
            Random random = new Random();
            int chance = random.Next(50, 70);
            chance += animal.GetAgility() / 15;
            chance += animal.GetEnergy() / 15;
            chance += animal.GetHealth() / 15;
            chance += 10 - animal.GetSatiety() / 15;
            chance += foodAmountPercent / 15;

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

        public int Sleep()
        {
            CountComfortPercent();
            return (comfort % 100);
        }


        public void Notify()
        {
            CountComfortPercent();
            owner.Update(this);
        }


        public int GetPolution()
        {
            return this.polution;
        }

        public void SetPolution(int polution)
        {
            this.polution = polution;
        }

        public float GetFoodAmountPercent()
        {
            return this.foodAmountPercent;
        }

        public void SetFoodAmountPercent(float foodAmount)
        {
            this.foodAmountPercent = (int)foodAmount;
        }


        public override String ToString() { return $"{this.GetType().Name}, Polution - {polution}%, FoodAmount - {foodAmountPercent}%, Comfor - {comfort}   "; }

        public Owner GetOwner()
        {
            return owner;
        }

    }
}
