using System.Diagnostics;
using System.IO;

namespace Laba15
{
    partial class Program
    {
        public static void procInfo()
        {
            Process[] processes = Process.GetProcesses();

            string info = "Количество запущенных процессов: " + processes.Length + "\n";

            int i = 1;
            foreach (Process process in processes)
            {
                info += $"-> {i}\nИдентификатор процесса: {process.Id}\n" +
                    $"Имя процесса: {process.ProcessName}\n" +
                    $"Базовый приоритет: {process.BasePriority}\n";
                i++;
            }

            string path = @"D:\ООП_2к_1с\Laba15\processesInfo.txt";
            using (StreamWriter swf = new StreamWriter(path))
            {
                swf.Write(info);
            }

            System.Console.WriteLine("Данные о процессах записаны в файл\n");
        }
    }
}
