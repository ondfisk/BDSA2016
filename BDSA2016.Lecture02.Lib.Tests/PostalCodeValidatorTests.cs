using Xunit;

namespace BDSA2016.Lecture02.Lib.Tests
{
    public class PostalCodeValidatorTests
    {
        [Fact]
        public void IsValid_given_2000_returns_true()
        {
            // Arrange
            var postalCode = "2000";

            // Act
            var valid = PostalCodeValidator.IsValid(postalCode);

            // Assert
            Assert.True(valid);
        }

        [Fact]
        public void IsValid_given_2000foo_returns_false()
        {
            // Arrange
            var postalCode = "2000foo";

            // Act
            var valid = PostalCodeValidator.IsValid(postalCode);

            // Assert
            Assert.False(valid);
        }

        [Fact]
        public void TryParse_given_2100_København_Ø_return_true_and_sets_fields()
        {
            // Arrange
            var postalCodeAndLocality = "2100 København Ø";
            string postalCode;
            string locality;

            // Act
            var valid = PostalCodeValidator.TryParse(postalCodeAndLocality,
                out postalCode, out locality);

            // Assert
            Assert.True(valid);
            Assert.Equal("2100", postalCode);
            Assert.Equal("København Ø", locality);
        }
    }
}
