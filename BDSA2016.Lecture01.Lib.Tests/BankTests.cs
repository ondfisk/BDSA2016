using System;
using Xunit;

namespace BDSA2016.Lecture01.Lib.Tests
{
    public class BankTests
    {
        [Fact]
        public void Ctor_sets_balance()
        {
            // Arrange

            // Act
            var bank = new Bank(42);

            // Assert
            Assert.Equal(42, bank.Balance);
        }

        [Fact]
        public void Deposit_increases_balance_by_value()
        {
            // Arrange
            var bank = new Bank();

            // Act
            bank.Deposit(42);

            // Assert
            Assert.Equal(42, bank.Balance);
        }

        [Fact]
        public void Deposit_given_overflow_throws_OverflowException()
        {
            // Arrange
            var bank = new Bank(42);

            // Act

            // Assert
            Assert.Throws<OverflowException>(() => bank.Deposit(int.MaxValue));
        }
    }
}
