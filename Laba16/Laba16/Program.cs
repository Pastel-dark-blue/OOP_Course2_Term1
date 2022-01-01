using System;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Laba16
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 создайте длительную по времени задачу (на основе Task) на выбор: перемножение матриц
            Console.WriteLine("***************** 1 *****************\n");
            Task matrMultTask = new Task(Numbers.matrixMult);

            // Оцените производительность выполнения используя объект Stopwatch на нескольких прогонах.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            matrMultTask.Start();
            matrMultTask.Wait();

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            Console.WriteLine("\n-> RunTime " + elapsedTime);

            // Выведите идентификатор текущей задачи, проверьте во время выполнения – завершена ли задача и выведите ее статус.
            Console.WriteLine($"\nИнформация о задаче: \n" +
                $"Идентификатор: {matrMultTask.Id}\n" +
                $"Статус: {matrMultTask.Status}\n");

            // 2 Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken и отмените задачу.
            Console.WriteLine("***************** 2 *****************\n");

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // так как нам необходимо, чтобы пользователь ввел некоторые значения, а в этот ввод,
            // если оставить его в функции matrixMultTokenб может вмешаться основной поток, создаем метод
            // с помощью которого плучаем и проверяем значения на корректность
            int rows1 = 0;
            int cols1 = 0;
            int rows2 = 0;
            int cols2 = 0;
            Task.Run(() => Numbers.rowsCols(ref rows1, ref cols1, ref rows2, ref cols2)).Wait();

            Task matrMultTaskWithToken = new Task(() => Numbers.matrixMultToken(token, rows1, cols1, rows2, cols2));

            matrMultTaskWithToken.Start();

            Console.WriteLine("\n-> Введите Y для отмены операции <-\n");
            string s = Console.ReadLine();
            if (s == "Y" || s == "y") { }
            cancelTokenSource.Cancel();

            // 3 Создайте три задачи с возвратом результата и используйте их для выполнения четвертой задачи. Например, расчет по формуле.
            Console.WriteLine("\n***************** 3 *****************\n");

            Task<int>[] tasks = new Task<int>[3]
            {
                new Task<int>(Numbers.Task1),
                new Task<int>(Numbers.Task2),
                new Task<int>(Numbers.Task3)
            };

            foreach (var t in tasks)
            {
                t.Start();
            }


            int sum = 0;
            foreach (var t in tasks)
            {
                sum += t.Result;
            }

            Console.WriteLine("Сумма 1 + 2 + 3 = " + sum);

            // 4 Создайте задачу продолжения (continuation task) в двух вариантах
            Console.WriteLine("\n***************** 4 *****************\n");

            // 1) C ContinueWith -планировка на основе завершения множества предшествующих задач
            Task<int> task4_1 = new Task<int>(() => 1);

            Task display = task4_1.ContinueWith(num => Console.WriteLine(
                $"-> Задача с идентификатором \"{task4_1.Id}\" вернула значение {num.Result}"));

            task4_1.Start();

            // 2) На основе объекта ожидания и методов GetAwaiter(),GetResult();
            Task<int> task4_2 = Task.Run(() => 2);

            // ждем завершения task4_2
            var awaiter = task4_2.GetAwaiter();

            // получив объект ожидания, решаем, что будем делать дальше; в данном случае выведем значение, которое вернула задача task4_2
            awaiter.OnCompleted(() => Console.WriteLine(
            $"-> Задача с идентификатором \"{task4_2.Id}\" вернула значение {awaiter.GetResult()}"));
            Thread.Sleep(100);

            // 5 Используя Класс Parallel распараллельте вычисления циклов For(), ForEach().
            // Оцените производительность по сравнению с обычными циклами
            Console.WriteLine("\n***************** 5 *****************\n");
            int amount = 5;

            Console.Write("Генерация 3 массивов по 5 элементов с помощью Parallel.For: ");

            stopWatch.Start();
            Parallel.For(1, 140, (num) => Numbers.genArray(amount));
            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            Console.WriteLine("\n-> RunTime " + elapsedTime);

            Console.Write("\nГенерация 3 массивов по 5 элементов с помощью цикла запуска задач: ");
            stopWatch.Start();
            for (int i = 1; i < 140; i++)
            {
                Task.Run(() => Numbers.genArray(amount)).Wait();
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            Console.WriteLine("\n-> RunTime " + elapsedTime);

            List<int> list = new List<int>() { 3, 4, 7, 8, 9, 2, 4, 7, 12, 9, 5, 5, 4, 23, 80, 65 };
            Console.Write("\nГенерация массивов по 3, 4, 7, 8, 9, 2, 4, 7, 12, 9, 5, 5, 4, 23, 80, 65 элементов с помощью Parallel.ForEach: ");

            stopWatch.Start();
            ParallelLoopResult result = Parallel.ForEach(list, Numbers.genArray);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            Console.WriteLine("\n-> RunTime " + elapsedTime);

            Console.Write("\nГенерация массивов по 3, 4, 7, 8, 9, 2, 4, 7, 12, 9, 5, 5, 4, 23, 80, 65 элементов с помощью цикла запуска задач: ");
            stopWatch.Start();
            for (int i = 0; i < list.Count; i++)
            {
                Task.Run(() => Numbers.genArray(list[i])).Wait();
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;

            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            Console.WriteLine("\n-> RunTime " + elapsedTime);

            // 6 Используя Parallel.Invoke() распараллельте выполнение блока операторов.
            Console.WriteLine("\n***************** 6 *****************\n");
            Parallel.Invoke(
                () =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Я поспал 1 секунду!");
                    },
                () => Console.WriteLine("А куда спать?"),
                () =>
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            Console.WriteLine("Цикл на итерации: " + i);
                        }
                    }
            );

            // 7 Используя Класс BlockingCollection реализуйте следующую задачу:
            // Есть 5 поставщиков бытовой техники, они завозят уникальные товары на склад(каждый по одному) и 
            // 10 покупателей – покупают все подряд, если товара нет - уходят.В вашей задаче: cпрос превышает предложение.
            // Изначально склад пустой.У каждого поставщика своя скорость завоза товара.Каждый раз при изменении состоянии склада
            // выводите наименования товаров на складе.
            Console.WriteLine("\n***************** 7 *****************\n");
            BlockingCollection<string> bc = new BlockingCollection<string>(5);
            int tea = 1;

            // псотавщики
            Task[] shippers = new Task[5]
            {
                new Task(() =>
                    {
                         while (!bc.IsAddingCompleted)
                         {
                            bc.Add("бензопила");
                            Console.WriteLine("На склад поставлена бензопила");
                            Thread.Sleep(1000);
                         }
                    }
                ),
                new Task (()=>
                    {
                        // когда будет доставлено 3 чая, поток заснет на 1 секунду, после чего заблокируется возможность добавления товаров
                        while (tea <= 3 && !bc.IsAddingCompleted)
                        {
                            bc.Add("чай");
                            Console.WriteLine("На склад поставлен чай");
                            tea++;
                            Thread.Sleep(1000);
                        }
                        bc.CompleteAdding();
                    }
                ),
                new Task (()=>
                    {
                        while (!bc.IsAddingCompleted)
                        {
                            bc.Add("странный кот");
                            Console.WriteLine("На склад поставлен странный кот");
                            Thread.Sleep(1000);
                        }
                    }
                ),
                new Task (()=>
                    {
                        while (!bc.IsAddingCompleted)
                        {
                            bc.Add("Сатурн");
                            Console.WriteLine("На склад поставлен Сатурн");
                            Thread.Sleep(1000);
                        }
                    }
                ),
                new Task (()=>
                    {
                        while (!bc.IsAddingCompleted)
                        {
                            bc.Add("семизубый меч");
                            Console.WriteLine("На склад поставлен семизубый меч");
                            Thread.Sleep(1000);
                        }
                    }
                )
            };

            string good = "";

            Task[] consumers = new Task[10]
            {
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
                new Task(()=>
                    {
                        while (!bc.IsCompleted)
                        {
                            if(bc.TryTake(out good))
                                Console.WriteLine("Взят товар с наименованием: " + good);
                            else
                                Console.WriteLine("Покупатель ушёл, ничего не купив");

                            Thread.Sleep(400);
                        }
                    }
                ),
            };

            foreach (var sр in shippers)
            {
                sр.Start();
            }

            foreach (var c in consumers)
            {
                c.Start();
            }

            Console.ReadLine();

            // 8 Используя async и await организуйте асинхронное выполнение любого метода.
            Console.WriteLine("\n***************** 8 *****************\n");
            Numbers.asyncMethod();

            Console.WriteLine("Поток Main не заблокирован асинхронным методом!");

            Console.ReadLine();
        }
    }
}