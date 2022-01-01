using System;
using System.IO;
using System.Threading;

namespace Laba15
{
    partial class Program
    {
        //Используя средства синхронизации организуйте работу потоков, таким образом, чтобы
        //    a. выводились сначала четные, потом нечетные числа
        //    b. последовательно выводились одно четное, другое нечетное.

        //// a
        //// в качестве параметра объекта типа AutoResetEvent передаем false, что говорит о том,
        //// что изначально объект будет в состоянии ожидания
        //static AutoResetEvent waitHandler = new AutoResetEvent(false);

        //public static void oddNums(int n)
        //{
        //    waitHandler.WaitOne(); // поток ожидает передачи сигнального состояния объекту waitHandler
        //        string nums = "\nНечетные числа: \n";

        //        for (int i = 1; i < n; i++)
        //        {
        //            if (i % 2 != 0)
        //            {
        //                Console.Write(i + "\t");
        //                nums += i + "\t";
        //                Thread.Sleep(10); // по условию скорость расчета чисел у потоков должна быть разная
        //            }
        //        }

        //        string path = @"D:\ООП_2к_1с\Laba15\evenOddNums.txt";
        //        using (StreamWriter swf = new StreamWriter(path, true))
        //        {
        //            swf.Write(nums);
        //        }
        //    waitHandler.Set();
        //}

        //public static void evenNums(int n)
        //{
        //    string nums = "Четные числа: \n";

        //        for (int i = 1; i < n; i++)
        //        {
        //            if (i % 2 == 0)
        //            {
        //                Console.Write(i + "\t");
        //                nums += i + "\t";
        //                Thread.Sleep(5); // по условию скорость расчета чисел у потоков должна быть разная
        //            }
        //        }

        //        string path = @"D:\ООП_2к_1с\Laba15\evenOddNums.txt";
        //        using (StreamWriter swf = new StreamWriter(path, true))
        //        {
        //            swf.Write(nums);
        //        }
        //    waitHandler.Set(); // передача сигнального состояния объекту waitHandler
        //}


        // b

        // в качестве параметра объекта типа AutoResetEvent передаем false, что говорит о том,
        // что изначально объект будет в состоянии ожидания
        static AutoResetEvent waitHandler1 = new AutoResetEvent(true); // сразу в сигнальном состоянии
        static AutoResetEvent waitHandler2 = new AutoResetEvent(false); // сазу в состоянии ожидания передачи сигнала 

        public static void oddNums(int n)
        {
            string path = @"D:\ООП_2к_1с\Laba15\alternation.txt";

            for (int i = 1; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    // на протяженни 20 мс ожидаем получения потока waitHandler2, потом получаем его принудительно
                    // это нужно потому что вывод четных чисел завершится раньше нечетных и иначе программа просто остановиться,
                    // ожидая сигнальное состояние для waitHandler2, но его не получит, ибо метод вывода четных чисел, 
                    // предоставляющий его, уже отработал
                    // вроде как, похоже на костыль, аха
                    waitHandler2.WaitOne(30);
                    Console.Write(i + "\t");
                    using (StreamWriter swf = new StreamWriter(path, true))
                    {
                        swf.Write(i + "\t");
                    }
                    Thread.Sleep(10); 
                    waitHandler1.Set();
                }
            }
        }

        public static void evenNums(int n)
        {
            string path = @"D:\ООП_2к_1с\Laba15\alternation.txt";

            for (int i = 1; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    waitHandler1.WaitOne(); // (*) выполнение начинается здесь
                    Console.Write(i + "\t");
                    using (StreamWriter swf = new StreamWriter(path, true))
                    {
                        swf.Write(i + "\t");
                    }
                    Thread.Sleep(5); 
                    waitHandler2.Set(); // освобождаем объект waitHandler2, который ожидает второй поток
                }
            }            
        }
    }
}
