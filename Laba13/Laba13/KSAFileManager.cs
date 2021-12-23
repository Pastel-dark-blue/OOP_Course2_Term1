using System;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace Laba13
{
    class KSAFileManager
    {
        public delegate void InfoAboutAction(string action, DateTime date);
        public static event InfoAboutAction Notify;

        public static void KSAInspect(string diskName)
        {
            KSAFileManager.Notify += KSALog.ActionsOfUser; // добавляем событию Notify обработчик

            if (diskName.Length < 3)
            {
                Console.WriteLine("-> Введите имя диска в формате -> \"C:\"\", где C - имя диска");
                return;
            }

            // проверяем существует ли диск с заданным именем
            DriveInfo[] allDisks = DriveInfo.GetDrives();
            bool exists = false;

            foreach(DriveInfo d in allDisks)
            {
                if (d.Name == diskName)
                    exists = true;
            }
            // если не существует
            if (!exists)
            {
                Console.WriteLine("-> Диска с именем " + diskName + " на данном компьютере не было найдено");
                return;
            }

            // создаем объект, хранящий информацию о диске с именем diskName
            DriveInfo disk = new DriveInfo(diskName);

            if (disk.IsReady)
            {
                try
                {
                    // получаем корневой директорий диска
                    DirectoryInfo rootDir = disk.RootDirectory;

                    string dirs = "Директории на диске " + diskName + ": ";
                    string files = "Файлы на диске " + diskName + ": ";

                    foreach (var dir in rootDir.GetDirectories())
                    {
                        dirs += "\n" + dir;
                    }
                    dirs += "\n";

                    foreach (var file in rootDir.GetFiles())
                    {
                        files += "\n" + file;
                    }
                    files += "\n";

                    string info = "========================== Информация о диске " + diskName + " ==========================\n" +
                        dirs + files;

                    string dirToCreate = @"D:\ООП_2к_1с\Laba13\KSAInspect";
                    DirectoryInfo newDir;

                    // проверяем, не существует ли уже директория с заданным именем
                    if (Directory.Exists(dirToCreate))
                    {
                        Console.WriteLine("-> Указанный директорий уже существует, новый файл будет создан в нем.");
                    }
                    else //если не существует, создаем его
                    {
                        newDir = Directory.CreateDirectory(dirToCreate);
                        Console.WriteLine("-> Директорий " + newDir.FullName + " создан");
                        Notify("-> Директорий " + newDir.FullName + " создан", DateTime.Now); // уведомляем обработчиков события о совершении действия
                    }

                    // путь к файлу
                    string pathOfFile = dirToCreate + @"\KSADirInfo.txt";

                    using (FileStream fstream = new FileStream(pathOfFile, FileMode.OpenOrCreate))
                    {
                        // преобразуем строку в байты, поскольку FileStream представляет доступ к файлам на уровне байтов
                        byte[] infoInBytes = Encoding.Default.GetBytes(info);

                        // записываем текст в файл, если в нем была другая информация, она перезашется
                        fstream.Write(infoInBytes);

                        Console.WriteLine("-> Информация записана в файл");

                        Notify("Информация о диске " + diskName + " записана в файл " + pathOfFile, DateTime.Now); // уведомляем обработчиков события о совершении действия
                    }

                    string copyFilePath = @"D:\ООП_2к_1с\Laba13\driveInfo.txt";
                    if (!File.Exists(copyFilePath))
                    {
                        // true => целевой файл можно перезаписать
                        File.Copy(pathOfFile, copyFilePath, true);
                        Console.WriteLine("-> Файл " + pathOfFile + @" скопирован в директорий D:\ООП_2к_1с\Laba13 под именем driveInfo.txt");

                        Notify("Файл " + pathOfFile + @" скопирован в директорий D:\ООП_2к_1с\Laba13 под именем driveInfo.txt", DateTime.Now); // уведомляем обработчиков события о совершении действия
                    }
                    else
                    {
                        File.Copy(pathOfFile, copyFilePath, true);
                        Console.WriteLine(@"-> Файл " + copyFilePath + " был перезаписан");

                        Notify(@"Файл " + copyFilePath + " был перезаписан", DateTime.Now); // уведомляем обработчиков события о совершении действия
                    }

                    if (File.Exists(copyFilePath))
                    {
                        File.Delete(pathOfFile);
                        Console.WriteLine("-> Файл " + pathOfFile + " удален");

                        Notify("Файл " + pathOfFile + " удален", DateTime.Now); // уведомляем обработчиков события о совершении действия
                    }
                    else
                    {
                        Console.WriteLine("-> Файл " + pathOfFile + " не был найден");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                }
            }
        }


        public static void KSAExtensionCopy(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("-> Указанного вами директория " + path + " не существует");
                    return;
                }

                string dirToCreate = @"D:\ООП_2к_1с\Laba13\KSAFiles";
                DirectoryInfo newDir = new DirectoryInfo(dirToCreate);

                // проверяем, не существует ли уже директория с заданным именем
                if (Directory.Exists(dirToCreate))
                {
                    Console.WriteLine("\n-> Указанный директорий уже существует, файлы будут добавлены в него");
                }
                else //если не существует, создаем его
                {
                    newDir.Create();
                    Console.WriteLine("\n-> Директорий " + newDir.FullName + " был создан");

                    Notify("Директорий " + newDir.FullName + " был создан", DateTime.Now); // уведомляем обработчиков события о совершении действия
                }

                // получаем полные пути файлов, соответствующих шаблону "*.txt", где * - любое сочетание символов
                string[] files = Directory.GetFiles(path, "*.txt");

                foreach (string file in files)
                {
                    // получаем только имя файла
                    string onlyFileName = Path.GetFileName(file);

                    File.Copy(file, Path.Combine(newDir.FullName, onlyFileName), true);
                }

                // Console.WriteLine(whereToMoveDir) -> D:\ООП_2к_1с\Laba13\KSAInspect\KSAFiles
                // Console.WriteLine(newDir.FullName) -> D:\ООП_2к_1с\Laba13\KSAFiles
                // чтобы переместить один директорий в другой последняя часть обоих путей должна совпадать, а части до существовать
                // совпадающие части нужны для того же, для чего и указание имен файлов в обоих путях (исходном и итоговом) при их перемещении -> 
                // знать под каким именем должен быть получиться итоговый файл, а в нашем случае поддиректорий

                // путь к директорию, куда нужно переместить директорию с файлами заданного расширения, где newDir.Name - имя конечного директория
                string whereToMoveDir = Path.Combine(@"D:\ООП_2к_1с\Laba13\KSAInspect", newDir.Name);
                if (Directory.Exists(whereToMoveDir))
                {
                    Directory.Delete(whereToMoveDir, true);
                    Console.WriteLine("-> Директорий " + whereToMoveDir + " был удален");

                    Notify("Директорий " + whereToMoveDir + " был удален", DateTime.Now); // уведомляем обработчиков события о совершении действия
                }

                newDir.MoveTo(whereToMoveDir);

                Console.WriteLine("-> Директорий " + whereToMoveDir + " был создан");
                Notify("Директорий " + whereToMoveDir + " был создан", DateTime.Now); // уведомляем обработчиков события о совершении действия

                Console.WriteLine("-> Директорий " + newDir.FullName + " был перемещен в директорий " + whereToMoveDir + "\n");
                Notify("Директорий " + newDir.FullName + " был перемещен в директорий " + whereToMoveDir, DateTime.Now); // уведомляем обработчиков события о совершении действия

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        public static void MakeArchive()
        {
            string sourceFolder = @"D:\ООП_2к_1с\Laba13\KSAInspect\KSAFiles"; // исходная папка
            string zipFile = @"D:\ООП_2к_1с\Laba13\KSAInspect\KSAFiles.zip"; // сжатый файл
            string targetFolder = @"D:\ООП_2к_1с\Laba13\KSAInspect\unzipKSAFiles"; // папка, куда распаковывается файл

            try
            {
                if (!Directory.Exists(sourceFolder))
                {
                    Directory.CreateDirectory(sourceFolder);
                }

                if (File.Exists(zipFile))
                {
                    File.Delete(zipFile);
                }

                ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                Console.WriteLine($"-> Папка {sourceFolder} архивирована в файл {zipFile}");
                Notify($"Папка {sourceFolder} архивирована в файл {zipFile}", DateTime.Now); // уведомляем обработчиков события о совершении действия

                if (Directory.Exists(targetFolder))
                {
                    Directory.Delete(targetFolder, true);
                }

                ZipFile.ExtractToDirectory(zipFile, targetFolder);
                Console.WriteLine($"-> Файл {zipFile} распакован в папку {targetFolder}\n");
                Notify($"Файл {zipFile} распакован в папку {targetFolder}", DateTime.Now); // уведомляем обработчиков события о совершении действия
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}
