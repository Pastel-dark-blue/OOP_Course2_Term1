using System;
using System.Collections.Generic;

namespace Laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем объекты рекламы
            Advertising ad1 = new Advertising("ad1");
            ad1.DurationMinutes = 0.5f;
            ad1.PremiereDate = new DateTime(2015, 7, 9);
            Advertising ad2 = new Advertising("ad2");
            ad2.DurationMinutes = 0.7f;
            ad2.PremiereDate = new DateTime(2002, 2, 5);

            //создаем объекты фильмов
            Film f1 = new Film("f1");
            f1.DurationMinutes = 123;
            f1.PremiereDate = new DateTime(2002, 2, 5);
            Film f2 = new Film("f2");
            f2.DurationMinutes = 87;
            f2.PremiereDate = new DateTime(2002, 5, 10);
            Film f3 = new Film("f3");
            f3.DurationMinutes = 76;
            f3.PremiereDate = new DateTime(1997, 12, 1);

            //создаем объекты худ.фильмов
            FeatureFilm ff1 = new FeatureFilm("ff1");
            ff1.DurationMinutes = 98;
            ff1.PremiereDate = new DateTime(1998, 12, 17);
            FeatureFilm ff2 = new FeatureFilm("ff2");
            ff2.DurationMinutes = 124;
            ff2.PremiereDate = new DateTime(1998, 12, 17);

            //записываем созданные объекты в контейнер
            Container cont = new Container(new List<TVProgram>() { ad1, ad2, f1, f2, f3 });
            cont.AddProgram(ff1);
            cont.AddProgram(ff2);

            //выводим все объекты, добавленные в контейнер
            cont.GetFullProgram();

            //программа в списке по индексу
            cont.GetProgram(1);

            //-------------- ЗАПРОСЫ --------------
            //вывод фильма по году
            Console.WriteLine("Фильмы за 2002 год : ");
            int i = 1;
            foreach (TVProgram film in Controller.GetFilmsByYear(2002, cont.List))
            {
                Console.WriteLine($"{i}) Название: {film.Title} // Режиссёр: {film.Director}" +
                $" // Продолжительность: {film.DurationMinutes} // Дата премьеры: {film.PremiereDate} //");
                i++;
            }

            //вывод продолжительности программы
            Console.WriteLine("Продолжительность всей программы : " + Controller.GetDuration(cont.List));

            //вывод продолжительности программы
            Console.WriteLine("Количество рекламных роликов в программе : " + Controller.GetNumberOfAds(cont.List));
        }
    }
}


