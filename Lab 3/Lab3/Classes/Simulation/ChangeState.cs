using BLL.Classes;
using BLL.Новая_папка;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Bll
{
    public class ChangeState
    {
        double speed = 1000;
        bool canFeed = true;
        bool pause = false;
        Simulation sim;

        public ChangeState(Simulation sim) {
            this.sim = sim;
        }

        public void ChangeCanFeed(Animal animal) {
            canFeed = !canFeed;
            animal.canFeed = canFeed;
        }

        public void FeedOn_10_Point(Animal animal)
        {
            animal.Feeding(10);
        }

        public void SpeedUp() {
            speed -= 100;
            if (speed <= 0)
                speed = 100;
            sim.ChangeSpeed(speed);
        }
        public void SlowDown() {
            sim.ChangeSpeed(speed += 100);
        }

        public void Pause() {
            pause = !pause;
            if(pause)
            sim.ChangeSpeed(int.MaxValue);
            else
                sim.ChangeSpeed(speed);
        }

        public List<String> GetMethodsAndValues() {
            List<String> str = new List<String>();
            MethodInfo[] m = typeof(ChangeState).GetMethods();
            List<FieldInfo> f = typeof(Animal).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetField).ToList();
            foreach (var method in m)
                str.Add(method.Name);

            str.Add(canFeed.ToString());
            str.Add(speed.ToString());
            str.Add(pause.ToString());
            return str;

        }
    }
}
