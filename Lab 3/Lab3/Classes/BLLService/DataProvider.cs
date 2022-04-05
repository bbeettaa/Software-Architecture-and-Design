using BLL.Classes.Animals;
using DAL.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes.BLLService
{
    public abstract class DataProvider
    {
        protected String fileName = "";
        protected String configFile = "";
        protected String configDir;
        protected Packet packet = new();

        public DataProvider() {
            configDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //fileName = "jsonFileName.xml";

            configDir = configDir.Replace("Program\\bin\\Debug\\net5.0", "");
            configDir = configDir.Replace("\\bin\\Debug\\net5.0", "");
            int pos = configDir.LastIndexOf("\\");
            configDir = configDir.Remove(pos, configDir.Length - pos);




        }

        abstract public void Serialize(Packet packet);
        abstract public Packet Deserialize();

        public void SaveListToPacket(Packet packet)
        {
           // this.packet = packet;
        }
        public void SetFileName(String fileName)
        {
            this.fileName = fileName;
            CheckFile();
        }
        public bool CheckFile()
        {
            if (!File.Exists(configFile))
                CreateFile();
            
            
            return true;
        }
        public void CreateFile()
        {
            FileStream file = new(configFile, FileMode.Create);
            StreamWriter writer = new(file, Encoding.Unicode);
            writer.Close();
            file.Close();

//           packet = new();
            this.Serialize(new Packet());

/*            String firstLine = File.ReadAllLines(fileName)[0];
            if (!firstLine.Contains("<?xml version=\"1.0\""))
            {
                packet = new List<Animal>();
                Serialize();
            }*/
        }
    }
}
