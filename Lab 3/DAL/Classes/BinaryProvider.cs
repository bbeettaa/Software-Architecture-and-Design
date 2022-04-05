using BLL.Classes;
using DAL_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using BLL.Classes.BLLService;
using BLL.Classes.Animals;

namespace DAL.Classes
{
    public class BinaryProvider : DataProvider
    {
        public BinaryProvider():base()
        {
            fileName = "jsonFileName.dat";
            configFile = configDir + "\\" + fileName;
            packet = new ();
        }
        override public void Serialize(Packet packet)
        {
            /*
                            BinaryFormatter formatter = new();
                            Stream stream = new FileStream(configFile, FileMode.Create, FileAccess.Write);
            #pragma warning disable SYSLIB0011 // Тип или член устарел
                            formatter.Serialize(stream, packet);
            #pragma warning restore SYSLIB0011 // Тип или член устарел

                            stream.Close();
            */
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(configFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, packet);
            }

        }
        override public Packet Deserialize()
        {
            CheckFile();
                FileStream fs = new(configFile, FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Тип или член устарел
                packet = (Packet)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Тип или член устарел
                fs.Close();

            return packet;
        }
    }
}
