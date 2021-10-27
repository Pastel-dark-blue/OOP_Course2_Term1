using System;

//3 ВАРИАНТ(СТУДЕНТ)

namespace Laba3
{
    partial class Student
        {
            //переменная счетчик
            private static int count = 0;
            //---------------------------------------

            //статический конструктор (вызывается один раз при первом использовании класса)
            static Student()
            {
                Console.WriteLine("Начинаем--");
            }
        //---------------------------------------

        //Закрытый конструктор (с модификатором private) не позволяет создавать определенного вида объекты
        //То есть, например наш конструктор не принимает никаких параметров => мы не сможем создать экземпляр класса 
        //без передачи параметров
        private Student() { }
        //---------------------------------------
        
        ////1) конструктор без параметров (из-за закрытого конструктора больше не действителен)
        //public Student()
        //    {
        //        id = Guid.NewGuid();

        //        count++;
        //    }

        //2) конструктор с параметрами
        public Student(string surname, DateTime bday_date, string faculty) //минимальная информация о студенте для его  идентификации
            {
                id = Guid.NewGuid();
                this.surname = surname;
                this.bday_date = bday_date;
                this.faculty = faculty;

                count++;
            }

            //3) конструктор с параметрами
            public Student(
                string surname, 
                string name, 
                string middle_name, 
                DateTime bday_date, 
                string adress, 
                string phone_number, 
                string faculty, 
                int course, 
                int group
                )
            {
                id = Guid.NewGuid();
                this.surname = surname;
                this.name = name;
                this.middle_name = middle_name;
                this.bday_date = bday_date;
                this.Adress = adress;
                this.Phone_number = phone_number;
                this.faculty = faculty;
                this.Course = course;
                this.Group = group;

                count++;
            }
            //---------------------------------------

            //поле-константа (минимальный средний балл для получения стипендии)
            public const float min_scolarship_score = 5.0f;
            //---------------------------------------

            //поле - только для чтения
            public readonly Guid id; //Guid - спец. структура для создания уникальных id
                                     //---------------------------------------

        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public DateTime bday_date { get; set; }

        //в качестве адреса принимаем строку, где идет сначала страна, город, название улицы, затем номер дома и квартиры
        //проверяем, что 2 последних значения числа
        private string adress;
        public string Adress {
                set
                {
                    string[] country_city_street_house_flat = value.Split(' ');

                    if (country_city_street_house_flat.Length < 5)
                    {
                        adress = $"адрес указан неправильно";
                        return;
                    }

                    try
                    {
                        Convert.ToUInt32(country_city_street_house_flat[3]);
                        Convert.ToUInt32(country_city_street_house_flat[4]);
                    }
                    catch
                    {
                        adress = $"адрес указан неправильно";
                        return;
                    }

                    adress = $"Страна {country_city_street_house_flat[0]}, город {country_city_street_house_flat[1]}\n" +
                           $"Улица {country_city_street_house_flat[2]} дом {country_city_street_house_flat[3]}, квартира {country_city_street_house_flat[4]}";
                }
            }

            private string phone_number;
        public string Phone_number
            {
                set
                {
                    if (value.Length != 9)
                    {
                        phone_number = "номер был указал неправильно";
                    }
                    else
                    {
                        phone_number = "+375" + value;
                    }
                }

                get
                {
                    return phone_number;
                }
            }

        public string faculty { get; set; }

            private int course;
        public int Course
            {
                set
                {
                    if (value < 0 || value > 5)
                    {
                       course = 0;
                    }
                    else
                    {
                        course = value;
                    }
                }

                get
                {
                    return course;
                }
            }

            private int group;
        public int Group {
                set {
                    if (value < 0 || value > 10)
                    {
                        group = 0;
                    }
                    else
                    {
                        group = value;
                    }
                }

                get
                {
                    return group;
                }
            }
            //---------------------------------------

        }
    class Program3
    {
        static void Main(string[] args)
        {
            //Фамилия(строка), Имя(строка), Отчество(строка), дата рождения(объект типа DateTime), 
            //адрес(строка (Страна Город Улица Дом Квартира)), номер телефона(строка (без +375!)), факультет(строка), курс(число (1-5)), группа(число (1-10)) 

            //создание объектов с помощью разных конструкторов
            //Student st0 = new Student(); (невозможно из-за закрытого конструктора)
            Student st1 = new Student("Хмельной", new DateTime(2000, 10, 23), "ФИТ");

            Student st2 = new Student("Творожный", "Сырок", "Фундук-какао", new DateTime(2021, 9, 22),
                "Беларусь Слуцк Тутаринова 45 0", "179555502", "Клецкая крыначка", 1, 8);

            Student st3 = new Student("Хмельной", new DateTime(2000, 10, 23), "ФИТ");

            Student st4 = new Student("Ито", "Шинджи", "-", new DateTime(1988, 12, 22),
    "Япония Токио Улица 14 0", "379455502", "Манга", 1, 7);

            Student st5 = new Student("Мицухаши", "Такаши", "-", new DateTime(1988, 9, 22),
                "Япония Токио Улица 14 0", "178885502", "Манга", 1, 7);
             //
            Console.WriteLine("\n***Количество созданных объектов типа Student***");
            Student.amount_of_obj();

            //
            Console.WriteLine("\n***Использование метода с ref-параметром (получение адреса)***");
            string adress = "";
            st2.getAdress(ref adress);
            Console.WriteLine(adress);

            //
            Console.WriteLine("\n***Сравнение объектов***");
            Console.WriteLine(st2.Equals(st3));
            Console.WriteLine(st1.Equals(st3));

            //
            Console.WriteLine("\n***Хеш-коды***");
            Console.WriteLine(st1.GetHashCode());
            Console.WriteLine("-------------------------------");
            Console.WriteLine(st2.GetHashCode());
            Console.WriteLine("-------------------------------");
            Console.WriteLine(st3.GetHashCode());

            //
            Console.WriteLine("\n***Объекты в виде строк***");
            Console.WriteLine(st2.ToString());
            Console.WriteLine(st3.ToString());

            //
            Console.WriteLine("\n***Функция с out-параметром (переход студента на следующий курс)***");
            st2.nextCourse();

            //
            Console.WriteLine("\n***Тип созданного объекта***");
            Console.WriteLine(st2.GetType());

            //
            Console.WriteLine("\n***Получение значений некоторых свойств объекта***");
            Console.WriteLine($"Имя : {st2.name}, фамилия : {st2.surname}, отчество : {st2.middle_name}");

            //
            Console.Write("\n////////////////////// РАБОТА С МАССИВОМ //////////////////////\n");
            Student[] array = new Student[] { st1, st2, st3, st4, st5 };

            Console.Write("=> Введите факультет, студентов которого необходимо вывести на консоль : ");
            string fac = Console.ReadLine();

            //если не будет найдено студентов с указанного факультета, то в переменной student_is сохранится значение false, иначе true (*)
            bool student_is = false;
            foreach(Student st in array)
            {
                if (st.faculty == fac)
                {
                    Console.WriteLine($"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                $"ID : {st.id}\n" +
                $"Surname : {st.surname}\n" +
                $"Name : {st.name}\n" +
                $"Middle name : {st.middle_name}\n" +
                $"Birthday date : {st.bday_date}\n" +
                $"Phone number : {st.Phone_number}\n" +
                $"Faculty : {st.faculty}\n" +
                $"Course : {st.Course}\n" +
                $"Group : {st.Group}\n" +
                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

                    student_is = true;          //(*)
                }
            }

            if (!student_is)
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nНа указанном факультете нет студентов\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            }

            Console.Write("=> Введите номер группы, студентов которой необходимо вывести на консоль : ");
            int gr = Convert.ToInt32(Console.ReadLine());

            student_is = false;
            foreach (Student st in array)
            {
                if (st.Group == gr)
                {
                    Console.WriteLine($"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                $"ID : {st.id}\n" +
                $"Surname : {st.surname}\n" +
                $"Name : {st.name}\n" +
                $"Middle name : {st.middle_name}\n" +
                $"Birthday date : {st.bday_date}\n" +
                $"Phone number : {st.Phone_number}\n" +
                $"Faculty : {st.faculty}\n" +
                $"Course : {st.Course}\n" +
                $"Group : {st.Group}\n" +
                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

                    student_is = true;
                }
            }

            if (!student_is)
            {
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nВ указанной группе нет студентов\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            }

            //
            Console.WriteLine("***Получение возрастов студентов***");
            Console.WriteLine($"Студент с датой рождения: {st1.bday_date} => возраст {st1.age()} лет");
            Console.WriteLine($"Студент с датой рождения: {st2.bday_date} => возраст {st2.age()} лет");

            //
            Console.WriteLine($"\n***Анонимный тип***");
            var anon_type = new
            {
                id = new Guid(),
                surname = "Pastel",
                name = "Dark",
                middle_name = "Blue",
                bday_date = new DateTime(2000, 12, 17),
                Adress = "Россия Иркутск Ул 5 6",
                Phone_number = "+375294250143",
                faculty = "ФИТ",
                Course = 1,
                Group = 7
            };
            Console.WriteLine(anon_type);
        }
    }
}

