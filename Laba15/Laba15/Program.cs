using System;
using System.Reflection;
using System.Threading;

namespace Laba15
{

    partial class Program
    {
        static void Main(string[] args)
        {
            // 1 (запись информации о запущенных процессах в файл)
            procInfo();

            // 2 (исследование текущего домена)
            AppDomain curDom = AppDomain.CurrentDomain;

            string curDomInfo = $"Имя домена приложения: {curDom.FriendlyName}\n" +
                $"Каталог домена: {curDom.BaseDirectory}\n" +
                $"Сборки домена:\n";

            Assembly[] assemblies = curDom.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                curDomInfo += asm.GetName().Name + "\n";
            }

            Console.WriteLine(curDomInfo);

            // 3 
            Console.Write("Введите число n для поиска простых чисел в диапазоне от 1 до n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Thread primeNumsThread = new Thread(() => primeNums(n));
            // запускаем в потоке primeNumsThread метод primeNums
            primeNumsThread.Start();

            // 4
            Console.Write("Введите число n для поиска нечетных и четных чисел в диапазоне от 1 до n: ");
            int odd_even_n = Convert.ToInt32(Console.ReadLine());

            Thread oddThread = new Thread(() => oddNums(odd_even_n));
            Thread evenThread = new Thread(() => evenNums(odd_even_n));

            evenThread.Start();
            oddThread.Start();

            // 5
            TimerCallback tm = new TimerCallback(methodForTimer);
            Timer timer = new Timer(tm, null, 0, 10);
        }
    }
}
