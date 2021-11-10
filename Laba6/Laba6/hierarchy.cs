using System;
using System.Collections.Generic;
using System.Text;

namespace Laba6
{
        class TVProgram
        {
            //свойства
            public string Title { get; set; }
            
            public float DurationMinutes { get; set; }

            private DateTime _premiereDate;
            public DateTime PremiereDate { 
            get {
                return _premiereDate;
            } 
            set {
                if (value.Year > 1850)
                {
                    _premiereDate = value;
                }
            } 
        }

            //при вызове конструктора у структуры поля структуры инициализируются значениями по умолчанию для определенных типов
            private Director _director = new Director();
            public Director Director { 
            get {
                return _director;
            } 
            set {
                _director = value;
            } 
        }

        //конструктор
        public TVProgram(string title)
            {
                Title = title;
            }
        }
        //------------------------------------------------------

        //------------------------------------------------------
        //Художественный фильм - то же, что игровой фильм.
        class FeatureFilm : Film
        {
            public FeatureFilm(string title) : base(title) { }

            //принимает строку со списком "Имя Фамилия" актеров
            public string MainActors { get; set; }

            public override string ToString()
            {
                return $"-> Название: {Title}// В главных ролях: {MainActors}";
            }

        }

        //Мультфильм
        class Cartoon : Film
    {
            public Cartoon(string title) : base(title) { }

            //принцип создания мультфильма: Пластилиновый, Рисованный, Кукольный, Компьютерный, Художественный
            public WaysToCreateACartoon WayToCreate { get; set; }

            public override string ToString()
            {
                return $"-> Название: {Title}// Принцип создания мультфильма: {WayToCreate}";
            }

        }

        //Телевизионная программа
        class Film : TVProgram
        {
            public Film(string title) : base(title) { }

            public string Genres { get; set; }
            public override string ToString()
            {
                return $"-> Название: {Title}// Жанры: {Genres}// Режиссёр: {Director}" +
                    $" //Продолжительность: {DurationMinutes}// Дата премьеры: {PremiereDate}";
            }
        }

        //------------------------------------------------------
        class News : TVProgram
        {
            public News(string title) : base(title) { }

            //название ТВ канала
            public string ChannelName { get; set; }
            public string Presenter { get; set; }

            public override string ToString()
            {
                return $"-> Название: {Title}// Канал: {ChannelName}";
            }
        }

        //------------------------------------------------------
        partial class Advertising : TVProgram
        {
            public Advertising(string title) : base(title) { }

            //методы
            public string CustomerCompany { get; set; }
            public string AdvertisingAgency { get; set; }

        }
}
