using BLL.Classes.Localities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Owners
{
    class Man : Owner
    {
        private int foodIncreasePercent = 81;
        private int polutionClean;

        public Man()
        {
            Random random = new Random();
            polutionClean = 5; //random.Next(1, 15);
        }
        public void Update(ILocality locality)
        {
            if (locality is null) { throw new ArgumentNullException(nameof(locality)); }
            if (locality.GetPolution() > 10) { locality.SetPolution(CleanPolution(locality.GetPolution())); }
            if (locality.GetFoodAmountPercent() < 50) locality.SetFoodAmountPercent(SetFoodIncreasePercent(locality.GetFoodAmountPercent()));
        }
        public int SetFoodIncreasePercent(float percent)
        {
            return foodIncreasePercent;
        }
        public int CleanPolution(int polution)
        {
            return (polution - polutionClean);
        }
        public override String ToString()
        {
            return $"{this.GetType().Name}: food increase {foodIncreasePercent}%, polution clean {polutionClean}%";
        }
    }
}
