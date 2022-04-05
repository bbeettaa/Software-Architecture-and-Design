using BLL.Bll;
using BLL.Classes.Builder;
using BLL.Новая_папка;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.BLLService
{
    public abstract class Service
    {
        public Simulation simulation;
        public ChangeState changeState;
        public Director director;
        public DataProvider dataProvider;

        public Service(Simulation simulation, ChangeState changeState, Director director, DataProvider dataProvider)
        {
            this.simulation = simulation;
            this.changeState = changeState;
            this.director = director;
            this.dataProvider = dataProvider;
        }

        abstract public List<Animal> GetAnimals();
        abstract public void AppendObject(int numberObj, int localityType, String name);
        abstract public void DeleteAnimal(int numberObject);
        abstract public List<Type> GetAssemblyTypesAnimal();
        abstract public void SaveObjs();
        abstract public void LoadObjs();

    }
}
