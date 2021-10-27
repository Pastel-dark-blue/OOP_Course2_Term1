using System;

namespace Laba5
{
    //------------------------------------------------------
    //абстрактный класс
    abstract class Person
    {
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        //абстрактный метод
        public abstract void Print();
    }

    //класс-наследник абстрактного класса Person
    class Director : Person
    {
        public Director(string name, string surname) : base(name, surname) { }

        //обязательное переопределение абстрактного метода родительского класса
        public override void Print()
        {
            Console.WriteLine("Имя режиссёра : " + this.Name + ", фамилия : " + this.Surname);
        }

        public void SaySmth()
        {
            Console.WriteLine("Я режиссёр!");
        }
    }

    //класс-наследник абстрактного класса Person
    class Presenter : Person 
    { 
        public Presenter(string name, string surname) : base(name, surname) { }
        
        public override void Print()
        {
            Console.WriteLine("Имя ведущего :" + this.Name + ", фамилия : " + this.Surname);
        }
    }
    //------------------------------------------------------

    //------------------------------------------------------
    //интерфейс для вывода описания произведения
    interface IDescription
    {
        void PrintDescription();
    }
    //------------------------------------------------------
    //абстрактный класс к заданию 4, который содержит метод с тем же названием, что и метод интерфейса IDescription
    abstract class DescriptionClass
    {
        public abstract void PrintDescription();
    }
    //------------------------------------------------------

    //------------------------------------------------------
    //Фильм может быть игровым и неигровым. 
    //Неигровое (документальное) кино - съёмки подлинных событий и лиц. 
    //Игровое - произведение, имеющее в основе сюжет, воплощённый в сценарии и интерпретируемый режиссёром, который создаётся с помощью 
    //актёрской игры, операторского и прочих искусств. 
    class Film : IDescription
    {
        //свойства
        public string Title { get; set; }
        public string Genres { get; set; }
        public  Director Director { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Description { get; set; }

        //конструктор
        public Film(string title)
        {
            Title = title;
        }

        //реализация метода интерфейса
        public void PrintDescription()
        {
            Console.WriteLine($"Описание \"{Title}\" : {Description}");
        }

        public override string ToString()
        {
            return $"-> Тип : {GetType()}, " +
                $"Название: {Title}// Жанры: {Genres}// Режиссёр: {Director}" +
                $" //Продолжительность: {DurationMinutes}// Дата премьеры: {PremiereDate}// Описание: {Description}";
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
            return $"-> Тип : {GetType()}, " +
                $"Название: {Title}// В главных ролях: {MainActors}";
        }
    }

    //Мультфильм
    class Cartoon : Film
    {
        public Cartoon(string title) : base(title) { }

        //принцип создания мультфильма: Пластилиновый, Рисованный, Кукольный, Компьютерный, Художественный
        public string WayToCreate { get; set; }

        public override string ToString()
        {
            return $"-> Тип : {GetType()}, " +
                $"Название: {Title}// Принцип создания мультфильма: {WayToCreate}";
        }
    }

    //Телевизионная программа
    class TVprogram : Film
    {
        public TVprogram(string title) : base(title) { }

        //ведущий
        public string Presenter { get; set; }

        public override string ToString()
        {
            return $"-> Тип : {GetType()}, " +
                $"Название: {Title}// Ведущий: {Presenter}";
        }
    }
    //------------------------------------------------------

    //------------------------------------------------------
    //sealed - значит от класса News нельзя наследовать
    sealed class News
    {
        //название ТВ канала
        public string ChannelName{ get; set; }
        public string Presenter { get; set; }
    }
    //------------------------------------------------------

    //------------------------------------------------------
    partial class Advertising : DescriptionClass, IDescription
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

        //реализация метода интерфейса IDescription
        void IDescription.PrintDescription()
        {
            Console.WriteLine($"(интерфейс) Описание \"{Title}\" : {Description}");
        }

        public override void PrintDescription()
        {
            Console.WriteLine($"(абстрактный класс) Описание \"{Title}\" : {Description}");
        }
    }

    //------------------------------------------------------
    class Printer
    {
        public void IAmPrinting(IDescription obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //задание 4, вызов одноименного метода 
            Advertising adv1 = new Advertising("adv1");
            adv1.PrintDescription(); //вызовется переопределение абстрактного метода
            ((IDescription)adv1).PrintDescription(); //вызовется реализация метода интерфейса

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            //задание 5

            //~~~~~~~~~~~~~~~~~~~~Ссылка типа абстрактного класса~~~~~~~~~~~~~~~~~~~~
            //Создаем объект типа Director, ссылку на объект передаем в переменную типа Person
            //Тип Person является абстрактным классом, от которого Director наследуется
            //Таким образом у нас ссылка типа Person, которая хранит данные типа Director
            Person P_NarDir = new Director("Наруто", "Узумаки");

            //Получение данных
            //P_NarDir.SaySmth(); //класс Director содержит метод SaySmth, ссылка типа Person не имеет доступа к этому методу (ошибка на этапе компиляции)

            //явное преобразование
            Director D_NarDir = P_NarDir as Director;
            //Получение данных
            D_NarDir.SaySmth(); //таким образом тип ссылки ограничивает область доступных данных и методов

            if (D_NarDir != null)
            {
                //Переменная, типа Director, записанная по ссылке Person, может быть записана по ссылке типа Director при явном преобразовании к этому типу
                Console.WriteLine("\n+ Преобразование ссылки типа абстрактного класса в ссылку типа класса, " +
                        "объект которого хранила ссылка типа абстрактного класса, удалось!");
            }
            else
            {
                Console.WriteLine("\n- Преобразование ссылки типа абстрактного класса в ссылку типа класса, " +
                        "объект которого хранила ссылка типа абстрактного класса, НЕ удалось!");
            }

            bool P_NarDir_is_Dir = P_NarDir is Director;
            if (P_NarDir_is_Dir)
            {
                Console.WriteLine("\nPerson P_NarDir = new Director(\"Наруто\", \"Узумаки\"); =>" +
                    " P_NarDir типа Director, Person - абстрактный класс");
            }
            else
            {
                Console.WriteLine("\nPerson P_NarDir = new Director(\"Наруто\", \"Узумаки\"); =>" +
                    " P_NarDir НЕ типа Director, Person - абстрактный класс");
            }

            //~~~~~~~~~~~~~~~~~~~~Ссылка типа интерфейса~~~~~~~~~~~~~~~~~~~~
            IDescription Inter_NarAdv = new Advertising("Йоу собаки");

            //Опять же, доступны только методы реализованного интерфейса (в нашем случае метод PrintDescription интерфейса IDescription)
            //Inter_NarAdv.Title; //ошибка

            Advertising Adv_NarAdv = Inter_NarAdv as Advertising;

            if (Adv_NarAdv != null)
            {
                Console.WriteLine("\n+ Преобразование ссылки типа интерфейса в ссылку типа класса, " +
                    "объект которого хранила интерфейсная ссылка, удалось!");
            }
            else
            {
                Console.WriteLine("\n- Преобразование ссылки типа интерфейса в ссылку типа класса, " +
                    "объект которого хранила интерфейсная ссылка, НЕ удалось!");

            }

            bool Inter_NarAdv_is_Adv = Inter_NarAdv is Advertising;
            if (Inter_NarAdv_is_Adv)
            {
                Console.WriteLine("\nIDescription Inter_NarAdv = new Advertising(\"Йоу собаки\"); =>" +
                    " Inter_NarAdv типа Advertising, nIDescription - интерфейс");
            }
            else
            {
                Console.WriteLine("\nPerson P_NarDir = new Director(\"Наруто\", \"Узумаки\"); =>" +
                    " Inter_NarAdv НЕ типа Advertising, nIDescription - интерфейс");
            }


            //задание 6
            Film NarF = new Film("Гав!");
            FeatureFilm NarFeature = new FeatureFilm("Анимационные псы");
            TVprogram NarProg = new TVprogram("Поиск покинувших деревню");

            Console.WriteLine("\n~~~~~~~~~Вызов переопределенного метода ToString~~~~~~~~~\n");
            Console.WriteLine(NarF.ToString());
            Console.WriteLine(NarFeature.ToString());
            Console.WriteLine(NarProg.ToString());

            //7 задание
            Console.WriteLine("\n~~~~~~~~~Вызов полиморфного метода IAmPrinting у объекта типа Printer~~~~~~~~~\n");

            Printer myPrinter = new Printer();

            object[] myClassesArray = new object[] { NarF, NarFeature, NarProg };

            foreach (dynamic obj in myClassesArray)
            {
                myPrinter.IAmPrinting(obj);
            }
            
        }
    }
}


