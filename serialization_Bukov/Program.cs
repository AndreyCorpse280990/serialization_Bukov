using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace serialization_Bukov
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string pathJson = @"E:\programming\Visual Studio\repos\serialization_Bukov\serialization_Bukov\PersonJson.txt";
            string pathBinary = @"E:\programming\Visual Studio\repos\serialization_Bukov\serialization_Bukov\PersonBinary.txt";
            string pathXml = @"E:\programming\Visual Studio\repos\serialization_Bukov\serialization_Bukov\PersonXml.txt";
            string pathSoap = @"E:\programming\Visual Studio\repos\serialization_Bukov\serialization_Bukov\PersonSoap.txt";
            People people = new People();

            people.Persons = new List<People.Person>
            {
                new People.Person() { Name = "John", Age = 20, Gender = "Male" },
                new People.Person() { Name = "Mary", Age = 21, Gender = "Female" },
                new People.Person() { Name = "Peter", Age = 22, Gender = "Male" }
            };

            // JSON формат
            People.SerializationJson(people, pathJson);
            Console.WriteLine("Недесериализованные данные из JSON файла: ");
            Console.WriteLine(File.ReadAllText(pathJson));

            People deserializedPeople = People.DeserializationJson(pathJson);

            Console.WriteLine("Десериализованные данные из JSON файла: ");
            foreach (var person in deserializedPeople.Persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Gender: {person.Gender}");
            }

            // Бинарный формат
            People.SerializationBinary(people, pathBinary);
            Console.WriteLine("Недесериализованные данные из бинарного файла: ");
            Console.WriteLine(File.ReadAllText(pathBinary));
            People binaryDeserialized = People.DeserializationBinary(pathBinary);

            Console.WriteLine("Десериализованные данные из бинарного файла: ");
            foreach (var person in binaryDeserialized.Persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Gender: {person.Gender}");
            }

            // XML формат
            People.XmlSerialization(people, pathXml);
            Console.WriteLine("Недесериализованные данные из XML файла: ");
            Console.WriteLine(File.ReadAllText(pathXml));
            People xmlDeserialized = People.XmlDeserialization(pathXml);

            Console.WriteLine("Десериализованные данные из XML файла: ");
            foreach (var person in xmlDeserialized.Persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Gender: {person.Gender}");
            }
            
            //Soap формат
            People.SoapSerialization(people, pathSoap);
            Console.WriteLine("Недесериализованные данные из Soap файла: ");
            Console.WriteLine(File.ReadAllText(pathSoap));
            People.SoapDeserialization(pathSoap);
            People soapDeserialized = People.SoapDeserialization(pathSoap);
            Console.WriteLine("Десериализованные данные из Soap файла: ");
            foreach (var person in soapDeserialized.Persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Gender: {person.Gender}");
            }
        }
    }
}
    