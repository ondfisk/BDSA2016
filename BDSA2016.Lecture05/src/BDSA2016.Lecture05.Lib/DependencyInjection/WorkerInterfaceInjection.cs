using System;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public interface IServiceSetter<T>
    {
        void SetService(T service);
    }

    public class WorkerInterfaceInjection : IServiceSetter<IFooService>, IDisposable
    {
        private IFooService _service;

        public void SetService(IFooService service)
        {
            _service = service;
        }

        public bool DoWork(FooDto fooDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _service?.Dispose();
        }
    }
}
