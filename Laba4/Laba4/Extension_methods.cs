using System;
using System.Collections.Generic;
using static Laba4.Program; //для Set !!!

namespace Laba4
{
    static class Extension_methods
    {
        //выделение первого числа в строке
        public static int FindFirstNum(this string str)
        {
            string num = "";

            foreach(char i in str)
            {
                //если символ строки равен от 0 до 9, значит записываем его в строку num 
                if (i >= 48 && i <= 57)
                {
                    num += i;
                }
                //если в строке num уже есть число, а мы встретили символ, отличный от цифры - значит мы уже выделили первое число
                else if (num != "")
                {
                    break;
                }
            }

            //если в строке чисел нет
            if (num == "")
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(num);
            }
        }

        //------------------------------------------------------------------

        //Удаление положительных элементов из множества Set
        public static List<int> RemovePosEls(this Set set)
        {
            List<int> posSet = new List<int> { };

            foreach(int i in set.Data)
            {
                if (i < 0)
                {
                    posSet.Add(i);
                }
            }

            return posSet;
        } 
    }
}
