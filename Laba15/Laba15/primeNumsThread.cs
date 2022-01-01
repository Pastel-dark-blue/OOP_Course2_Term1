using System;
using System.IO;
using System.Threading;

namespace Laba15
{
    partial class Program
    {
        public static void primeNums(int n)
        {
            if (n < 1)
            {
                return;
            }

            string primeNumsStr = "";

            for(int i = 1; i < n; i++)
            {
                bool isSimple = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }

                if (isSimple)
                {
                    primeNumsStr += i + "\t";

                    Console.Write(i + "\t");
                    // приостанавливаем поток на 100 мс
                    Thread.Sleep(100);
                };
            }

            string path = @"D:\ООП_2к_1с\Laba15\primeNums.txt";
            using (StreamWriter swf = new StreamWriter(path))
            {
                swf.Write(primeNumsStr);
            }

            Console.WriteLine("\n\nЧисла были записаны в файл");

            // получение и вывод информации о текущем потоке
            Thread curThread = Thread.CurrentThread;
            string primeNumsThreadInfo = $"\nИнформация о потоке:\n" +
                        $"Имя: {curThread.Name}\n" +
                        $"Идентификатор: {curThread.ManagedThreadId}\n" +
                        $"Выполняется ли поток: {curThread.IsAlive}\n" +
                        $"Приоритет: {curThread.Priority}\n";

            Console.WriteLine(primeNumsThreadInfo);
        }
    }
}
