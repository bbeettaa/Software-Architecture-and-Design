using BLL.Classes;
using BLL.Classes.Animals;
using BLL.Classes.BLLService;
using DAL_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// внутринее исключение xml - файл не являеться xml - пересоздать его с потерей данних

namespace DAL.Classes
{
    public class XML_Provider : DataProvider
    {

        public XML_Provider():base()
        {
            packet = new ();
        }
        override public void Serialize(Packet packet)
        {
            CheckFile();
            packet.SetToPacket(new List<Animal> { new Cat()});
            TextWriter twr = new StreamWriter(fileName);
            XmlSerializer writer = new (typeof(Packet));

            writer.Serialize(twr, packet);
            twr.Close();
        }
        override public Packet Deserialize()
        {
            CheckFile();
            XmlSerializer serializer = new XmlSerializer (typeof(Packet));
            FileStream fs = new (fileName, FileMode.Open);
            Packet packet = (Packet)serializer.Deserialize(fs);

            fs.Close();
            return packet;
        }
       
    }
}



