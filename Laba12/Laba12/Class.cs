using System;

namespace Laba12
{
    interface IPref
    {
        // отношение животного к чему-то 
        //(типа: любит сырую картошку => attitude - "любит", smth - "сырую картошку")
        void pref(string attitude, string smth);
    }

    class Animal : IPref
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal(string type, string name, int age)
        {
            Type = type;
            Name = name;
            Age = age;
        }

        public Animal() { }

        public void pref(string attitude, string smth)
        {
            Console.WriteLine($"{Type} {Name} {attitude} {smth}");
        }
    }
}
