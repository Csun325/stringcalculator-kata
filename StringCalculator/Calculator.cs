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

            if (input.Length <= 1) return int.Parse(input);
            
            var checkSlash = input.Substring(0, 2);
            char[] delimitersChars;
            
            if (checkSlash == "//")
            {
                delimitersChars = input.Substring(2, 1).ToCharArray();
                input = input.Substring(4);
            }
            else
            {
                delimitersChars = new Char[]{',', '\n'};
            }
            
            var inputString = input.Split(delimitersChars);
            
            int[] inputValues = Array.ConvertAll(inputString, s => int.Parse(s));
            return inputValues.Sum();

        }
    }
}