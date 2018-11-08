using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCodeExcersie
{
    public class StringCalculator
    {
        private const string delimiter = ",";

        public int Add(string numbers)
        {
            

            if(numbers.Length == 0)
            {
                return 0;
            }

            //check for delimiters
            if (HasDelimitor(numbers))
            {
                return Hadmultiple(numbers);
            }
            else
                return (HandleOneNumber(numbers));
        }


        private bool HasDelimitor(string numbers)
        {
            return numbers.IndexOf(delimiter) > 0;
        }
        private int HandleOneNumber(string number)
        {
            return int.Parse(number);
        }

        private int Hadmultiple(string numbers)
        {

            int count = 0;
            foreach (var item in numbers.Split(delimiter.ToCharArray()))
            {
                count += HandleOneNumber(item);
            }
            
            return count;
        }
    }
}
