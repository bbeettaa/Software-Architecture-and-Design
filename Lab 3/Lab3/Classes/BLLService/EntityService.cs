using BLL.Bll;
using BLL.Classes.Builder;
using BLL.Новая_папка;
using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace BLL.Classes.BLLService
{
    public class EntityService : Service
    {
        Packet packet;
        object locker = new();
        public EntityService(Simulation simulation, ChangeState changeState, Director director, DataProvider dataProvider) : 
            base(simulation,changeState, director, dataProvider)
        {
            simulation.StartNotify();
            SetAnimalFromRepository();

            Timer timer = new Timer();
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Interval = 5000;
            timer.Enabled = true;

            packet = new();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            lock (locker)
            {
                SaveObjs();
            }
        }

        override public void DeleteAnimal(int numberObject)
        {
            simulation.GetAnimals().RemoveAt(numberObject);
        }

        override public List<Animal> GetAnimals()
        {
            return simulation.GetAnimals();
        }

        override public List<Type> GetAssemblyTypesAnimal()
        {
            List<Type> list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "BLL.Classes.Animals").ToList();
            list.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
            list = (from x in list where !typeof(Animal).Name.Contains(x.Name) select x).ToList();
            list = (from x in list where !x.Name.Contains("<>c") select x).ToList();

            return list;
        }

        override public void AppendObject(int numberObj, int localityType, String name)
        {
            List<Type> list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "BLL.Classes.Builder").ToList();
            list = (from x in list where !typeof(Director).Name.Contains(x.Name) select x).ToList();
            list = (from x in list where !typeof(IBuilder).Name.Contains(x.Name) select x).ToList();
            list = (from x in list where !x.Name.Contains("<>c") select x).ToList();

            if (localityType >= 0 && localityType <= 1)
            {
                var obj = Activator.CreateInstance(list[numberObj]);
                switch (localityType)
                {
                    case 0:
                        simulation.AddAnimal(director.BuildHomeAnimal((IBuilder)obj, name));
                        break;
                    case 1:
                        var obj1 = director.BuildWildAnimal((IBuilder)obj, name);
                        simulation.AddAnimal(obj1);
                        break;
                }
            }
        }

        override public void SaveObjs()
        {
            List<Animal> anims = simulation.GetAnimals();
            packet.SetToPacket(anims);
            dataProvider.Serialize(packet);
        }

        override public void LoadObjs()
        {
            dataProvider.Deserialize();
        }

        public void SetAnimalFromRepository() {

            foreach (var obj in dataProvider.Deserialize().getList())
                obj.SubscribeOnEvent();

            simulation.SetAnimals(dataProvider.Deserialize().getList());
        }


    }
}
