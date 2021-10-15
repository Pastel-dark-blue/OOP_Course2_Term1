using System;
using System.Text; //для класса StringBuilder

namespace Laba2
{
    class Program2
    {
        //``````````````````` ЗАДАНИЕ 5 ```````````````````
        static public (int, int, int, char) Method(int[] arr, string str)
        {
            int min;
            int max;
            int sum;

            //локальная функция - это функция внутри другой функции (метода)
            void func()
            {
                min = arr[0];
                max = arr[0];
                sum = 0;

                foreach (int num in arr)
                {
                    if (num > max)
                    {
                        max = num;
                    }

                    if (num < min)
                    {
                        min = num;
                    }

                    sum += num;
                }

            }
            func();
            return (max, min, sum, str[0]);
        }

        static void Main(string[] args)
        {

            //``````````````````` ЗАДАНИЕ 1 (a) ```````````````````

            //хранит значение true или false (логические литералы)
            bool f = false;
            bool t = true;

            //хранит целое число от 0 до 255 и занимает 1 байт
            byte byte_num = 255;

            //хранит целое число от -128 до 127 и занимает 1 байт
            sbyte sbyte_neg_num = 10;
            sbyte sbyte_pos_num = -65;

            // хранит целое число от -32768 до 32767 и занимает 2 байта
            short sh_neg_num = -4000;
            short sh_pos_num = 2768;

            //хранит целое число от 0 до 65535 и занимает 2 байта
            ushort ush_num = 64590;

            //хранит целое число от -2147483648 до 2147483647 и занимает 4 байта
            //Все целочисленные литералы по умолчанию представляют значения типа int
            int i_hex_num = 0xFF;   //i_hex_num = 255
            int i_dec_num = -999;

            //хранит целое число от 0 до 4294967295 и занимает 4 байта
            uint ui_num = 80;

            //хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт
            long l_neg_num = -602;
            long l_pos_num = 5339;

            //хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт
            ulong ul_num = 0x3A;    //ul_num = 58

            //хранит число с плавающей точкой от ± 1,5*10^-45 до ± 3,4*10^38, точность ~6-9 цифр и занимает 4 байта
            //В visual studio дробное значение по умолчанию воспринимается как тип double, чтобы явно указать, 
            //что у нас число типа float можно использовать в конце суффикс F/f
            float f_neg_num = -214.3f;
            float f_pos_num = 67.19f;

            //хранит число с плавающей точкой от ±5.0*10^-324 до ±1.7*10^308, точность ~15-17 цифр и занимает 8 байт
            double d_neg_num = -256.16e34;
            double d_pos_num = 45;

            //хранит число с плавающей точкой от ±1.0*10^-28 до ±7.9228*10^28, точность 28-29 цифр и занимает 16 байт
            decimal dec_neg_num = -34.92223m;
            decimal dec_pos_num = 7.21m;

            //хранит одиночный символ в кодировке Unicode и занимает 2 байта
            char symb = 'S';

            Console.WriteLine($"Bool : {f}, {t} \n" +
                $"Byte : {byte_num} \n" +
                $"Sbyte : {sbyte_neg_num}, {sbyte_pos_num} \n" +
                $"Short : {sh_neg_num}, {sh_pos_num} \n" +
                $"Ushort : {ush_num} \n" +
                $"Int : {i_hex_num}, {i_dec_num} \n" +
                $"Uint : {ui_num} \n" +
                $"Long : {l_neg_num}, {l_pos_num} \n" +
                $"Ulong : {ul_num} \n" +
                $"Float : {f_neg_num}, {f_pos_num} \n" +
                $"Double : {d_neg_num}, {d_pos_num} \n" +
                $"Decimal : {dec_neg_num}, {dec_pos_num} \n" +
                $"Char : {symb} \n");

            //``````````````````` ЗАДАНИЕ 1 (b) ```````````````````

            //~~~~~ неявное преобразование

            byte byte_a = 30;
            int int_a = byte_a;

            char symbol = 'A';
            float int_symb = symb;

            byte byte_b = 10;
            float float_b = byte_b;

            long long_c = 9872;
            double double_c = long_c;

            short short_d = -45;
            int int_d = short_d;

            Console.WriteLine($"Неявное преобразование \n" +
                $"byte -> int : {byte_a} \n" +
                $"char -> float : {int_symb} \n" +
                $"byte -> float : {float_b} \n" +
                $"long -> double : {double_c} \n" +
                $"short -> int : {int_d}");

            //~~~~~ явное преобразование

            sbyte sbyte_e = -1;
            byte byte_e = (byte)sbyte_e;

            float float_f = 9.23f;
            byte byte_f = (byte)float_f;

            double double_g = 12.9887615213456;
            float float_g = (float)double_g;

            int int_j = -289;
            sbyte sbyte_j = (sbyte)int_j;

            int int_k = 10;
            short short_k = (short)int_k;

            Console.WriteLine($"\nЯвное преобразование \n" +
                $"sbyte -> byte : {byte_e} \n" +
                $"float -> byte : {byte_f} \n" +
                $"double -> float : {float_g} \n" +
                $"int -> byte : {sbyte_j} \n" +
                $"int -> short : {short_k}");

            //~~~~~ класс Convert

            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Age : ");
            int age = Convert.ToByte(Console.ReadLine());
            Console.WriteLine($"Name : {name}, age : {age}");

            //``````````````````` ЗАДАНИЕ 1 (с) ```````````````````

            //явная упаковка/распаковка
            int a = 10; //данные переменной размещаются в стеке
            object o_a = a; //упаковка (object - базовый класс для всех типов данных в c#, т.к. object - класс, то его данные размечаются в куче)
            //таким образом в переменной o_a получаем ссылку на данные в куче
            int b = (int)o_a; //распаковка

            //неявная упаковка/распаковка
            int c = 1;
            c.GetType(); // возвращает тип данных переменной c
            Console.Write(c + 8);

            //``````````````````` ЗАДАНИЕ 1(d) ```````````````````
            //var - ключевое слово, которое позволяет компилятору выяснить тип переменной
            var a1d = 5;
            var b1d = "I was born on the wrong side of the train tracks";
            var c1d = 9.87f;

            //``````````````````` ЗАДАНИЕ 1(e) ```````````````````
            //свойства Nullable-типа
            int? x = null;
            Console.WriteLine($"x.HasValue : {x.HasValue}"); //x = null, значит выведет False
            Console.WriteLine($"x ?? \"-1\" : {x ?? -1}"); // если x - null, выведет -1, иначе значение x
            //Console.WriteLine($"x.Value : {x.Value}"); //приведет к ошибке, так как x = null
            Console.WriteLine($"x : {x}"); //выведет пустоту

            //математические операции с Nullable-типом
            x = 2;
            int? y = null;
            Console.WriteLine($"\nx = 2, y = null \n" +
                $"x + 3 = {x + 3} \n" +     //5
                $"x < 1 : {x < 1} \n" +     //False
                $"x + y = {x + y}");        //number "+,-,/,*" null = null

            //объекты равны, когда их значения null
            int? a_nullable = null;
            int? b_nullable = null;
            Console.WriteLine($"\na = null, b = null \n" +
                $"a == b : {a == b}"); //True

            //явное приведение Nullable-типа
            float f_a = (float)x; //если Nullable-тип имеет значение отличное от null, то мы можем преобразовать его к другому типу по правиласм преобразования
            Console.WriteLine("\n" + f_a);

            //``````````````````` ЗАДАНИЕ 1 (e) ```````````````````
            var w = 10;
            //w = "Every single one\'s got a story to tell";

            //------------------------------------------------------------------------------------------------------------------------------------

            //``````````````````` ЗАДАНИЕ 2 (a) ```````````````````
            string st1 = "Ito";
            string st2 = "Mitsu";
            //Для сравнения строк применяется статический метод Compare
            //Если первая строка по алфавиту стоит выше второй, то возвращается число меньше нуля. В противном случае возвращается число больше нуля. 
            //И третий случай - если строки равны, то возвращается число 0.
            Console.WriteLine(String.Compare(st1, st2));

            //``````````````````` ЗАДАНИЕ 2(b) ```````````````````
            string s1 = "Broken boy, ";
            string s2 = "How does ";
            string s3 = "it feel?";

            string concat_plus = s1 + s2 + s3;
            string concat_method = String.Concat(s1, s2, s3);
            string concat_join = String.Join("", s1, s2, s3);

            Console.WriteLine("***Concatenation***\n" +
                $"\"+\" operation : {concat_plus}\n" +
                $"method Concat : {concat_method}\n" +
                $"method Join : {concat_join}\n");

            string copy_method = String.Copy(s1);
            string assignment = s1; //приравнивание, не уверена, что так можно копировать !!!!
            string sub_method = s1.Substring(0, s1.Length);

            Console.WriteLine($"***Coping***\n" +
                $"method Copy : {copy_method}\n" +
                $"assignment : {assignment}\n" +
                $"method Substring : {sub_method}\n");

            string substr1 = s3.Substring(s3.Length - 1, 1);
            string substr2 = s1.Substring(7, 3);

            Console.WriteLine($"***Substring***\n" +
                $"method Substring with 1 parameter : {substr1}\n" +
                $"method Substring with 2 parameters : {substr2}\n");

            string[] words_arr = concat_plus.Split(" ");

            Console.WriteLine($"***Split***");
            foreach (string wo in words_arr)
            {
                Console.WriteLine(wo);
            }

            string insert_method = concat_plus.Insert(1, "...");

            Console.WriteLine($"\n***Substring in position***\n" +
                $"method Insert : {insert_method}\n");

            string rm_method1 = s1.Remove(s1.Length - 2);
            string rm_method2 = rm_method1.Remove(0, 7);

            Console.WriteLine($"***Remove substring***\n" +
                $"method Remove with 1 parameter : {rm_method1}\n" +
                $"method Remove with 2 parameters : {rm_method2}\n");

            /*Специальный знак $ идентифицирует строковый литерал как интерполированную строку. 
             *Интерполированная строка — это строковый литерал, который может содержать выражения интерполяции. 
             *При разрешении интерполированной строки в результирующую элементы с выражениями интерполяции заменяются 
             *строковыми представлениями результатов выражений. Эта функция доступна начиная с C# 6.*/

            string interp = $"s1 : {s1}, s2 : {s2}, s3 : {s3}";

            Console.WriteLine($"***String interpolation***\n {interp}");

            //``````````````````` ЗАДАНИЕ 2 (c) ```````````````````
            string n_str = null;
            string emp_str = "";
            string str = "string with text";

            Console.WriteLine($"IsNullOrEmpty method\n" +
                $"string is null : {String.IsNullOrEmpty(n_str)}\n" +
                $"string is empty : {String.IsNullOrEmpty(emp_str)}\n" +
                $"string with text : {String.IsNullOrEmpty(str)}\n");

            Console.WriteLine($"Plus : {n_str + emp_str}");     //""
            Console.WriteLine($"Compare : {String.Compare(n_str, emp_str)}");   //-1
            Console.WriteLine($"String.Equals : {String.Equals(n_str, emp_str)}");  //False
            Console.WriteLine($"String.Concat : {String.Concat(n_str, emp_str)}");  //""
            Console.WriteLine($"Interpolation : {n_str}, {emp_str}");   //, ""

            //``````````````````` ЗАДАНИЕ 2 (d) ```````````````````
            StringBuilder str2d = new StringBuilder("Can you please sit the fuck down"); //выделяет больше памяти, чем нужно в данный момент, для возможности менять строку

            Console.WriteLine($"Remove : {str2d.Remove(0, 23)}");

            str2d.Insert(0, "->");
            str2d.Append("<-");
            Console.WriteLine($"Insert + Append: {str2d}");

            //------------------------------------------------------------------------------------------------------------------------------------

            //``````````````````` ЗАДАНИЕ 3 (a) ```````````````````
            int[,] nums = { { 0, 1, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 } };
            int rows = nums.GetUpperBound(0) + 1;
            int cols = nums.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(nums[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }

            //``````````````````` ЗАДАНИЕ 3 (b) ```````````````````
            string[] strs = new string[6] { "I was born on the wrong side of the train tracks",
                "I was raised with a strap across my back",
                "Lay me on my side or hold me up to the light, yeah",
                "I was burned by the cold kiss of a vampire",
                "I was bit by the whisper of a soft liar",
                "Any good friend of yours is a good friend of mine"};

            Console.WriteLine("***Array***");
            foreach (string s in strs)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"\nArray's length : {strs.Length}\n");

            Console.Write("Введите номер строки : ");
            int ind = Convert.ToInt32(Console.ReadLine()) - 1;
            //если введенное число больше, количсетва строк в массиве, то менять будем последнюю строку
            if (ind >= strs.Length)
            {
                ind = strs.Length - 1;
            }

            Console.Write("Введите, на что заменить эту строку : ");
            string new_str = Console.ReadLine();

            strs[ind] = new_str;

            Console.WriteLine("\n***Array witn changed line***");
            foreach (string s in strs)
            {
                Console.WriteLine(s);
            }

            //``````````````````` ЗАДАНИЕ 3 (c) ```````````````````
            float[][] arr = new float[3][];
            arr[0] = new float[2];
            arr[1] = new float[3];
            arr[2] = new float[4];

            //ВВОД МАССИВА
            Console.Write("Введите в массив 9 вещественных чисел через пробел : ");

            //через пробел делим строку на элементы массива и записываем получившиеся строки в массив
            string[] usual_arr_str = (Console.ReadLine().Split(" "));
            int usual_ind = 0;

            for (int i = 0; i < 3; i++)
            {
                int max_col = 0;

                if (i == 0)
                {
                    max_col = 2;
                }
                else if (i == 1)
                {
                    max_col = 3;
                }
                else if (i == 2)
                {
                    max_col = 4;
                }

                for (int j = 0; j < max_col; j++)
                {
                    //элементы массива строк приводим к вещественным числам
                    arr[i][j] = Convert.ToSingle(usual_arr_str[usual_ind]);
                    usual_ind++;
                }
            }

            //ВЫВОД МАССИВА
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n");

                int max_col = 0;

                if (i == 0)
                {
                    max_col = 2;
                }
                else if (i == 1)
                {
                    max_col = 3;
                }
                else if (i == 2)
                {
                    max_col = 4;
                }

                for (int j = 0; j < max_col; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine("\n");
            }

            //``````````````````` ЗАДАНИЕ 3 (d) ```````````````````
            var str3d = "From Today on, It's My Turn!!";
            var arr3d = new[] { 1.2, 7.09, 8.3 };

            Console.WriteLine($"String : {str3d}");

            Console.Write($"Array : ");
            foreach (float i in arr3d)
            {
                Console.Write(i + "\t");
            }

            Console.Write("\n");

            //------------------------------------------------------------------------------------------------------------------------------------

            //``````````````````` ЗАДАНИЕ 4 (a, b) ```````````````````

            (int, string, char, string, ulong) cor = (7, "Kyou kara Ore wa!!", 'A', "Rainforest Alliance", 45);

            Console.WriteLine(cor);
            Console.WriteLine($"\n1 cortege element : {cor.Item1}");
            Console.WriteLine($"2 cortege element : {cor.Item2}");
            Console.WriteLine($"3 cortege element : {cor.Item3}");
            Console.WriteLine($"4 cortege element : {cor.Item4}");
            Console.WriteLine($"5 cortege element : {cor.Item5}");

            //``````````````````` ЗАДАНИЕ 4 (c) ```````````````````
            //деконструирование кортежа 

            //явное объявление первых двух переменных и ключевое слово var, чтобы C# сам определил тип третьей переменной
            (string song, int num, var fl) = ("Smells Like Teen Spirit", 10, 9.4f);

            //C# объявлет тип всех переменных 
            var (int_num, cha) = (-10, 'E');

            //вы можете разложить кортеж на уже объявленные переменные
            int a4c;
            int b4c = 9;

            (a4c, b4c) = (10, 7);

            //``````````````````` ЗАДАНИЕ 4 (d) ```````````````````
            (int, int, int, int, int) cor1 = (10, 20, 9, 0, 40);
            (int, int, int, int, int) cor2 = (20, 10, 9, 75, -2);

            //позволяет сравнивать кортежи с разным количеством элементов
            Console.WriteLine("cor2.Equals(cor1) : " + cor2.Equals(cor1)); //False

            //компилируются только, если количество элементов в первом кортеже равно количеству во втором
            Console.WriteLine("cor1 == cor2 : " + (cor1 == cor2)); //False
            Console.WriteLine("cor2.CompareTo(cor1) : " + cor2.CompareTo(cor1)); //1
            Console.WriteLine("cor1.CompareTo(cor2) : " + cor1.CompareTo(cor2)); //-1

            //------------------------------------------------------------------------------------------------------------------------------------

            //``````````````````` ЗАДАНИЕ 5 ```````````````````

            var result = Method(new int[] { 8, 9, 0, -1, 45 }, "hello there!");

            Console.WriteLine("max, min, sum, first letter : " + result);

            //------------------------------------------------------------------------------------------------------------------------------------

            //``````````````````` ЗАДАНИЕ 6 ```````````````````
            void ch(int a)
            {
                try
                {
                    checked
                    {
                        a = a + 8;
                    }
                    Console.WriteLine(a);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Переполнение");
                }

            }

            void unch(int a)
            {
                unchecked
                {
                    a = a + 8;
                }
                Console.WriteLine(a);
            }

            int max_int = 2147483647;

            ch(max_int);
            unch(max_int);
        }
    }
}
