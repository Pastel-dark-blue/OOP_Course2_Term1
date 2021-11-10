using System;
using System.Diagnostics; //для Debug.Assert()

namespace Laba7
{
        class TVProgram
        {
            private string _title;
            public string Title {
                get { 
                    return _title; 
                }
                set {
                    if (value == null) 
                    {
                        throw new Exceptions.Title_Exception("Необходимо задать название!");
                    }
                    else if (value.Length == 0) 
                    {
                        throw new Exceptions.Title_Exception("Пустая строка не может быть названием.");
                    }
                    else
                    {
                        _title = value;
                    }
                }
            }

            private float _durationMinutes;
            public float DurationMinutes { 
                get {
                    return _durationMinutes;
                } 
                set {
                    if (value <= 0)
                    {
                        throw new Exceptions.DurationMinutes_Exception("Продолжительность фильма не может быть равна или меньше 0 минут.");
                    }
                    else
                    {
                        _durationMinutes = value;
                    }
                } 
            }

            private DateTime _premiereDate;
            public DateTime PremiereDate { 
                get {
                    return _premiereDate;
                } 
                set {
                    if (value.Year > 1887)
                    {
                        _premiereDate = value;
                    }
                    else
                    {
                        throw new Exceptions.PremiereDate_Exception("Первая кинокартина в мире была снята в 1888 году.");
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
            public TVProgram(string title) {
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
            private WaysToCreateACartoon _wayToCreate;
            public WaysToCreateACartoon WayToCreate { 
                get{
                    return _wayToCreate;
                }
                set {
                    if((int)value>=1 && (int)value <= 5)
                    {
                        _wayToCreate = value;
                    }
                    else
                    {
                        throw new ArgumentException("Необходимо выбрать одно из предложенных значений!");
                    }
                } 
            }
        
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
            private string _channelName;
            public string ChannelName {
                get {
                    return _channelName;
                }

                set {
                    Debug.Assert(value != "", "Пустая строка не может служить именем канала.");
                    _channelName = value;
                }
            }

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


