using System;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public interface IServicePropertySetter<T>
    {
        T Service { set; }
    }

    public class WorkerInterfacePropertyInjection : IServicePropertySetter<IFooService>, IDisposable
    {
        public IFooService Service { private get; set; }

        public bool DoWork(FooDto fooDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Service?.Dispose();
        }
    }
}
