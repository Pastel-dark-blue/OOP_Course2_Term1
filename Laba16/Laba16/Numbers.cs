using System;
using System.Threading;
using System.Threading.Tasks;

namespace Laba16
{
    class Numbers
    {
        public static void matrixMult()
        {
            int rows1 = 0;
            int cols1 = 0;
            int rows2 = 0;
            int cols2 = 0;
            bool result;

            Console.Write("Введите количество строк 1 матрицы: ");
            result = int.TryParse(Console.ReadLine(), out rows1);
            if (!result) { 
                Console.WriteLine("\nВведите число!");
                return;
            }

            Console.Write("\nВведите количество столбцов 1 матрицы: ");
            result = int.TryParse(Console.ReadLine(), out cols1);
            if (!result)
            {
                Console.WriteLine("\nВведите число!");
                return;
            }

            Console.Write("\nВведите количество столбцов 2 матрицы: ");
            result = int.TryParse(Console.ReadLine(), out cols2);
            if (!result)
            {
                Console.WriteLine("\nВведите число!");
                return;
            }
            rows2 = cols1;

            Random rnd = new Random();

            Console.WriteLine("\n---------------------- 1 матрица ----------------------");
            int[,] matr1 = new int[rows1, cols1];
            for(int r1 = 0; r1 < rows1; r1++)
            {
                for(int c1 = 0; c1 < cols1; c1++)
                {
                    matr1[r1, c1] = rnd.Next(-20, 100);
                    Console.Write(matr1[r1, c1] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n---------------------- 2 матрица ----------------------");
            int[,] matr2 = new int[rows2, cols2];
            for (int r2 = 0; r2 < rows2; r2++)
            {
                for (int c2 = 0; c2 < cols2; c2++)
                {
                    matr2[r2, c2] = rnd.Next(-20, 100);
                    Console.Write(matr2[r2, c2] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n---------------------- Перемноженные матрицы ----------------------");
            int[,] multMatr = new int[rows1, cols2];
            for (var i = 0; i < rows1; i++)
            {
                for (var j = 0; j < cols2; j++)
                {
                    multMatr[i, j] = 0;

                    for (var k = 0; k < cols1; k++)
                    {
                        multMatr[i, j] += matr1[i, k] * matr2[k, j];
                    }
                    Console.Write(multMatr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void rowsCols(ref int rows1, ref int cols1, ref int rows2, ref int cols2)
        {
            bool result;

            Console.Write("Введите количество строк 1 матрицы: ");
            result = int.TryParse(Console.ReadLine(), out rows1);
            if (!result)
            {
                Console.WriteLine("\nВведите число!");
                return;
            }

            Console.Write("\nВведите количество столбцов 1 матрицы: ");
            result = int.TryParse(Console.ReadLine(), out cols1);
            if (!result)
            {
                Console.WriteLine("\nВведите число!");
                return;
            }

            Console.Write("\nВведите количество столбцов 2 матрицы: ");
            result = int.TryParse(Console.ReadLine(), out cols2);
            if (!result)
            {
                Console.WriteLine("\nВведите число!");
                return;
            }
            rows2 = cols1;
        }


        public static void matrixMultToken(CancellationToken token, int rows1, int cols1, int rows2, int cols2)
        {
            Random rnd = new Random();

            Console.WriteLine("\n---------------------- 1 матрица ----------------------");
            int[,] matr1 = new int[rows1, cols1];
            for (int r1 = 0; r1 < rows1; r1++)
            {
                for (int c1 = 0; c1 < cols1; c1++)
                {
                    matr1[r1, c1] = rnd.Next(-20, 100);
                    Console.Write(matr1[r1, c1] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n---------------------- 2 матрица ----------------------");
            int[,] matr2 = new int[rows2, cols2];
            for (int r2 = 0; r2 < rows2; r2++)
            {
                for (int c2 = 0; c2 < cols2; c2++)
                {
                    matr2[r2, c2] = rnd.Next(-20, 100);
                    Console.Write(matr2[r2, c2] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n---------------------- Перемноженные матрицы ----------------------");
            int[,] multMatr = new int[rows1, cols2];
            for (var i = 0; i < rows1; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }

                for (var j = 0; j < cols2; j++)
                {
                    multMatr[i, j] = 0;

                    for (var k = 0; k < cols1; k++)
                    {
                        multMatr[i, j] += matr1[i, k] * matr2[k, j];
                    }
                    Console.Write(multMatr[i, j] + "\t");
                    Thread.Sleep(2000);
                }
                Console.WriteLine();
            }
        }

        public static int Task1()
        {
            return 1;
        }

        public static int Task2()
        {
            return 2;
        }

        public static int Task3()
        {
            return 3;
        }

        public static void genArray(int amount)
        {
            Random rnd = new Random();

            int[] array = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                array[i] = rnd.Next(-100, 100);
            }

            foreach (int n in array)
            {
                Console.Write(n + "\t");
            }
        }

        public static async void asyncMethod()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
                Console.WriteLine("Асинхронный метод завершился!");
            });
        }
    }
}
