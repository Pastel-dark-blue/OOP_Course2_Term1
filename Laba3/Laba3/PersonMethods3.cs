using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3
{

    partial class Student
    {
        //вывод количества созданных объектов класса Student
        public static void amount_of_obj()
        {
            Console.WriteLine("Количество созданных экземпляров класса Student : " + count);
        }
        //---------------------------------------

        //вывод информации о студенте
        public override string ToString()
        {
            return $"\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                $"ID : {id}\n" +
                $"Surname : {surname}\n" +
                $"Name : {name}\n" +
                $"Middle name : {middle_name}\n" +
                $"Birthday date : {bday_date}\n" +
                $"Phone number : {Phone_number}\n" +
                $"Faculty : {faculty}\n" +
                $"Course : {Course}\n" +
                $"Group : {Group}\n" +
                $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
        }
        //---------------------------------------

        //хеш-код студента
        public override int GetHashCode()
        {
            //полученное значение типа DateTime при помощи метода ToString() приводим к строке вида
            //"день.месяц.год часы:минуты:секунды" и далеее к массиву [день, месяц, ... , секунды]
            string[] bday = (this.bday_date.ToString()).Split(' ', ':', '.');
            int sum = 0;
            //конвертирует значения из массива в тип int и складываем
            foreach (string i in bday)
            {
                sum += Convert.ToInt32(i);
            }

            //теперь к полученной ранее сумме добавлем ASCII-коды символов фамилии
            foreach(char i in this.surname)
            {
                sum += (int)i;
            }

            //и символов факультета
            foreach (char i in this.faculty)
            {
                sum += (int)i;
            }

            //полученная сумма, умноженная на день рождения и есть хеш-код
            return sum* Convert.ToInt32(bday[0]);
        }
        //---------------------------------------

        //сравнение объектов
        public override bool Equals(object obj)
        {
            //типы сравниваемых объектов должны быть одинаковыми
            if (obj.GetType() != this.GetType())
                return false;

            //obj приводим к виду объекта типа Student
            Student st = (Student)obj;
            return (
                this.surname == st.surname &&
                this.bday_date == st.bday_date &&
                this.faculty == st.faculty 
                );
        }
        //---------------------------------------

        //переход студента на следующий курс
        public void nextCourse()
        {
            //вызываем метод, в котором в переменную mes запишется сообщение о переводе
            changeCourse(out string mes);
            Console.Write(mes);
        }

        private void changeCourse(out string mes)
        {
            Course++;
            mes = $"\nСтудент переведен на {Course} курс\n";
        }
        //---------------------------------------

        //создадим метод для получения адреса студента
        public void getAdress(ref string adress)
        {
            adress = this.adress;
        }
        //---------------------------------------

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
