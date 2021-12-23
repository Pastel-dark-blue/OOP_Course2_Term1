using System;

namespace Laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|||| Запись информации о типах в файлы ||||\n");
            Reflector.WriteInfoToFile("Laba12.Animal", typeof(string), @"D:\ООП_2к_1с\Laba12\infoAnimal.txt");
            Reflector.WriteInfoToFile("System.String", typeof(int), @"D:\ООП_2к_1с\Laba12\infoString.txt");

            Console.WriteLine("\n|||| Создание экземпляра типа с помощью поиска " +
                "наиболее подходящего конструктора (в соответствии с переданными параметрами) ||||\n");
            Animal animal = Reflector.Create("Laba12.Animal", new object[] { "кролик", "Станислав", 2 })
                as Laba12.Animal;
            Console.WriteLine("Тип животного : " + animal.Type);
            Console.WriteLine("Имя : " + animal.Name);
            Console.WriteLine("Возраст : " + animal.Age);

            Console.WriteLine("\n|||| Передача методу значений, считанных из файла ||||\n");
            Animal dog = new Animal("собака", "Лика", 10);
            Reflector.Invoke(dog, "Laba12.Animal", "pref", @"D:\ООП_2к_1с\Laba12\parameters.txt");
        }
    }
}