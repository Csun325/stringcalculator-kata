using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            var inputString = input.Split(delimitersChars);
            
            if (IsDoubleSlash(input))
            {
                
                var endDelimiterPos = input.IndexOf('\n');
                
                var inputRule = input.Substring(2, endDelimiterPos - 2);
                if (inputRule.Contains('['))
                {
                    var match = Regex.Match(inputRule, @"\[(.+?)\]").Groups[1].Value;
                    input = input.Substring(5 + match.Length);
                    inputString = input.Split(match);
                }
                else
                {
                    delimitersChars = inputRule.ToCharArray();
                    input = input.Substring(4);
                    inputString = input.Split(delimitersChars);
                }
            }
            
            int[] inputNumbers = Array.ConvertAll(inputString, s => int.Parse(s));

            if (inputNumbers.Any(num => num < 0)) 
            {
                var message = GetExceptionMessage(inputNumbers);
                throw new ArgumentException(message);
            }

            if (!inputNumbers.Any(num => num >= 1000)) return inputNumbers.Sum();

            inputNumbers = GetNumbersLessThan1000(inputNumbers);

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

        private static int[] GetNumbersLessThan1000 (int[] inputNumbers)
        {
            var numbersLessThan1000 = inputNumbers.ToList().Where(num => num < 1000);
            var result = numbersLessThan1000.ToArray();
            return result;
        }
    }
}