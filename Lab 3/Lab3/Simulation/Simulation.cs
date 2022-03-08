using BLL.Classes;

using BLL.Classes.Builder;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace BLL.Новая_папка
{
    public class Simulation
    {
        //public int speedUp { get;private set; } = 1;
        private int hour = 1000;
        private int speed = 1000;
        private int time = 0; // max 24 000
        private List<Animal> animals;
        System.Timers.Timer timer = new System.Timers.Timer();

        public Simulation() {
            animals = new List<Animal>();
            Director d = new Director();
            animals.Add(d.BuildHomeAnimal(new CatBuilder(),"Cat 1"));
            animals.Add(d.BuildWildAnimal(new CatBuilder(), "Cat 2"));
            //animals.Add(d.BuildHomeAnimal(new CatBuilder()));

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = false;
            timer.Interval = this.speed;
        }

        public void ChangeSpeed(double speed) {
            if (speed <= 0)
                speed = 100;
            timer.Interval = speed;
        }

        public int GetTime() { return time; }

        public List<Animal> GetAnimals() { return animals; }

        public void Notify()
        {
            if (time >= 24000) time = 0;

            foreach (var animal in animals)
            {
                animal.Update(this);
            }
            time += hour;  
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Notify();
        }

        public void StartNotify() {
            timer.Enabled = true;
        }
        public void StopNotify() {
            timer.Enabled = false;
        }

        public void AddAnimal(Animal animal) {
            animals.Add(animal);
        }
    }
}
