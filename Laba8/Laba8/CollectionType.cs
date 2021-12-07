using System;
using System.Collections.Generic;
using System.IO;

namespace Laba8
{
    class CollectionType<T> : Iarv<T> where T : class
    {
        private string path = @"D:\ООП_2к_1с\Laba8\file.txt";

        private List<T> list = new List<T>();

        public void Add(T obj)
        {
            list.Add(obj);
        }

        public void Remove(T obj)
        {
            list.Remove(obj);
        }

        public void View()
        {
            foreach(T element in list)
            {
                Console.Write($"\n{element.ToString()}");
            }
        }

        public void WriteFile()
        {
            try
            {
                using(StreamWriter file = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    foreach(T el in list)
                    {
                        file.WriteLine(el.ToString());
                    }
                }

                Console.WriteLine("File is written");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadFile()
        {
            try
            {
                using(StreamReader file=new StreamReader(path, System.Text.Encoding.Default))
                {
                    //построчное считывание
                    //string line;
                    //while ((line = file.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(line);
                    //}

                    //считывание всего текста сразу
                    Console.WriteLine(file.ReadToEnd());

                    Console.WriteLine("File is read");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

