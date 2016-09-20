using System;
using Xunit;

namespace BDSA2016.Lecture03.Lib.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_fails_when_overflowing() 
        {
            var calc = new Calculator(42);

            Assert.Throws<OverflowException>(() => calc.Add(int.MaxValue));
        }

        [Fact]
        public void Invert_returns_inverted()
        {
            var calc = new Calculator(-42);

            var value = calc.Invert();

            Assert.Equal(42, value);
        }
    }
}
