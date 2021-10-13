using System;
using static Laba4.Program; //для Set !!!

namespace Laba4
{
        //класс Owner
        public class Owner
        {
            readonly int id = 8;
            readonly string name = "Софья";
            readonly string organization = "БГТУ";

            //конструкторы
            public Owner(int id, string name, string organization)
            {
                this.id = id;
                this.name = name;
                this.organization = organization;
            }

            public Owner() { }

            //метод для вывода значения полей объекта типа Owner
            public void Print()
            {
                Console.WriteLine($"\nid : {this.id}\n" +
                    $"name : {this.name}\n" +
                    $"organization : {this.organization}\n");
            }
        }

    //статический класс StatisticOperation с тремя методами для работы со множеством
    static class StatisticOperation
    {
        public static int Sum(Set set)
        {
            int sum = 0;
            foreach(int el in set.Data) 
            { 
                sum += el;
            }
            return sum;
        }

        public static int MaxMinDiff(Set set)
        {
            int min = set.Data[0];
            int max = set.Data[0];

            foreach(int el in set.Data)
            {
                if (el < min) { min = el; }
                if (el > max) { max = el; }
            }

            return max - min;
        }

        public static int AmountOfEls(Set set)
        {
            return set.Data.Count;
        }
    }
}
