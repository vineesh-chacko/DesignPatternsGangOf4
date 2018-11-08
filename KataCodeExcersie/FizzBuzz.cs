using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKataExercise
{
    public class FizzBuzz
    {
        public string FizzBuzzKata(int i)
        {
            if ((i % 5 == 0) && (i % 3 == 0))
                return "FizzBuzz";
            if (i % 5 == 0)
                return "Buzz";
            if (i % 3 == 0)
                return "Fizz";
            return i.ToString();

        }
    }
}
