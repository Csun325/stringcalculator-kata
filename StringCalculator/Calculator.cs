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
            string[] inputString = input.Split(",");
            int[] inputValues = Array.ConvertAll(inputString, s => int.Parse(s));
            return inputValues.Sum();
        }
    }
}