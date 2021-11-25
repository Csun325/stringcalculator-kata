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
                var inputRule = GetInputRule(input);
                inputString = inputRule.Contains('[') ? ProcessMultipleDelimiters(input, inputRule) : ProcessSingleDelimiter(input, inputRule);
            }
            
            int[] inputNumbers = Array.ConvertAll(inputString, s => int.Parse(s));

            // for negative numbers
            if (inputNumbers.Any(num => num < 0)) 
            {
                var message = GetExceptionMessage(inputNumbers);
                throw new ArgumentException(message);
            }

            if (!inputNumbers.Any(num => num >= 1000)) return inputNumbers.Sum();

            //for numbers >= 1000
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

        private static string GetInputRule(string input)
        {
            var endDelimiterPos = input.IndexOf('\n');
            return input.Substring(2, endDelimiterPos - 2);
        }

        private static string[] ProcessSingleDelimiter(string input, string inputRule)
        {
            var delimitersChars = inputRule.ToCharArray();
            input = input.Substring(4);
            return input.Split(delimitersChars);
        }

        private static string[] ProcessMultipleDelimiters(string input, string inputRule)
        {
            var ruleMatch = Regex.Matches(inputRule, @"\[(.+?)\]").Cast<Match>().Select(s => s.Groups[1].Value).ToArray();
            input = input.Substring(input.LastIndexOf(']') + 2);
            return input.Split(ruleMatch, System.StringSplitOptions.None);
        }
    }
}