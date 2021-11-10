using System;
using System.Collections.Generic;

namespace Laba6
{
    class Container
    {
        private List<TVProgram> list = new List<TVProgram>();

        public List<TVProgram>  List
        {
            get { 
                return list; 
            }
            private set { 
                list = value; 
            }
        }

        public Container()
        { }

        public Container(List<TVProgram> list)
        {
            List = list;
        }

        //установка нового значения для всего списка
        public void SetFullProgram(List<TVProgram> new_prog)
        {
            List = new_prog;
        }

        //добавление новой программы в список
        public void AddProgram(TVProgram new_prog)
        {
            List.Add(new_prog);
        }

        //удаление определенной программы
        public void RemoveProgram(TVProgram new_prog)
        {
            List.Remove(new_prog);
        }

        //удаление программы по индексу в списке
        public void RemoveProgram(int index)
        {
            index--;
            if (index < 0 || index > List.Count)
            {
                Console.WriteLine("Индекс выходит за границы списка.");
                Console.WriteLine($"Введите значение от 0 до {List.Count}.\n");
            }
            else
            {
                List.RemoveAt(index);
                Console.WriteLine($"Элемент {index} удалён.\n");
            }
        }

        //вывод всех программ в списке
        public void GetFullProgram()
        {
            int i = 1;
            foreach(TVProgram prog in List)
            {
                Console.WriteLine($"{i}) Название: {prog.Title} // Режиссёр: {prog.Director}" +
                $" // Продолжительность: {prog.DurationMinutes} // Дата премьеры: {prog.PremiereDate} //");
                i++;
            }
        }

        //вывод программы по индексу в списке
        public void GetProgram(int index)
        {
            index--;
            if (index < 0 || index > List.Count)
            {
                Console.WriteLine("Индекс выходит за границы списка.");
                Console.WriteLine($"Введите значение от 0 до {List.Count}.\n");
            }
            else
            {
                Console.WriteLine($"Название: {List[index].Title}// Режиссёр: {List[index].Director}" +
                $" //Продолжительность: {List[index].DurationMinutes}// Дата премьеры: {List[index].PremiereDate}//");
            }
        }

    }
}
