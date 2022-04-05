using BLL.Classes;
using BLL.Classes.Animals;
using BLL.Classes.BLLService;
using DAL_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DAL.Classes {
    public class JsonProvider : DataProvider
    {
        //Settings//
        readonly String configDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        readonly string configName = "\\settings.json";

        JsonSerializerOptions options;

        public JsonProvider()
        {
            //configName = configDir + configName;
            options = new JsonSerializerOptions { WriteIndented = true };
        }
        
        override public void Serialize(Packet packet)
        {
            string jsonString = JsonSerializer.Serialize(packet, options);


            File.WriteAllText(configFile, jsonString);

        }
        override public Packet Deserialize()
        {
            CheckFile();
            string jsonString = File.ReadAllText(configFile);
            if (jsonString != "")
                packet = JsonSerializer.Deserialize<Packet>(jsonString,options);

            return packet;
        }
    
        public void SaveSettings(Settings settings)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, };
            string jsonString = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(configName, jsonString);
        }
        public Settings LoadSettings()
        {
            string jsonString = File.ReadAllText(configName);
            Settings settings = JsonSerializer.Deserialize<Settings>(jsonString);

            return settings;
        }

    }
}
