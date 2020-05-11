namespace XUnitTestProject.Tests
{
    using Xunit;
    using xUnitSimpleTest;
    public class CalculatorTest
    {
        [Fact]
        public void SumShouldRetunrCorrectResultWithTwoNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void SumShouldRetunrCorrectResultWithManyNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(1, 2, 4, 6);

            Assert.Equal(13, result);
        }

        [Fact]
        public void SumShouldRetunrCorrectResultWithOutNumbers()
        {
            var calculator = new Calculator();
            var result = calculator.Sum();

            Assert.Equal(0, result);
        }
    }
}
