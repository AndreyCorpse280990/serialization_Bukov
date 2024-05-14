using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace serialization_Bukov
{
    [Serializable]
    public class People
    {
        public List<Person> Persons { get; set; }

        // JSON формат
        public static void SerializationJson(People people, string path)
        {
            string json = JsonConvert.SerializeObject(people, Formatting.Indented);
            File.WriteAllText(path, json);
            Console.WriteLine("Объект записан в JSON файл.");
        }

        public static People DeserializationJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<People>(json);
        }

        // Бинарный формат
        public static void SerializationBinary(People people, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, people);
            }
            Console.WriteLine("\n\nОбъект записан в бинарный файл.");
        }

        public static People DeserializationBinary(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (People)formatter.Deserialize(stream);
            }
        }

        // XML формат
        public static void XmlSerialization(People people, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(People));
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(stream, people);
                Console.WriteLine("\n\nОбъект записан в XML файл.");
            }
        }

        public static People XmlDeserialization(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(People));
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (People)xmlSerializer.Deserialize(stream);
            }
        }
        
        //Soap формат
        public static void SoapSerialization(People people, string path)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, people);
                Console.WriteLine("\n\nОбъект записан в Soap файл.");
            }
        }

        public static People SoapDeserialization(string path)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (People)formatter.Deserialize(stream);
            }
        }

        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }
    }
}
