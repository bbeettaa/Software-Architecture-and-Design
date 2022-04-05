using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes.Event
{
	public class LocalityEventArgs : EventArgs
	{
		public int Polution { get; private set; }
		public float FoodAmount { get; private set; }
		public LocalityEventArgs(int polution, float foodAmount)
		{
			this.Polution = polution;
			this.FoodAmount = foodAmount;
		}

	}
}
