using System;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public class WorkerPropertyInjection : IDisposable
    {
        public IFooService Service { get; set; }

        public bool DoWork(FooDto foo)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Service?.Dispose();
        }
    }
}
