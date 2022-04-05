using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter formatter = new();
            Stream stream = new FileStream("testXml.dat", FileMode.Create, FileAccess.Write);
#pragma warning disable SYSLIB0011 // Тип или член устарел
            formatter.Serialize(stream, new Home(new Animal(), new Cat("ca",228,1110)));
#pragma warning restore SYSLIB0011 // Тип или член устарел
            stream.Close();



            FileStream fs = new("testXml.dat", FileMode.Open, FileAccess.Read);
            IFormatter formatter1 = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Тип или член устарел
            Home packet = (Home)formatter1.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Тип или член устарел
            fs.Close();


            Console.WriteLine(String.Format("Home: {0}\nAnima: {1}\tName: {2}\nCat: {3}\tName: {4}\tAge: {5}\nBrain: {6}\n", 
                packet.GetType().Name,
                packet.animal.GetType().Name, packet.animal.name, 
                packet.cat.GetType().Name, packet.cat.name, packet.cat.getAge(),
                packet.brain.GetType().Name)) ;
            Console.ReadKey();
        }

        [Serializable]
        public class Animal {
            public String name;
            [XmlIgnore]
            [SoapIgnore]
            [IgnoreDataMember]
            private int age;
            public Animal(String str,int age) {
                name = str;
                this.age = age;
            }
            public Animal() : this("Animal", 11) { }
            public int getAge() {
                return age;
            }
        }

        [Serializable]
        public class Cat:Animal
        {
            public int paws;
            public Cat(String str, int age, int paws):base(str,age)
            {
                this.paws = paws;
            }
            public Cat() : this("Cat1", 0,4) { }

        }


        public interface Brain {
            public void Think();
        }

        [Serializable]
        public class CurBrain : Brain {
            public int think = 4;
            public CurBrain() { }

            public void Think()
            {
                throw new NotImplementedException();
            }
        }

        [Serializable]
        public class Home {
            public Cat cat;
            public Animal animal;
            public Brain brain ;
            public Home() {
                brain = new CurBrain();
                cat = new();
                animal = new();
                Console.WriteLine("Base");
            }

            public Home(Animal animal, Cat cat):this() {
                this.animal = animal;
                this.cat = cat;
            }

        }

    }
}
