using System;
using System.Linq;

namespace Console
{
    public class Calculator
    {
        public int Add(string input)
        {
            if (input == "")
            {
                return 0;
            }

            var result = 0;
            char[] delimitersChars = {',', '\n'};
            string[] inputString = input.Split(delimitersChars);
            int[] inputValues = Array.ConvertAll(inputString, s => int.Parse(s));
            return inputValues.Sum();
        }
    }
}