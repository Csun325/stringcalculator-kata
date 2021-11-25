using System;
using Console;
using Xunit;


namespace StringCalculator.Tests

{
    public class CalculatorTest
    {
        private Calculator _calculator;
        public CalculatorTest()
        {
            _calculator = new Calculator();
            
        }
        
        [Fact]
        public void Add_WhenStringIsNull_ThenReturnZero()
        {
            //arrange
            //act
            var ans = _calculator.Add("");
            //assert
            Assert.Equal(0, ans);
        }

        [Fact]
        public void Add_WhenStringIsSingleDigit_ThenReturnSameSingleDigit()
        {
            //arrange
            //act
            var ans = _calculator.Add("6");
            //assert
            Assert.Equal(6, ans);
        }

        [Fact]
        public void Add_WhenStringIsDoubleDigit_ThenReturnSumOfTheDigits()
        {
            //arrange
            //act
            var ans = _calculator.Add("3,5");
            //assert
            Assert.Equal(8, ans);
        }
        
        [Fact]
        public void Add_WhenStringIsAnyAmountOfDigit_ThenReturnSumOfAllTheDigits()
        {
            //arrange
            //act
            var ans = _calculator.Add("3,5,3,9");
            //assert
            Assert.Equal(20, ans);
        }

        [Fact]
        public void Add_WhenStringDigitsHasDelimiters_ThenReturnSumOfAllDigits()
        {
            //arrange
            //act
            var ans = _calculator.Add("1,2\n3");
            //assert
            Assert.Equal(6, ans);
        }

        [Fact]
        public void Add_WhenStringDigitsHasMultipleDelimiters_ThenReturnSumOfAllDigits()
        {
            //arrange
            //act
            var ans = _calculator.Add("//;\n1;2");
            //assert
            Assert.Equal(3, ans);
        }

        [Fact]
        public void Add_WhenStringDigitsHasNegatives_ThenThrowExceptions()
        {
            //arrange
            //act
            //assert
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Add("-1,2,-3"));
            Assert.Equal("Negative not allowed: -1 -3", exception.Message);
        }

        [Fact]
        public void Add_WhenNumberIsGreaterOrEqual1000_ThenNumberIsIgnoredInSum()
        {
            //arrange
            //act
            var ans = _calculator.Add("1000,1001,2");
            //assert
            Assert.Equal(2, ans);
        }

        [Fact]
        public void Add_WhenDelimiterIsAnyLength_ThenReturnSumOfAllDigitsIgnoreDelimiter()
        {
            //arrange
            //act
            var ans = _calculator.Add("//[***]\n1***2***3");
            //assert
            Assert.Equal(6, ans);
        }

        [Fact]
        public void Add_WhenMultipleDelimiterTypeIntroduced_ThenReturnSumOfAllDigitsIgnoringDelimiter()
        {
            //arrange
            //act
            var ans = _calculator.Add("//[*][%]\n1*2%3");
            //assert
            Assert.Equal(6, ans);
        }

        [Fact]
        public void Add_WhenMultipleDelimiterWithDifferentLengthIntroduced_ThenReturnSumOfAllDigitsIgnoringDelimiter()
        {
            //arrange
            //act
            var ans = _calculator.Add("//[***][#][%]\n1***2#3%4");
            //assert
            Assert.Equal(10, ans);
        }
        
    }
}