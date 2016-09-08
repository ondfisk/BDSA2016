using Xunit;

namespace BDSA2016.Lecture02.Lib
{
    public class TrafficLightControllerTests
    {
        [Fact]
        public void CanIGo_given_Green_returns_True()
        {
            ITrafficLightController controller = new TrafficLightController();

            var go = controller.MayIGo(TrafficLightColor.Green);

            Assert.True(go);
        }

        [Fact]
        public void CanIGo_given_Yellow_returns_False()
        {
            ITrafficLightController controller = new TrafficLightController();

            var go = controller.MayIGo(TrafficLightColor.Yellow);

            Assert.False(go);
        }

        [Fact(DisplayName = nameof(CanIGo_given_Red_returns_False))]
        public void CanIGo_given_Red_returns_False()
        {
            ITrafficLightController controller = new TrafficLightController();

            var go = controller.MayIGo(TrafficLightColor.Red);

            Assert.False(go);
        }

        [Theory(DisplayName = "CanIGo returns false on red and yellow but true on green")]
        [InlineData(TrafficLightColor.Green, true)]
        [InlineData(TrafficLightColor.Yellow, false)]
        [InlineData(TrafficLightColor.Red, false)]
        public void CanIGo_theory(TrafficLightColor color, bool result)
        {
            ITrafficLightController controller = new TrafficLightController();

            var go = controller.MayIGo(color);

            Assert.Equal(result, go);
        }
    }
}
