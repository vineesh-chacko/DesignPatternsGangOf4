using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKataExercise
{
    public class Wrapper
    {
        public static string Wrap(string text, int columns)
        {
            if (text.Length <= columns)
            {
                return text;
            }

            if (text[columns] == ' ')
            {
                return Split(text, columns, 1);
            }
            return "";
        }


        private static string Split(string text, int positon, int offset = 0)
        {

            return text.Substring(0, positon) + '\n' + Wrap(text.Substring(positon + offset), positon);
        }
    }

}
