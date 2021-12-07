using System;
using System.Collections.Generic;
using System.Text;

namespace Laba8
{
    class Advertising 
    {
        //конструктор
        public Advertising(string title)
        {
            Title = title;
        }

        //методы
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string AdvertisingAgency { get; set; }
        public float DurationMinutes { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Description { get; set; }

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
    }
}
