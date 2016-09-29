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
            var service = new FooServiceFalseStub();

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

            using (var worker = new WorkerConstructorInjection(mock.Object))
            {
                var result = worker.DoWork(new FooDto());

                Assert.True(result);
            }
        }

        [Fact(DisplayName = "Get given 42")]
        public void Get_given_42_returns_instance_of_foo()
        {
            var foo = new Foo { Id = 42, Name = "Answer" };

            var mock = new Mock<IFooService>();
            mock.Setup(m => m.Read(42)).Returns(foo);

            using (var worker = new WorkerConstructorInjection(mock.Object))
            {
                var result = worker.Get(42);

                Assert.Equal("Answer", result.Name);
            }
        }
    }
}
