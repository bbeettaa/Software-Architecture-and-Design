using BLL.Classes.Localities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Owners
{
    class MotherNature : Owner
    {
        private float foodIncreasePercent;
        private float foodIncrease = 0;
        private int polutionClean = 11;
        Random random;
        public MotherNature() {
            random = new Random(8);
            foodIncreasePercent = (float)((float)random.NextDouble() * (0.62 - 0.58) + 0.61);
        }

        public void Update(ILocality locality)
        {
            if (locality is null) { throw new ArgumentNullException(nameof(locality)); }
            if(locality.GetPolution()>0) locality.SetPolution(CleanPolution(locality.GetPolution())); 
            if(locality.GetFoodAmountPercent()<100) locality.SetFoodAmountPercent(SetFoodIncreasePercent(locality.GetFoodAmountPercent()));
        }
        public float SetFoodIncreasePercent(float percent)
        {
            System.Diagnostics.Debug.WriteLine((float)(foodIncreasePercent - percent / 10 * 0.1));
            return percent  + (float)(foodIncreasePercent - percent / 10 * 0.02);
        }
        public int CleanPolution(int polution)
        {
            Random random = new Random();
            polutionClean = 10;//(byte)random.Next(5, 15);
            return polution - polutionClean;
        }
        public override String ToString()
        {
            return $"{this.GetType().Name}: food increase {string.Format("{0:N2}", foodIncreasePercent)}%, polution clean {polutionClean}%";
        }
    }
}
