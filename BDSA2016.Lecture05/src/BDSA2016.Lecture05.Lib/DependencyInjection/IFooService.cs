using System;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public interface IFooService : IDisposable
    {
        bool Update(Foo foo);

        Foo Read(int id);
    }
}
