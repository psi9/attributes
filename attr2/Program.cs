﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace attr2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a new TestSimpleObject object.
            TestSimpleObject obj = new TestSimpleObject();

            Console.WriteLine("Before serialization the object contains: ");
            obj.Print();

            // Opens a file and serializes the object into it in binary format.
            Stream stream = File.Open("data.xml", FileMode.Create);
            var formatter = new BinaryFormatter();

            //BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            stream.Close();

            // Empties obj.
            obj = null;

            // Opens file "data.xml" and deserializes the object from it.
            stream = File.Open("data.xml", FileMode.Open);
            formatter = new BinaryFormatter();

            //formatter = new BinaryFormatter();

            obj = (TestSimpleObject)formatter.Deserialize(stream);
            stream.Close();

            Console.WriteLine("");
            Console.WriteLine("After deserialization the object contains: ");
            obj.Print();
        }
    }

    [Serializable]
    public class TestSimpleObject
    {

        public int member1;
        public string member2;
        public string member3;
        public double member4;

        // A field that is not serialized.
        [NonSerialized] public string member5;

        public TestSimpleObject()
        {

            member1 = 11;
            member2 = "hello";
            member3 = "hello";
            member4 = 3.14159265;
            member5 = "hello world!";
        }

        public void Print()
        {

            Console.WriteLine("member1 = '{0}'", member1);
            Console.WriteLine("member2 = '{0}'", member2);
            Console.WriteLine("member3 = '{0}'", member3);
            Console.WriteLine("member4 = '{0}'", member4);
            Console.WriteLine("member5 = '{0}'", member5);
        }
    }
}
