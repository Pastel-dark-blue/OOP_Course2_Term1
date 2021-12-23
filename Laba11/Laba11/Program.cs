using System;
using System.Collections.Generic;
using System.Linq; 

namespace Laba11
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 ЗАДАНИЕ
            //Задайте массив типа string, содержащий 12 месяцев(June, July, May, December, January ….).
            //Используя LINQ to Object напишите запрос выбирающий последовательность месяцев с длиной 
            //строки равной n, запрос возвращающий только летние и зимние месяцы, запрос вывода месяцев 
            //в алфавитном порядке, запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х..
                
            string[] months = { "January", "February", "March", "April", "May",
                     "June", "July", "August", "September", "October", "November", "December" };
            foreach (string month in months)
            {
                Console.Write(month + " ");
            }
            //
            Console.Write("\n\n-->Введите какой длины названия месяцев нужно выбрать : ");
            int n = Convert.ToInt32(Console.ReadLine());

            var monthsLen = from month in months
                            where month.Length == n
                            select month;

            foreach(string month in monthsLen)
            {
                Console.Write(month + " ");
            }
            //
            Console.WriteLine("\n\n-->Выборка из только зимних и летних месяцев последовательности");
            string[] sumWintMonths_arr = { "January", "February", "June", "July", "August", "December" };
            var sumWintMonths_request = months.Intersect(sumWintMonths_arr);
            foreach (string month in sumWintMonths_request)
            {
                Console.Write(month + " ");
            }
            //
            //Каждый раз, когда в выборке появлется буква 'u', название которому она принадлежит входит в выборку
            //Так как в названии может быть несколько 'u', то один и тот же месяц может попасть в выборку несколько раз
            //Поэтому используем метод Distinct(), который убирает дублирующиеся элементы
            int amountMonthsWithLet_u = (from month in months
                                         from letter in month
                                         where letter == 'u' && month.Length >= 4
                                         select month).Distinct().Count();
            Console.WriteLine("\n\n-->Количество названий месяцев с буквой \"u\" = " + amountMonthsWithLet_u);
            //
            var sorted = from month in months
                         orderby month
                         select month;

            Console.WriteLine("\n-->Список, отсортированный по алфавиту");
            foreach (string month in sorted)
            {
                Console.Write(month + " ");
            }

            //2 ЗАДАНИЕ 
            //Создайте коллекцию List<T> и параметризируйте ее типом(классом) из лабораторной №3
            //(при необходимости реализуйте нужные интерфейсы).Заполните ее минимум 8 элементами.
            Student st1 = new Student("Иван", "Хмельной", new DateTime(2000, 10, 23), "ФИТ", "ПОИБМС", 7);
            Student st2 = new Student("Иван", "Сырок", new DateTime(2006, 9, 22), "ФИТ", "ПОИБМС", 7);
            Student st3 = new Student("Ито", "Шинджи", new DateTime(1988, 12, 22), "ФИТ", "ПОИБМС", 7);
            Student st4 = new Student("Мицухаши", "Такаши", new DateTime(1988, 12, 22), "ФИТ", "ПОИБМС", 7);
            Student st5 = new Student("Маки", "Зенин", new DateTime(2000, 7, 26), "ФИТ", "ДЭиВИ", 10);
            Student st6 = new Student("Мегуми", "Фушигуро", new DateTime(2001, 1, 2), "ФИТ", "ДЭиВИ", 9);
            Student st7 = new Student("Тодзи", "Фушигуро", new DateTime(1980, 6, 8), "ФИТ", "ПОИБМС", 7);
            Student st8 = new Student("Юдзи", "Итадори", new DateTime(2002, 12, 18), "ФИТ", "ДЭиВИ", 9);
            Student st9 = new Student("Сугуру", "Гето", new DateTime(1990, 6, 28), "ФИТ", "ПОИТ", 5);

            List<Student> students = new List<Student>() { st1, st2, st3, st4, st5, st6, st7, st8, st9 };

            //3 ЗАДАНИЕ
            //На основе LINQ сформируйте запросы по вариантам
            Console.WriteLine("\n\n--> Студенты спецальности \"ПОИБМС\", отсортированные по имени и фамилии");
            string spec = "ПОИБМС";
            var specOrdered = from student in students
                              where student.speciality == spec
                              orderby student.name, student.surname
                              select student;
            foreach (var student in specOrdered)
            {
                Console.WriteLine(student.ToString());
            }

            //
            Console.WriteLine("--> Cписок 6 учебной группы, факультета \"ПИМ\"");

            string fac = "ПИМ";
            int gr6 = 6;
            var facGr = from student in students
                        where student.faculty == fac && student.Group == gr6
                        select student;

            foreach (var student in facGr)
            {
                Console.WriteLine(student.ToString());
            }

            //
            Console.WriteLine("--> Вывод информации о самом молодом студенте");

            var youngest_stud_bday_date = students.Max(student => student.bday_date);
            var youngest_stud = from student in students
                                where student.bday_date == youngest_stud_bday_date
                                select student;

            foreach (var student in youngest_stud)
            {
                Console.WriteLine(student.ToString());
            }

            //
            Console.Write("--> Количество студентов 7 группы : ");

            int gr7 = 7;
            var amountStudGr = (from student in students
                                where student.Group == gr7
                                select student).Count();
            var amountStudGr_exMeth = students.Where(student => student.Group == gr7).Count();

            Console.Write(amountStudGr);
            Console.WriteLine(" (запрос Linq), " + amountStudGr_exMeth + " (метод расширения)");

            //
            Console.WriteLine("\n--> Вывод первого студента с именем \"Иван\"");

            string name = "Иван";
            var studName = (from student in students
                           where student.name == name
                           select student).FirstOrDefault();

            if (studName != null)
                Console.WriteLine(studName);
            else
                Console.WriteLine("Ничего не найдено");

            //4 ЗАДАНИЕ
            //Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: 
            //условия, проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения.
            //Выбрать студентов старше 20, сгруппировать их по группам, затем создать новый объект с полями:
            //groupNum - номер группы, Count - количество студентов в группе, studs - массив студентов данной группы
            Console.WriteLine("\n--> Студенты старше 20, разбитые по своим группам\n");
            var myReq = from student in students
                        where student.age() > 20
                        group student by student.Group into gr
                        select new
                        {
                            groupNum = gr.Key,
                            Count = gr.Count(),
                            studs = from st in gr 
                                    select st
                        };
            foreach(var g in myReq)
            {
                Console.WriteLine($"{g.groupNum} группа , число студентов : {g.Count}");
                foreach(Student st in g.studs)
                {
                    Console.WriteLine(st.ToString());
                }
            }

            //5 ЗАДАНИЕ
            //Придумайте запрос с оператором Join
            var characters = new List<Character>(){
                new Character("Киллуа Золдик","Хантер x Хантер"),
                new Character("Курапика","Хантер x Хантер"),
                new Character("Эдвард Элрик","Стальной алхимик"),
                new Character("Грид","Стальной алхимик"),
                new Character("Чосо","Магическая битва"),
                new Character("Куроро Люцифер","Хантер x Хантер"),
                new Character("Гон Фрикс","Хантер x Хантер"),
                new Character("Кугисаки Нобара","Магическая битва"),
            };

            var animes = new List<Anime>(){
                new Anime("Магическая битва"),
                new Anime("Хантер x Хантер"),
                new Anime("Стальной алхимик"),
            };

            var result = characters.Join(animes,
                c => c.anime,
                a => a.name,
                (c, a) => new { character = c.name, anime = a.name });
            foreach(var item in result)
            {
                Console.WriteLine($"Аниме : {item.anime}, персонаж : {item.character}");
            }
        }
    }
}


