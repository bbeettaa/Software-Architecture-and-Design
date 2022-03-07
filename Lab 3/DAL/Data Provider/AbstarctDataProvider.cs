using DAL_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace DALWorckWithDataBases
{
    public abstract class AbstarctDataProvider
    {
        protected String fileName = "";
        protected Packet packet = new();

        virtual public void Serialize() { }
        virtual public List<Object> Deserialize() { return null; }
        public void SaveListToPacket(List<Object> objList)
        {
            packet.Reset();
            foreach (var obj in objList)
                packet.AddToPacket(obj);
        }
        public void SetFileName(String fileName)
        {
            this.fileName = fileName;
            CheckFile();
        }
        public bool CheckFile()
        {
            if (!File.Exists(fileName))
            {
                return false;
            }
            return true;
        }
        public void CreateFile()
        {
            FileStream file = new(fileName, FileMode.Create);
            StreamWriter writer = new(file, Encoding.Unicode);
            writer.Close();
            file.Close();

            packet = new Packet();
            Serialize();

            String firstLine = File.ReadAllLines(fileName)[0];
            if (!firstLine.Contains("<?xml version=\"1.0\""))
            {
                packet = new Packet();
                Serialize();
            }
        }
    }
}
