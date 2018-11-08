using System;

namespace CodeKataExercise
{

    public class Wrapper
    {

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(Wrapper.Wrap("test123456", 4));
        //}

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
            var previousSpace = text.Substring(0, columns).LastIndexOf(' ');

            if (previousSpace != -1)
                return Split(text, previousSpace, 1);

            return Split(text, columns);
        }


        private static string Split(string text, int position, int offset = 0)
        {

            return text.Substring(0, position) + '\n' + Wrap(text.Substring(position + offset), position);
        }

    }

    
}
