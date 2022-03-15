using BLL.Classes.Localities;
using Lab3.Classes.Event;
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

        public Man(Locality locality)
        {
            Random random = new Random();
            polutionClean = random.Next(1, 15);

            locality.OnChangeHandler += 
                new Locality.ChangeEventHandler(Update);
        }
        public void Update(object source, LocalityEventArgs e)
        {
            if (source is null) { throw new ArgumentNullException(nameof(source)); }
            if (e.Polution > 10) (source as Locality).SetPolution(CleanPolution(e.Polution));
            if (e.FoodAmount < 50) (source as Locality).SetFoodAmountPercent(SetFoodIncreasePercent(e.FoodAmount));
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
