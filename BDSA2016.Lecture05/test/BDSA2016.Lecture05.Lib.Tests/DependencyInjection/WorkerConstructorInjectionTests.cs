using BDSA2016.Lecture05.Lib.DependencyInjection;
using Moq;
using Xunit;

namespace BDSA2016.Lecture05.Lib.Tests.DependencyInjection
{
    public class WorkerConstructorInjectionTests
    {
        [Fact]
        public void DoWork_when_IFooService_Update_returns_false_returns_false_StubVersion()
        {
            IFooService service = new FooServiceFalseStub();
            using (var worker = new WorkerConstructorInjection(service))
            {
                var result = worker.DoWork(new FooDto());

                Assert.False(result);
            }
        }

        [Fact]
        public void DoWork_when_IFooService_Update_returns_false_returns_false_MockVersion()
        {
            var mock = new Mock<IFooService>();
            IFooService service = mock.Object;
            using (var worker = new WorkerConstructorInjection(service))
            {
                var result = worker.DoWork(new FooDto());

                Assert.False(result);
            }
        }

        [Fact]
        public void DoWork_when_IFooService_Update_returns_true_returns_true_MockVersion()
        {
            var mock = new Mock<IFooService>();
            mock.Setup(m => m.Update(It.IsAny<Foo>())).Returns(true);
            IFooService service = mock.Object;

            using (var worker = new WorkerConstructorInjection(service))
            {
                var result = worker.DoWork(new FooDto());

                Assert.True(result);
            }
        }
    }
}
