using System;
using System.Linq;

namespace Console
{
    public class Calculator
    {
        public int Add(string input) 
        {
            if (IsEmptyString(input)) return 0;
            
            if(IsSingleDigit(input)) return int.Parse(input);
            
            // default delimiters
            char[] delimitersChars = new[]{',', '\n'};
            
            if (IsDoubleSlash(input))
            {
                delimitersChars = input.Substring(2, 1).ToCharArray();
                input = input.Substring(4);
            }
            
            var inputString = input.Split(delimitersChars);
            int[] inputNumbers = Array.ConvertAll(inputString, s => int.Parse(s));

            if (inputNumbers.Any(num => num < 0)) 
            {
                var message = GetExceptionMessage(inputNumbers);
                throw new ArgumentException(message);
            }

            if (!inputNumbers.Any(num => num >= 1000)) return inputNumbers.Sum();

            inputNumbers = RemoveNumberGreaterOrEqualTo1000(inputNumbers);

            return inputNumbers.Sum();

        }
        
        // helper methods below
        private static bool IsEmptyString(string input)
        {
            return input == "";
        }

        private static bool IsSingleDigit(string input)
        {
            return input.Length <= 1;
        }

        private static bool IsDoubleSlash(string input)
        {
            var checkSlash = input.Substring(0, 2);
            return (checkSlash == "//");
        }

        private static string GetExceptionMessage(int[] inputNumbers)
        {
            int[] negativeNumbers = inputNumbers.Where(num => num < 0).ToArray();
            var message = negativeNumbers.Aggregate("Negative not allowed:", (current, num) => current + (" " + num));
            return message;
        }

        private static int[] RemoveNumberGreaterOrEqualTo1000(int[] inputNumbers)
        {
            for (var i = 0; i < inputNumbers.Length; i++)
            {
                if(inputNumbers[i] >= 1000)
                {
                    inputNumbers[i] = 0;
                }
            }
            return inputNumbers;
        }
    }
}