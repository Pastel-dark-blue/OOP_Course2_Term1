using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba10
{
    //реализация интерфейса IList для создания коллекции типа FurnitureList для хранения объектов типа Furniture
    class FurnitureList : IList<Furniture>
    {
        //коллекция объектов объектов
        public ArrayList fList = new ArrayList();

        //метод для вывода коллекции FurnitureList
        public void Print()
        {
            foreach (var item in fList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        //реализация интерфейса IList
        public Furniture this[int index]
        {
            get
            {
                if ((index >= 0) && (index < fList.Count))
                {
                    return (Furniture)fList[index];
                }
                else
                {
                    Console.WriteLine("-- > Вы вышли за пределы размера коллекции < --");
                    Console.WriteLine("-- > Поэтому будет выведен первый элемент коллекции < --");
                    return (Furniture)fList[0];
                }
            }
            set { throw new NotImplementedException(); }
        }

        public int Count => fList.Count;

        public bool IsReadOnly { get; }

        public void Add(Furniture item)
        {
            fList.Add(item);
        }

        public void Clear()
        {
            fList.Clear();
        }

        public bool Contains(Furniture obj)
        {
            foreach (var el in this)
            {
                if (el.Equals(obj))
                    return true;
            }

            return false;
        }

        public void CopyTo(Furniture[] array, int arrayIndex)
        {
            fList.CopyTo(array, arrayIndex);
        }

        public int IndexOf(Furniture item)
        {
            return fList.IndexOf(item);
        }

        public void Insert(int index, Furniture item)
        {
            fList.Insert(index, item);
        }

        public bool Remove(Furniture item)
        {
            fList.Remove(item);
            return true;
        }

        public void RemoveAt(int index)
        {
            try
            {
                fList.RemoveAt(index);
            }
            catch
            {
                Console.WriteLine("--> Вы вышли за пределы размера коллекции <--");
            }
        }

        public IEnumerator<Furniture> GetEnumerator()
        {
            foreach (var item in fList)
            {
                yield return (Furniture)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
