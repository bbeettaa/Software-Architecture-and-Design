using BLL.Classes;

using BLL.Classes.Builder;
using Lab3.Classes.Event;
using System;
using System.Collections.Generic;
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
        System.Timers.Timer timer;
        static private Simulation instance;
        Object locker = new object();

        public Simulation() {
            instance = this;
            animals = new List<Animal>();
            /*          Director d = new Director();
                      animals.Add(d.BuildHomeAnimal(new CatBuilder(), "Cat 1"));
                      animals.Add(d.BuildWildAnimal(new CatBuilder(), "Cat 2"));*/

            timer = new Timer();
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = false;
            timer.Interval = this.speed;


        }

        public delegate void ChangeEventHandler(object source, SimulationEventArgs e);
        public event ChangeEventHandler OnChangeHandler;
        public void Notify()
        {
            lock(locker){

                if (time >= 24_000) time = 0;

                OnChangeHandler?.Invoke(this, new SimulationEventArgs(time));
                time += hour;
            }
        }

        public static Simulation GetInstance() {
            return instance;
        }

        public void ChangeSpeed(double speed) {
            if (speed <= 0)
                speed = 100;
            timer.Interval = speed;
        }

        public int GetTime() { return time; }

        public List<Animal> GetAnimals() { return animals; }
        public void SetAnimals(List<Animal> animals) { this.animals = animals; }

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
