using DAL_Classes;
using ProgramClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DALWorckWithDataBases
{
    class BinaryProvider : AbstarctDataProvider
    {
        public BinaryProvider()
        {
            packet = new ();
        }
        override public void Serialize()
        {
            BinaryFormatter formatter = new();
            Stream stream = new FileStream (fileName, FileMode.Create, FileAccess.Write);
#pragma warning disable SYSLIB0011 // Тип или член устарел
            formatter.Serialize(stream, packet);
#pragma warning restore SYSLIB0011 // Тип или член устарел

            stream.Close();
        }
        override public List<Object> Deserialize()
        {
            FileStream fs = new (fileName, FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Тип или член устарел
            packet = (Packet)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Тип или член устарел
            fs.Close();

            return packet.GetList();
        }
    }
}
