using System;
using Xunit;
using DemoCalc;

namespace DemoCalc.Tests
{
    public class CalculatorTests
    {
        // [Fact] => for simple tests, without parameters
        [Theory]
        [InlineData(-1, 4, 3)]
        [InlineData(4, -2, 2)]
        [InlineData(4, 7, 11)]
        [InlineData(4.25, 7.50, 11.75)]
        [InlineData(double.MaxValue, 7.50, double.MaxValue)]
        public void Add_SimpleValuesShouldCalculate(double a, double b, double expected)
        {
            // Arrange = Arrange or setup the values
            //double expected = 9;

            // Act = Do the action of the test
            ICalculator calculator = new Calculator();
            //double actual = calculator.Add(4, 5);
            
            double actual = calculator.Add(a, b);

            // Assert = with the actual result, what we expected
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4, 2, 2)]
        [InlineData(4, -2, -2)]
        [InlineData(5, 1, 5)]
        [InlineData(1, 5, 0.2)]
        public void Divide_SimpleValuesShouldCalculate(double a, double b, double expected)
        {
            // Arrange
            // Act 
            ICalculator calculator = new Calculator();
            double actual = calculator.Divide(a, b);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_DivideByZeroSholdRaiseException()
        {
            Assert.Throws<DivideByZeroException>(() => new Calculator().Divide(10, 0));
        }
    }
}
