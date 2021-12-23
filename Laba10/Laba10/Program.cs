using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

//класс FurnitureList представляет собой коллекцию для работы с объектами класса Furniture, 
//в FurnitureList определена переменная fList типа коллекции ArrayList, для хранения объектов Furniture

namespace Laba10
{
    class Program
    {
        static void Main(string[] args)
        {
            //-------------- 1 ЗАДАНИЕ --------------
            FurnitureList fur = new FurnitureList();
            fur.Add(new Furniture("Подушка \"Junior Green\"", 227));
            fur.Add(new Furniture("Подушка \"Ocean Fusion L\"", 430));
            fur.Add(new Furniture("Ортопедическая подушка с эффектом памяти \"Rita plus\"", 134));
            fur.Add(new Furniture("Кровать с подъёмным механизмом \"Честер\"", 477));
            fur.Add(new Furniture("Кровать в комбинированном цвете", 220));
            fur.Add(new Furniture("Кровать \"Denver\" черная, 160/200", 852));

            //демонстрация работы с коллекцией (добавление/удаление/поиск/вывод)
            Console.WriteLine("Вывод сформированной коллекции");
            fur.Print();
            Console.WriteLine();

            fur.Remove(new Furniture("Ортопедическая подушка с эффектом памяти \"Rita plus\"", 134));
            fur.RemoveAt(2);
            Console.WriteLine("Коллекция после удаления элемента по передаче объекта и передаче индекса");
            fur.Print();
            Console.WriteLine();

            Console.WriteLine("Поиск по индексу элемента в коллекции (получаем значение через set индексатора), индекс = 2");
            Console.WriteLine(fur[2]);
            Console.WriteLine();

            Console.WriteLine("Поиск по индексу элемента в коллекции (получаем значение через set индексатора), индекс = 100");
            Console.WriteLine(fur[100]);
            Console.WriteLine();

            Console.WriteLine($"Узнаем, содержится ли в коллекции объект : " +
                $"{(new Furniture("Подушка \"Junior Green\"", 227)).ToString()}");
            Console.WriteLine(fur.Contains(new Furniture("Подушка \"Junior Green\"", 227)));
            Console.WriteLine();

            Console.WriteLine($"Узнаем, содержится ли в коллекции объект : " +
                $"{(new Furniture("Я не существующий в коллекции элемент", 0)).ToString()}");
            Console.WriteLine(fur.Contains(new Furniture("Я не существующий в коллекции элемент", 0)));
            Console.WriteLine();

            //-------------- 2 ЗАДАНИЕ --------------
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

            //a.Выведите коллекцию на консоль
            Console.WriteLine("||||||||||||||||||||");
            Console.WriteLine("Вывод коллекции на консоль: ");
            foreach (var item in nums)
            {
                Console.Write(item + "\t");
            }

            //b. Удалите из коллекции n последовательных элементов
            Console.WriteLine("\n\n||||||||||||||||||||\n");
            Console.WriteLine("С какого индекса нужно удалить элементы : ");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index >= 0 && index < nums.Count - 1)
            {
                Console.WriteLine("Сколько элементов нужно удалить?");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n > 0)
                {
                    if (index + n > nums.Count)
                        n = nums.Count - index;

                    for (int i = index; i < index + n; i++)
                    {
                        nums.RemoveAt(index);
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("-- > Вы вышли за пределы размера коллекции < --");
            }

            Console.WriteLine("Вывод коллекции на консоль: ");
            foreach (var item in nums)
            {
                Console.Write(item + "\t");
            }

            //c. Добавьте другие элементы (используйте все возможные методы добавления для вашего типа коллекции).
            Console.WriteLine("\n\n||||||||||||||||||||\n");
            nums.Add(2); // добавление элемента
            nums.AddRange(new int[] { 7, 8, 9, 10 }); //добавление в список массива
            nums.Insert(1, 99);// вставляем на второе место в списке число 99

            Console.WriteLine("Вывод коллекции на консоль после разных способов добавления элементов : ");
            foreach (var item in nums)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();

            //d. Создайте вторую коллекцию (из таблицы выберите другой тип коллекции) и заполните ее данными из первой коллекции.
            Dictionary<char, int> dic = new Dictionary<char, int>();
            
            for (int i = 0, k = 97; i < nums.Count; i++, k++) 
            {
                char key = (char)k;

                dic.Add(key, nums[i]);
            }

            foreach(char c in dic.Keys)
            {
                Console.WriteLine(c + " : " + dic[c]);
            }

            //f. Найдите во второй коллекции заданное значение.
            Console.WriteLine("Введите значение, которое нужно найти : ");
            int num = Convert.ToInt32(Console.ReadLine());

            bool thereIs = false;
            foreach(char c in dic.Keys)
            {
                if (dic[c] == num)
                {
                    Console.WriteLine("Значение найдено : ");
                    Console.WriteLine(c + " : " + dic[c]);

                    thereIs = true;
                }
            }

            if (!thereIs)
            {
                Console.WriteLine("Значение не найдено!");
            }

            //Объект наблюдаемой коллекции ObservableCollection<T>
            var furObserve = new ObservableCollection<Furniture>
            {
                fur[0],
                fur[1],
            };

            Console.WriteLine("\n\nИзначально в наблюдаемой коллекции 2 объекта");
            foreach (var item in furObserve)
            {
                Console.WriteLine(item);
            }

            furObserve.CollectionChanged += FurnitureList_CollectionChanged;

            Console.WriteLine("\n--> Начинаем изменять коллекцию <--");
            furObserve.Add(fur[2]);
            furObserve.Remove(fur[2]);

            furObserve[0] = fur[2];

            Console.WriteLine("\nКоллекция после всех изменений");
            foreach (var item in furObserve)
            {
                Console.WriteLine(item);
            }
        }

        public static void FurnitureList_CollectionChanged(object sender, 
            NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Furniture newFur = e.NewItems[0] as Furniture;
                    Console.WriteLine($"Добавлен новый объект : {newFur.ToString()}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Furniture oldFur = e.OldItems[0] as Furniture;
                    Console.WriteLine($"Удален объект : {oldFur.ToString()}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Furniture replacedFur = e.OldItems[0] as Furniture;
                    Furniture replacingFur = e.NewItems[0] as Furniture;
                    Console.WriteLine($"Объект {replacedFur.ToString()} заменен объектом {replacingFur.ToString()}");
                    break;
            }
        }
    }
}
