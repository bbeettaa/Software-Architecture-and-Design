using BLL.Новая_папка;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.Animals
{
    class Cat : Animal
    {
        
        private IMoveState runState { get; set; } = new RunState();
        private IMoveState walkState { get; set; } = new WalkState();
        private IMoveState crawlState { get; set; } = new CrawlState();


        public Cat(String name): base(name) { 
        
        }

        public override void Update(Simulation publisher)
        {
            if (!isAlive) return;
            bool criticalState = isCriticalState();
           


            locality.Notify();
            if (publisher.GetTime() >= sleepTime || publisher.GetTime() <= wakeupTime) Sleep();//18000 - evening, 6000 - morning
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
            if (publisher.GetTime() == 0)
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
