using BLL.Новая_папка;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL.Classes.Animals
{

    [Serializable]
    public class Cat : Animal
    {
        [NonSerialized]
        private IMoveState runState;
        [NonSerialized]
        private IMoveState walkState;
        [NonSerialized]
        private IMoveState crawlState;

        public Cat() : this("new_Cat")
        {

        }
        public Cat(String name) : base(name) {
            runState = new RunState();
            walkState = new WalkState();
            crawlState = new CrawlState();
        }
        [System.STAThread]
        public override void Update(object source, SimulationEventArgs e)
        {
            if (!isAlive) return;
            bool criticalState = isCriticalState();
           

            locality.Notify();
            if (e.Time >= sleepTime || e.Time <= wakeupTime) Sleep();//18000 - evening, 6000 - morning
            else if (isSleep) WakeUp();
            else if (energy <= 0) {
                move = null;
                Sleep();
            }
            //forced to survive
            else if (criticalState)
            {
                if (isSleep) WakeUp();
                if (hunger <= 75 && energy > 0 && canFeed) { ChangeMoveState(); Feeding(); }
                else if (energy <= 75) {  Sleep(); }
            }
            //wiling
            else if (!isSleep && !criticalState)
            {
                if (hunger < 80 && canFeed)
                    Feeding();
                else if (energy > 0)
                    WalkAround();
                

            }
            // sleep
            else if (isSleep && energy > 0)
            {
                Sleep();
            }

            if (health <= 0) Death();
            else if (hunger <= 0)
            {
                health -= 10;
            }
            if (e.Time == 0)
                history.Add($"New day {++daysAlive}");

            if (energy > 100) energy = 100;
            //energy = ((int)(energy * energySabeModify));
            // base.Update(publisher);
        }

        public void WalkAround() {
            Walk();
            energy = (int)(energy * energySaveModify / SpeedUp);
            //System.Diagnostics.Debug.WriteLine("Walking around territory");
            history.Add("Walking around territory");
        }
        public override void Sleep() {
            Crawl();
            base.Sleep();
        }

        public void ChangeMoveState() {
            if (Run()) return;
            else if (Walk()) return;
            else if (Crawl()) return;
        }

        public bool Crawl()
        {
                move = crawlState;
                energySaveModify = 0.95f;
                agility = 60;
                return true;
        }
        public bool Walk()
        {
            if (energy > 25)
            {
                move = walkState;
                energySaveModify = 0.93f;
                agility = 40;
                return true;
            }
            return false;
        }
        public bool Run()
        {
            if (energy >= 40)
            {
                move = runState;
                energySaveModify =0.9f;
                agility = 70;
                return true;
            }
            return false;
        }

        public override String ToString()
        {
            return String.Format("{0}: {1}, days alive - {2}, ({3}), {4}",
this.GetType().Name, this.name, daysAlive, this.locality.GetType().Name, (this.isAlive) ? "alive" : "dead ");
        }
    }
}
