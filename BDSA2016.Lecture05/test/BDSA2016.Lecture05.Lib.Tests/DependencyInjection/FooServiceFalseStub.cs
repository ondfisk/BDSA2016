using System;
using BDSA2016.Lecture05.Lib.DependencyInjection;

namespace BDSA2016.Lecture05.Lib.Tests.DependencyInjection
{
    public class FooServiceFalseStub : IFooService
    {
        public bool Update(Foo foo)
        {
            return false;
        }

        public void Dispose()
        {
        }

        public Foo Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
