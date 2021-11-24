using Console;
using Xunit;


namespace StringCalculator.Tests

{
    public class UnitTest1
    {
        [Fact]
        public void Add_WhenStringIsNull_ThenReturnZero()
        {
            //arrange
            Calculator calc = new Calculator();
            //act
            var ans = calc.Add("");
            //assert
            Assert.Equal(0, ans);
        }
    }
}