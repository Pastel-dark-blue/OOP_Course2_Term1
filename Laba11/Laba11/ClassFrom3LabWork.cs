using System;

namespace Laba11
{
    class Student
    {
        public Student(
            string name, 
            string surname, 
            DateTime bday_date, 
            string faculty, 
            string speciality,
            int group)
        {
            this.name = name;
            this.surname = surname;
            this.bday_date = bday_date;
            this.faculty = faculty;
            this.speciality = speciality;
            this.Group = group;

        }

        //---------------------------------------

        public string surname { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public DateTime bday_date { get; set; }

        public string faculty { get; set; }
        public string speciality { get; set; }

        private int group;
        public int Group
        {
            set
            {
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

        //вывод информации о студенте
        public override string ToString()
        {
            return $"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                $"Имя : {name}\n" +
                $"Фамилия : {surname}\n" +
                $"Дата рождения : {bday_date}\n" +
                $"Факультет : {faculty}\n" +
                $"Специальность : {speciality}\n" +
                $"Группа : {Group}\n" +
                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
        }

        //расчет возраста студента
        public int age()
        {
            var today = DateTime.Today;

            var age = today.Year - this.bday_date.Year;

            //отнимаем полученный возраст от сегодняшней даты
            //если в этом году у студента ещё не было дня рождения, то результат будет меньше даты дня рождения студента
            //так как age - это возраст, которого достигнет человек в этом году, то отнимаем 1 для получения текущего возраста
            if (this.bday_date.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
