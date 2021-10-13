using System;
using System.Collections.Generic; //List<type_name>

namespace Laba4
{
    class Program
    {
        public class Set
        {
            //инициализация объекта типа Owner
            public Owner owner = new Owner();

            //------------------------------------------------------------------

            //конструкторы 
            public Set() {
                date = DateTime.Now;
            }
            public Set(List<int> data)
            {
                date = DateTime.Now;

                this.data = data;
            }

            private List<int> data = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            public List<int> Data
            {
                get { return data; }
                set { data = value; }
            }

            //------------------------------------------------------------------
            //Символы > и < напоминают мне символы включения в дискретной математике, так что это value1 < value2 - значит, что value2 включено в value1
            //а это value1 > value2 - значит, что value1 включено в value2

            //Проверка на подмножество
            //Множество subset принадлежит множеству set (является его подмножеством)
            //Если любой элемент множества subset также принадлежит множеству set
            public static bool operator <(Set set, Set subset)
            {
                int subset_length = subset.data.Count;
                int num_of_subset_elements_in_set = 0;
                //если в множестве data содержится число num, значит num принадлежит data
                foreach (int subset_item in subset.data)
                {
                    if (set.data.Contains(subset_item)) {
                        num_of_subset_elements_in_set++;
                    }
                }

                if (num_of_subset_elements_in_set == subset_length)
                {
                    return true;
                }

                return false;
            }
            //компилятор требует перегрузки аналогичной выше, но для >
            public static bool operator >(Set subset, Set set)
            {
                int subset_length = subset.data.Count;
                int num_of_subset_elements_in_set = 0;
                //если в множестве data содержится число num, значит num принадлежит data
                foreach (int subset_item in subset.data)
                {
                    if (set.data.Contains(subset_item))
                    {
                        num_of_subset_elements_in_set++;
                    }
                }

                if (num_of_subset_elements_in_set == subset_length)
                {
                    return true;
                }

                return false;
            }

            //------------------------------------------------------------------

            //Проверка на принадлежность
            //Число num принадлежит множеству set
            public static bool operator >(int num, Set set)
            {
                foreach (int item in set.data)
                {
                    if (num == item)
                    {
                        //если num содержится в set
                        return true; }
                }

                return false;
            }
            //компилятор требует перегрузки аналогичной выше, но для <
            public static bool operator <(int num, Set set)
            {
                foreach (int item in set.data)
                {
                    if (num != item)
                    {
                        //если num содержится в set
                        return false;
                    }
                }

                return true;
            }

            //------------------------------------------------------------------

            //Пересечение множеств
            //Возвращает массив из элементов общих для обоих множеств
            public static List<int> operator *(Set set1, Set set2)
            {
                List<int> intersection = new List<int> { };

                foreach (int item1 in set1.data)
                {
                    foreach (int item2 in set2.data)
                    {
                        if (item1 == item2)
                        {
                            intersection.Add(item1);
                        }
                    }
                }

                return intersection;
            }

            //------------------------------------------------------------------

            //перегрузка операции преобразования типов
            //явное приведение к типу DateTime
            //преобразует тип Set к типу DateTime, при этом в переменной сохраняется время создания объекта типа Set
            private DateTime date;
            public static explicit operator DateTime(Set set)
            {
                return set.date;
            }

            //------------------------------------------------------------------

            //вывод множества в виде { <элементы множества через запятую> }
            public void PrintSet()
            {
                Console.Write("{");
                foreach (int i in this.data)
                {
                    Console.Write(" " + i + " ");
                }
                Console.WriteLine("}");
            }

            //проверка перегруженнных операторов
            public static void OverloadOpTest(Set set1, Set set2, Set set3, int num)
            {
                Console.Write("set1 : ");
                set1.PrintSet();
                Console.Write("\nset2 : ");
                set2.PrintSet();
                Console.Write("\nset3 : ");
                set3.PrintSet();
                Console.Write($"\nnumber : {num}");

                Console.WriteLine("\n\n|||||||||||||||||||| проверка на принадлежность ||||||||||||||||||||");
                Console.WriteLine($"set1 принадлежит number (number < set1) : {num < set1}");
                Console.WriteLine($"number принадлежит set1 (number > set1) : {num > set1}");

                Console.WriteLine("\n|||||||||||||||||||| проверка на подмножество ||||||||||||||||||||");
                Console.WriteLine($"set1 является подмножеством set2 (set1 > set2) : {set1 > set2}");
                Console.WriteLine($"set3 является подмножеством set2 (set2 < set3) : {set2 < set3}");

                Console.WriteLine("\n|||||||||||||||||||| пересечение множеств ||||||||||||||||||||");
                Console.Write("пересечением множеств set1 и set2 является список (set1 * set2) : ");
                Console.Write("{");
                foreach (int i in set1 * set2)
                {
                    Console.Write(" " + i + " ");
                }
                Console.WriteLine("}\n");
            }

            //------------------------------------------------------------------

            //вложенный класс Date(дата создания)
            public class Date
            {
                public readonly DateTime dateOfCreation = DateTime.Now;
            }

            public Date dateObj = new Date();
        }


        static void Main(string[] args)
        {
            //вывод значения поля типа Owner множества Set
            Console.Write("------------- вывод значения поля типа Owner множества setOwnerCheck -------------");
            Set setOwnerCheck = new Set();
            setOwnerCheck.owner.Print();
            //------------------------------------------------------------------
            //вывод значения поля объекта типа Date множества setDateCheck
            Console.WriteLine("------------- вывод значения поля объекта типа Date множества setDateCheck -------------");
            Set setDateCheck = new Set();
            Console.WriteLine("Дата создания объекта dateObj класса Date, который вложен в класс Set : " + setDateCheck.dateObj.dateOfCreation);
            //------------------------------------------------------------------
            //явное приведение объекта типа Set к типу DateTime
            Console.WriteLine("\n------------- явное приведение объекта типа Set к типу DateTime -------------");
            Set explTypeCast = new Set();
            Console.WriteLine("Приведение (дата создания объекта типа Set) : "+ (DateTime)explTypeCast);
            //------------------------------------------------------------------
            //проверка перегруженнных операторов
            Console.WriteLine("\n------------- проверка перегруженнных операторов -------------");
            Set set1 = new Set(new List<int> { 1, 5, 6, 9, -7, 5, 34 });
            Set set2 = new Set(new List<int> { 4, 8, 6, -9, -4, 0, 34, 6 });
            Set set3 = new Set(new List<int> { 6, -9, -4, 34 });
            int num = 9;

            Set.OverloadOpTest(set1, set2, set3, num);
            //------------------------------------------------------------------
            //выделение первого числа из строки
            Console.WriteLine("-------------Выделение первого числа из строки-------------");
            Console.WriteLine($"ты предал христа : {"ты предал христа".FindFirstNum()}");
            Console.WriteLine($"aaabbb0111ccc34 : {"aaabbb0111ccc34".FindFirstNum()}");
            //------------------------------------------------------------------
            //Удаление положительных элементов из множества Set
            Console.WriteLine("\n-------------Удаление положительных элементов из множества Set-------------");
            Set set_pos_neg = new Set(new List<int> { -2, 5, 0, -2, 52, -7 });
            
            Console.Write("Удаление положительных элементов из множества : {");
            foreach(int i in set_pos_neg.Data)
            {
                Console.Write(" " + i + " ");
            }
            Console.WriteLine("}");

            Set set_pos = new Set(set_pos_neg.RemovePosEls());
           
            Console.Write("Результат : {");
            foreach (int i in set_pos.Data)
            {
                Console.Write(" " + i + " ");
            }
            Console.WriteLine("}");
            //------------------------------------------------------------------
            //Проверка методов из класса StatisticOperation 
            Console.WriteLine("\n-------------Проверка методов из класса StatisticOperation-------------");

            Set set = new Set(new List<int> { 1, 2, 3, -8, 19 });
            Console.Write("Множество : ");
            set.PrintSet();

            //Sum - сумма элементов множества
            Console.WriteLine("сумма элементов множества : " + StatisticOperation.Sum(set));
            //MaxMinDiff - разница между максимальным и минимальным элементами
            Console.WriteLine("разница между максимальным и минимальным элементами : " + StatisticOperation.MaxMinDiff(set));
            //AmountOfEls - подсчет количества элементов
            Console.WriteLine("подсчет количества элементов : " + StatisticOperation.AmountOfEls(set));
        }
    }
}

