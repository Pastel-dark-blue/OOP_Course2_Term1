using System;

namespace Laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionType<Advertising> collection = new CollectionType<Advertising>();

            Advertising[] ads =
            {
                new Advertising("1ad"),
                new Advertising("2ad"),
                new Advertising("3ad"),
                new Advertising("4ad"),
            };

            foreach(Advertising el in ads)
            {
                collection.Add(el);
            }

            Console.WriteLine("Коллекция: ");
            collection.View();

            collection.Remove(new Advertising("3ad"));

            Console.WriteLine("\nКоллекция после удаления 3ad : ");
            collection.View();

            Console.WriteLine("\nЗапись в файл");
            collection.WriteFile();
            Console.WriteLine("\nЧтение из файла");
            collection.ReadFile();
        }
    }
}
