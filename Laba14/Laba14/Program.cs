using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace Laba14
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1
            Console.WriteLine("\n---------------------- СЕРИАЛИЗАЦИЯ ОБЪЕКТОВ ----------------------\n");

            // --------------- BINARY ---------------
            string path1 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\binary.txt";

            Film f1 = new Film
            {
                Title = "Film 1",
                DurationMinutes = 87,
                rating = 3.7f,
                FilmCompany = new Company() { company = "company 1" }
            };

            BinaryFormatter formatterBinary = new BinaryFormatter();

            using (FileStream fs = new FileStream(path1, FileMode.OpenOrCreate))
            {
                formatterBinary.Serialize(fs, f1);
                Console.WriteLine("-> Объект сериализован");
            }

            using (FileStream fs = new FileStream(path1, FileMode.OpenOrCreate))
            {
                Film desFilm = (Film)formatterBinary.Deserialize(fs);

                Console.WriteLine("-> Объект десериализован");
                Console.WriteLine($"Название: {desFilm.Title}\n" +
                    $"продолжительность: {desFilm.DurationMinutes}\n" +
                    $"рейтинг: {desFilm.rating}\n" +
                    $"компания производства: {desFilm.FilmCompany.company}\n");
            }

            // --------------- JSON ---------------
            string path2 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\json.json";

            FeatureFilm f2 = new FeatureFilm
            {
                Title = "Film 2",
                DurationMinutes = 96,
                rating = 3.3f,
                FilmCompany = new Company() { company = "company 2" }
            };

            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                // установка пробелов
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                await JsonSerializer.SerializeAsync<FeatureFilm>(fs, f2, options);
                Console.WriteLine("-> Данные сохранены в файл");
            }

            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                FeatureFilm objFromJson = await JsonSerializer.DeserializeAsync<FeatureFilm>(fs);

                Console.WriteLine("-> Объект десериализован");
                Console.WriteLine($"Название: {objFromJson.Title}\n" +
                    $"продолжительность: {objFromJson.DurationMinutes}\n" +
                    $"рейтинг: {objFromJson.rating}\n" +
                    $"компания производства: {objFromJson.FilmCompany.company}\n");
            }

            // --------------- XML ---------------
            string path3 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\xml.xml";

            Film f3 = new Film
            {
                Title = "Film 3",
                DurationMinutes = 125,
                rating = 4.9f,
                FilmCompany = new Company() { company = "company 3" }
            };

            // прописываем поле rating, которое в классе Film нужно проигнорировать XmlIgnore = true (по умолчанию false)
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            overrides.Add(typeof(Film), "rating", new XmlAttributes { XmlIgnore = true });

            XmlSerializer formatterXml = new XmlSerializer(typeof(Film), overrides);

            using (FileStream fs = new FileStream(path3, FileMode.OpenOrCreate))
            {
                formatterXml.Serialize(fs, f3);
                Console.WriteLine("-> Объект сериализован");
            }

            using (FileStream fs = new FileStream(path3, FileMode.OpenOrCreate))
            {
                Film xmlFilm = (Film)formatterXml.Deserialize(fs);
                Console.WriteLine("-> Объект десериализован");

                Console.WriteLine($"Название: {xmlFilm.Title}\n" +
                    $"продолжительность: {xmlFilm.DurationMinutes}\n" +
                    $"рейтинг: {xmlFilm.rating}\n" +
                    $"компания производства: {xmlFilm.FilmCompany.company}\n");
            }

            // 2
            Console.WriteLine("\n---------------------- СЕРИАЛИЗАЦИЯ МАССИВОВ ОБЪЕКТОВ ----------------------\n");
            Film[] films = new Film[] { f1, f2, f3 };

            // --------------- BINARY ---------------
            string path4 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\arrayBin.txt";

            BinaryFormatter binFormArray = new BinaryFormatter();

            using (FileStream fs = new FileStream(path4, FileMode.OpenOrCreate)) 
            {
                binFormArray.Serialize(fs, films);
                Console.WriteLine("-> Объекты сериализованы");
            }

            using (FileStream fs = new FileStream(path4, FileMode.OpenOrCreate))
            {
                Film[] desFilms = (Film[])binFormArray.Deserialize(fs);
                Console.WriteLine("-> Объекты десериализованы");

                foreach(var film in desFilms)
                {
                    Console.WriteLine($"Название: {film.Title}\n" +
                                $"продолжительность: {film.DurationMinutes}\n" +
                                $"рейтинг: {film.rating}\n" +
                                $"компания производства: {film.FilmCompany.company}\n");
                }
            }

            // --------------- JSON ---------------
            string path5 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\arrayJson.json";

            using (FileStream fs = new FileStream(path5, FileMode.OpenOrCreate))
            {
                // установка пробелов
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                await JsonSerializer.SerializeAsync<Film[]>(fs, films, options);
                Console.WriteLine("-> Объекты сериализованы");
            }

            using (FileStream fs = new FileStream(path5, FileMode.OpenOrCreate))
            {
                Film[] objFromJson = await JsonSerializer.DeserializeAsync<Film[]>(fs);

                Console.WriteLine("-> Объекты десериализованы");
                foreach (var film in objFromJson)
                {
                    Console.WriteLine($"Название: {film.Title}\n" +
                                $"продолжительность: {film.DurationMinutes}\n" +
                                $"рейтинг: {film.rating}\n" +
                                $"компания производства: {film.FilmCompany.company}\n");
                }
            }

            // --------------- XML ---------------
            string path6 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\arrayXml.xml";

            XmlSerializer formatterArrayXml = new XmlSerializer(typeof(Film[]), overrides);

            using (FileStream fs = new FileStream(path6, FileMode.OpenOrCreate))
            {
                formatterArrayXml.Serialize(fs, films);
                Console.WriteLine("-> Объекты сериализованы");
            }

            using (FileStream fs = new FileStream(path6, FileMode.OpenOrCreate))
            {
                Film[] xmlFilms = (Film[])formatterArrayXml.Deserialize(fs);
                Console.WriteLine("-> Объекты десериализованы");

                foreach (var film in xmlFilms)
                {
                    Console.WriteLine($"Название: {film.Title}\n" +
                                $"продолжительность: {film.DurationMinutes}\n" +
                                $"рейтинг: {film.rating}\n" +
                                $"компания производства: {film.FilmCompany.company}\n");
                }
            }


            // 3
            //  XPATH
            Console.WriteLine("\n---------------------- XPATH ----------------------\n");

            // XmlDocument представляет весь xml-документ
            XmlDocument xDoc = new XmlDocument();
            if (File.Exists(path6))
            {
                Console.WriteLine("Селектор 1 (//FilmCompany/company):");
                xDoc.Load(path6);
                var childNodes = xDoc.SelectNodes("//FilmCompany/company");

                foreach(XmlNode node in childNodes)
                {
                    Console.WriteLine(node.InnerText);
                }
            }

            if (File.Exists(path6))
            {
                Console.WriteLine("\nСелектор 2 (FilmCompany[company = 'company 2']):");
                xDoc.Load(path6);
                var childNodes = xDoc.SelectNodes("//FilmCompany[company = 'company 2']");

                foreach (XmlNode node in childNodes)
                {
                    Console.WriteLine(node.InnerText);
                }
            }


            // 4
            // LINQ TO XML
            Console.WriteLine("\n---------------------- LINQ TO XML ----------------------\n");

            // Создание XML-документа
            XDocument newDoc = new XDocument(
                new XElement("students",
                    new XElement("student",
                        new XAttribute("ed_form", "бюджет"),
                        new XElement("surname", "Хмельная"),
                        new XElement("first_name", "Ольга"),
                        new XElement("patronymic", "Андреевна"),
                        new XElement("year_of_birth", 2001)
                    ),
                    new XElement("student",
                        new XAttribute("ed_form", "бюджет"),
                        new XElement("surname", "Зернович"),
                        new XElement("first_name", "Ева"),
                        new XElement("patronymic", "Евгеньевна"),
                        new XElement("year_of_birth", 2004)
                    ),
                    new XElement("student",
                        new XAttribute("ed_form", "платная"),
                        new XElement("surname", "Лаканов"),
                        new XElement("first_name", "Иван"),
                        new XElement("patronymic", "Георгиевич"),
                        new XElement("year_of_birth", 2002)
                    )
                )
            );

            string path7 = @"D:\ООП_2к_1с\OOP_Course2_Term1\Laba14\xmlToLinq.xml";
            newDoc.Save(path7);
            Console.WriteLine("Xml-документ был создан\n");

            // linq запросы
            if (File.Exists(path7))
            {
                XDocument xmlLinqDoc = XDocument.Load(path7);

                // 1 запрос (выбор студентов родившихся в 2002 и позже)
                var birthSelection = from stud in xmlLinqDoc.Element("students").Elements("student")
                                   where Convert.ToInt32(stud.Element("year_of_birth").Value) <= 2002
                                   select stud;

                foreach(var st in birthSelection)
                { 
                    Console.WriteLine(st.Element("surname").Value);
                }
                Console.WriteLine();

                // 2 запрос (перебор определенных элементов и вывод их значений)
                foreach(XElement st in xmlLinqDoc.Element("students").Elements("student"))
                {
                    XAttribute nameAttr = st.Attribute("ed_form");
                    XElement surnameEl = st.Element("surname");
                    XElement FirstNameEl = st.Element("first_name");

                    Console.WriteLine($"Фамилия: {surnameEl.Value}\n" +
                        $"Имя: {FirstNameEl.Value}\n" +
                        $"Форма обучения: {nameAttr.Value}\n");
                }

                // 3 запрос (выбор студентов на бюджетной форме обучения)
                var edFormSelection = from stud in xmlLinqDoc.Element("students").Elements("student")
                                      where stud.Attribute("ed_form").Value == "бюджет"
                                      select stud;

                foreach (var st in edFormSelection)
                {
                    Console.WriteLine(st.Element("surname").Value);
                }
                Console.WriteLine();
            }
        }
    }
}

