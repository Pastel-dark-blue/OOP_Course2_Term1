using System;
using System.Text; //StringBuilder
using System.Text.RegularExpressions;

namespace Laba9_task2
{
    class StringProcessing
    {
        public static void removePunctuationMarks(string str)
        {
            var sb = new StringBuilder();
            char[] punctuationMarks = { '.', ',', ';', ':', '!', '?', '-', '"', '(', ')' };

            foreach (char c in str)
            {
                bool isPunctuationMark = false;
                foreach (char mark in punctuationMarks)
                {
                    if (c == mark)
                    {
                        isPunctuationMark = true;
                        break;
                    }
                }
                if (!isPunctuationMark)
                    sb.Append(c);
            }

            str = sb.ToString();

            Console.WriteLine("--> Удаление символов пунктуации : " + str + "\n");
        }

        public static void reverseString(string str)
        {
            var sb = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }

            str = sb.ToString();

            Console.WriteLine("--> Реверс строки : " + str + "\n");
        }

        public static void toUpperCase(string str)
        {
            str = str.ToUpper();

            Console.WriteLine("--> Перевод символов в верхний регистр : " + str + "\n");
        }

        public static void removeExtraSpaces(string str)
        {
            str = (Regex.Replace(str, "[ ]+", " ")).Trim();

            Console.WriteLine("--> Удаление лишних пробелов : " + str + "\n");
        }

        public static void replaceVowelsWithAsterisk(string str)
        {
            char[] vowelsArr = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };
            foreach (char c in str)
            {
                foreach (char vowel in vowelsArr)
                {
                    if (c == vowel)
                    {
                        str = str.Replace(c, '*');
                    }
                }
            }

            Console.WriteLine("--> Замена гласных на символ \"*\" : " + str + "\n");
        }
    }

}
