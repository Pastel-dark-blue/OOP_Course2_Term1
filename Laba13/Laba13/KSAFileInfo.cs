using System;
using System.IO;

namespace Laba13
{
    class KSAFileInfo
    {
        public delegate void InfoAboutAction(string action, DateTime date);
        public static event InfoAboutAction Notify;

        public static void fileInfoString(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                string fullName = file.FullName;
                long len = file.Length;
                string ext = file.Extension;
                string name = file.Name;
                DateTime dateOfCreation = file.CreationTime;
                DateTime dateOfLastChanging = file.LastWriteTime;

                string info = "========================== Полное имя файла: " + fullName + " ==========================\n" +
                    "Имя файла: " + name + "\n" +
                    "Размер (в байтах): " + len + "\n" +
                    "Расширение: " + ext + "\n" +
                    "Дата создания: " + dateOfCreation + "\n" +
                    "Дата внесения последних изменений: " + dateOfLastChanging + "\n";

                Console.WriteLine(info);
            }
            else
            {
                Console.WriteLine("Указанного файла не существует\n");
            }

            KSAFileInfo.Notify += KSALog.ActionsOfUser; // добавляем событию Notify обработчик
            Notify("Вывод информации о файле " + path, DateTime.Now); // уведомляем обработчиков события о совершении действия
        }
    }
}
