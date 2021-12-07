using System;

namespace Laba9_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> edit = null;
            edit += StringProcessing.removePunctuationMarks;
            edit += StringProcessing.reverseString;
            edit += StringProcessing.toUpperCase;
            edit += StringProcessing.removeExtraSpaces;
            edit += StringProcessing.replaceVowelsWithAsterisk;

            string str = $"That's my boy, "+
                          "American son "+
                          "Hope I'm not   around when he gets the idea to buy a gun";

            edit(str);
        }
    }
}
