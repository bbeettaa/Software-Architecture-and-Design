using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes.Event
{
    public class SimulationEventArgs : EventArgs
	{
		public int Time { get; private set; }
		public SimulationEventArgs(int time)
		{
			this.Time = time;
		}

	}
}
