using BLL.Classes.Localities;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Classes.Owners
{
    [Serializable]
    public class MotherNature : Owner
    {
        public MotherNature():base() { 
       // public MotherNature(Locality locality)
        
            random = new Random(8);
            foodIncreasePercent = (float)((float)random.NextDouble() * (0.62 - 0.58) + 0.61);
          //locality.OnChangeHandler += new Locality.ChangeEventHandler(Update);
        }

       override public void Update(object source, LocalityEventArgs e)
        {
            if (source is null) { throw new ArgumentNullException(nameof(source)); }
            if(e.Polution>0) (source as Locality).SetPolution(CleanPolution(e.Polution)); 
            if(e.FoodAmount<100) (source as Locality).SetFoodAmountPercent(SetFoodIncreasePercent(e.FoodAmount));
        }
        public float SetFoodIncreasePercent(float percent)
        {
            //System.Diagnostics.Debug.WriteLine((float)(foodIncreasePercent - percent / 10 * 0.1));
            return percent + (float)(foodIncreasePercent - percent / 10 * 0.02);
        }
        public int CleanPolution(int polution)
        {
            Random random = new Random();
            polutionClean = 10;
            return polution - polutionClean;
        }
        public override String ToString()
        {
            return $"{this.GetType().Name}: food increase {string.Format("{0:N2}", foodIncreasePercent)}%, polution clean {polutionClean}%";
        }
    }
}
