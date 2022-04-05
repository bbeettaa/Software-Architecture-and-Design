using BLL.Classes;
using BLL.Classes.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Classes
{
    [Serializable]
    public class Packet
    {
        public List<Cat> cats;
        public List<Parrot> parrots;
        public List<Snake> snakes;

        public Packet() {
            reset();
        }

        public void SetToPacket(List<Animal> animals) {
            reset();
            foreach (var animal in animals)
                if (animal.GetType() == typeof(Cat))
                    cats.Add(animal as Cat);
                else if (animal.GetType() == typeof(Parrot))
                    parrots.Add(animal as Parrot);
                else if (animal.GetType() == typeof(Snake))
                    snakes.Add(animal as Snake);
        }

        public List<Animal> getList() {
            List<Animal> animals = new();
            cats.ForEach(animals.Add);
            parrots.ForEach(animals.Add);
            snakes.ForEach(animals.Add);
            return animals;
        }

        public void reset() {
            cats = new();
            parrots = new();
            snakes = new();
        }
    }
}
