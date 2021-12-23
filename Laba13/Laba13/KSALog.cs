using System;
using System.IO;
using System.Text;

namespace Laba13
{
    class KSALog
    {
        public static void ActionsOfUser(string action, DateTime date)
        {
            try
            {
                string path = @"D:\ООП_2к_1с\Laba13\KSALogFile.txt";

                using (StreamWriter swFile = new StreamWriter(path, true)) 
                {
                    swFile.Write(action + " ->Время: " + date + "\n\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ActionsForTheLastHour()
        {
            try
            {
                string path = @"D:\ООП_2к_1с\Laba13\KSALogFile.txt";

                DateTime lastHour = DateTime.Now;
                lastHour.AddHours(-1);

                if (File.Exists(path))
                {
                    int amountOfNotesForLastHour = 0;
                    
                    if (File.GetLastWriteTime(path) < lastHour)
                    {
                        string notes = "";

                        using (StreamReader srFile = new StreamReader(path))
                        {
                            string line = srFile.ReadLine();
                            while (line != null) 
                            {
                                amountOfNotesForLastHour++;
                                line = srFile.ReadLine();
                                notes += line + "\n";
                            }
                            amountOfNotesForLastHour /= 2; // в конце каждой записи добавлялся перенос строки
                            Console.WriteLine("Количество записей за последний час: " + amountOfNotesForLastHour);
                            Console.WriteLine("Записи за последний час" + notes);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
