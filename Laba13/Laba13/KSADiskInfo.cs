using System;
using System.IO;

namespace Laba13
{
    class KSADiskInfo
    {
        public delegate void InfoAboutAction(string action, DateTime date);
        public static event InfoAboutAction Notify; 

        public static void driveInfoString()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            string info = "";

            foreach (DriveInfo dr in drives)
            {
                info += "========================== Диск: " + dr.Name + " ==========================\n" +
                    "Свободное место на диске (в байтах): " + dr.TotalFreeSpace + "\n" +
                    "Доступное место на диске (в байтах)" + dr.AvailableFreeSpace + "\n" +
                    "Общий размер диска (в байтах)" + dr.TotalSize + "\n" +
                    "Имя файловой системы: " + dr.DriveFormat + "\n" +
                    "Метка тома: " + dr.VolumeLabel + "\n";
            }

            Console.WriteLine(info);

            KSADiskInfo.Notify += KSALog.ActionsOfUser; // добавляем событию Notify обработчик
            Notify("Вывод информации о дисках", DateTime.Now); // уведомляем обработчиков события о совершении действия
        }
    }
}
