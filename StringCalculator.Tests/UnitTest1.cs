using Console;
using Xunit;


namespace StringCalculator.Tests

{
    public class UnitTest1
    {
        private Calculator _calculator;
        public UnitTest1()
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
        
    }
}