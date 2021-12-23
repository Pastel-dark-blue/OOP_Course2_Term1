using System;
using System.IO;

// Так как нужно получить информацию об определенном директории, используем класс DirectoryInfo

namespace Laba13
{
    class KSADirInfo
    {
        public delegate void InfoAboutAction(string action, DateTime date);
        public static event InfoAboutAction Notify;

        public static void dirInfoString(string path)
        {
            if (Directory.Exists(path))
            {
                int amountOfFiles = Directory.GetFiles(path).Length;
                DateTime dateOfCreation = Directory.GetCreationTime(path);
                int amoutOfSubdirs = Directory.GetDirectories(path).Length;
                DirectoryInfo parent = Directory.GetParent(path);

                string info = "========================== Путь к директорию: " + path + " ==========================\n" +
                    "Количество файлов в директории: " + amountOfFiles + "\n" +
                    "Дата создания: " + dateOfCreation + "\n" +
                    "Количество поддиректорий: " + amoutOfSubdirs + "\n" +
                    "Родительский директорий: " + parent + "\n";

                Console.WriteLine(info);
            }
            else
            {
                Console.WriteLine("Указанного директория не существует\n");
            }

            KSADirInfo.Notify += KSALog.ActionsOfUser; // добавляем событию Notify обработчик
            Notify("Вывод информации о директории " + path, DateTime.Now); // уведомляем обработчиков события о совершении действия
        }
    }
}
