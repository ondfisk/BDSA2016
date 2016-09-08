using Xunit;

namespace BDSA2016.Lecture02.Lib
{
    public class TrafficLightControllerTests
    {
        [Fact]
        public void CanIGo_given_Green_returns_True()
        {

        }

        [Fact]
        public void CanIGo_given_Yellow_returns_False()
        {

        }

        [Fact(DisplayName = nameof(CanIGo_given_Red_returns_False))]
        public void CanIGo_given_Red_returns_False()
        {

        }

        [Theory(DisplayName = "CanIGo returns false on red and yellow but true on green")]
        [InlineData("Green", true)]
        [InlineData("Yellow", false)]
        [InlineData("Red", false)]
        public void CanIGo_theory(string color, bool result)
        {

        }
    }
}
