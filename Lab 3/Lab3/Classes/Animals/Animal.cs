using BLL.Classes.Localities;
using BLL.Новая_папка;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    abstract public class Animal
    {
        protected String name = "Animal";
        protected int daysAlive = 0;
        protected bool isAlive = true;
        protected bool isSleep = false;
        protected int health = 100;
        protected int energy = 100;
        protected float energySaveModify { get; set; } = 1;
        protected int hunger = 100;
        protected int agility { get; set; } = 0; // max 100
        protected int happiness = 0;

        protected String voice;
        protected int wakeupTime { get; set; } = 7000;//18000 - evening, 6000 - morning
        protected int sleepTime { get; set; } = 18000;
        protected int SpeedUp { get; set; } = 1;

        public bool canFeed { get; set; } = true;

        public IMoveState move;
        public Locality locality;
        public History history { get; set; } = new History();

        public Animal(string name)
        {
            this.name = name;

            Simulation.GetInstance().OnChangeHandler +=
            new Simulation.ChangeEventHandler(Update);
        }

        abstract public void Update(object source, SimulationEventArgs e);

        public List<Object> getAllInfo()
        {
            List<Object> info = new List<Object>();
            List<FieldInfo> fieldName = typeof(Animal).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetField  ).ToList();
            fieldName = (from x in fieldName where x.CustomAttributes.Count() != 2 select x).ToList();
            List<Object> fieldInfo = new List<Object>();

            foreach (var field in fieldName)
            {
                info.Add(field.Name);
                info.Add(field.GetValue(this));  
            }
            return info;
        }

        public void SetMoveState(IMoveState moveState) { }
        public String Voice() { return voice; }
        virtual public void Sleep() {
            BioProcess();
            _ = (energy < 100) ? energy += locality.Sleep() + SpeedUp : energy += 0;
            isSleep = true;
            //System.Diagnostics.Debug.WriteLine("Sleep");
            history.Add("Sleep");
        }
        public void WakeUp()
        {
            //System.Diagnostics.Debug.WriteLine("Waked");
            history.Add("Waked");
            BioProcess();
            isSleep = false;
        }
        public void Feeding() {
            BioProcess();
            _ = (energy > 0) ? energy = (int)(energy * energySaveModify - 3) : energy += 0;
            hunger += locality.Feeding(this) * SpeedUp;
            history.Add("Feeding");
        }
        public void Feeding(int point)
        {
            BioProcess();
            _ = (energy > 0) ? energy = (int)(energy * energySaveModify - 3) : energy += 0;
            hunger += 10;
            locality.Feeding(this);
            history.Add("Feeding 10 point");
        }


        public void BioProcess() {
            _ = (health < 100) ? health += 1 * SpeedUp : health += 0;
            _ = (energy < 100) ? energy += 1 * SpeedUp : energy += 0;
            _ = (hunger > 0) ? hunger -= 2 * SpeedUp : hunger += 0;
        }

        public void Death() { isAlive = false; }





        protected bool isCriticalState() {
            if (health <= 25) {
                System.Diagnostics.Debug.WriteLine("needed health");
                return true;
            }
            else if (energy <= 25) {
                System.Diagnostics.Debug.WriteLine("needed ener");
                return true;
            }
            else if (hunger <= 25) {
                System.Diagnostics.Debug.WriteLine("needed hun");
                return true;
            }
            return false;
        }

        public int GetAgility() { return this.agility; }
        public int GetEnergy() { return this.energy; }
        public int GetSatiety() { return this.hunger; }
        public int GetHealth() { return this.health; }


        public override String ToString() { return String.Format("{0}: {1}, days alive - {2}, ({3}), {4}",
            this.GetType().Name, this.name, daysAlive, this.locality.GetType().Name, (this.isAlive) ? "alive" : "dead");
        }
    }
}
