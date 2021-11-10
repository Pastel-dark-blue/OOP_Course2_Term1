using System;
using System.Collections.Generic;
using System.Text;

namespace Laba6
{
    static class Controller
    {
        //получение фильма по году
        static public List<TVProgram> GetFilmsByYear (uint year,List<TVProgram> container)
        {
            List<TVProgram> yearFilms = new List<TVProgram>();
            foreach(TVProgram film in container)
            {
                //элемент списка должен быть фильмом и год его создания должен быть равен тому, что ввёл пользователь
                if(film is Film && film.PremiereDate.Year == year)
                {
                    yearFilms.Add(film);
                } 
            }

            return yearFilms;
        }

        //продолжительность всей программы
        static public float GetDuration(List<TVProgram> container)
        {
            float duration = 0f;
            foreach (TVProgram el in container)
            {
                duration += el.DurationMinutes;
            }
            return duration;
        }

        //число рекламных роликов
        static public int GetNumberOfAds(List<TVProgram> container)
        {
            int NumOfAds = 0;
            foreach (TVProgram el in container)
            {
                if(el is Advertising)
                {
                    NumOfAds += 1;
                }
            }

            return NumOfAds;
        }

    }
}
