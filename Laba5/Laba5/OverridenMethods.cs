using System;
using System.Collections.Generic;
using System.Text;

namespace Laba5
{
    partial class Advertising
    {
        //вывод информации о рекламе
        public override string ToString()
        {
            return $"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                $"Название : {Title}\n" +
                $"Компания заказчик : {CustomerCompany}\n" +
                $"Рекламное агентство : {AdvertisingAgency}\n" +
                $"Продолжительность : {DurationMinutes}\n" +
                $"Дата премьеры : {PremiereDate}\n" +
                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
        }
        //---------------------------------------

        //хэш-код 
        public override int GetHashCode()
        {
            //полученное значение типа DateTime при помощи метода ToString() приводим к строке вида
            //"день.месяц.год часы:минуты:секунды" и далеее к массиву [день, месяц, ... , секунды]
            string[] bday = (this.PremiereDate.ToString()).Split(' ', ':', '.');
            int sum = 0;
            //конвертируем значения из массива в тип int и складываем
            foreach (string i in bday)
            {
                sum += Convert.ToInt32(i);
            }

            //теперь к полученной ранее сумме добавлем ASCII-коды символов компании заказчика
            foreach (char i in this.CustomerCompany)
            {
                sum += (int)i;
            }

            //и символов рекламного агентства
            foreach (char i in this.AdvertisingAgency)
            {
                sum += (int)i;
            }

            //полученная сумма, умноженная на ДЕНЬ премьеры, и есть хэш-код
            return sum * Convert.ToInt32(bday[0]);
        }
        //---------------------------------------

        //сравнение объектов
        public override bool Equals(object obj)
        {
            //типы сравниваемых объектов должны быть одинаковыми
            if (obj.GetType() != this.GetType())
                return false;

            //obj приводим к виду объекта типа Advertising
            var st = (Advertising)obj;

            return (this.ToString() == obj.ToString());

        }

    }
}
