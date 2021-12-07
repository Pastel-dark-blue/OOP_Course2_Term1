using System;
using System.Collections.Generic;

namespace Laba7
{
    class Program
    {
        static void exceptionPrint(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n*** Error! ***\n--------------\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Текст ошибки : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(e.Message);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Сборка, где возникла ошибка : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(e.Source);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Вывод стека : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(e.StackTrace);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void Main(string[] args)
        {
            FeatureFilm ff1 = new FeatureFilm("ff1");

            try
            {
                ff1.PremiereDate = new DateTime(1885, 12, 20);
            }
            catch (Exceptions.PremiereDate_Exception e)
            {
                exceptionPrint(e);
            }

            try
            {
                Cartoon c1 = new Cartoon(null);
            }
            catch (Exceptions.Title_Exception e)
            {
                exceptionPrint(e);
            }

            try
            {
                Cartoon c2 = new Cartoon("");
            }
            catch (Exceptions.Title_Exception e)
            {
                exceptionPrint(e);
            }

            try
            {
                ff1.DurationMinutes = -3;
            }
            catch (Exceptions.DurationMinutes_Exception e)
            {
                exceptionPrint(e);
            }

            Cartoon c3 = new Cartoon("c3");
            try
            {
                Console.Write("\nСпособы создания мультфильма " + c3.Title + " : \n" +
                    "пластилиновый - 1 \nрисованный - 2 \nкукольный - 3 \nкомпьютерный - 4 \nхудожественный - 5 \n\n-> Ваш выбор : ");
                c3.WayToCreate = (WaysToCreateACartoon)Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ваш мультфильм : \n" + c3.ToString());
            }
            catch(ArgumentException e)
            {
                exceptionPrint(e);
            }

            //Assert!
            Console.WriteLine();
            News n1 = new News("n1");
            n1.ChannelName = "";
        }
    }
}


