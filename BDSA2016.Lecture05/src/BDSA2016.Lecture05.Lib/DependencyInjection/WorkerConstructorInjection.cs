using System;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public class WorkerConstructorInjection : IDisposable
    {
        private readonly IFooService _service;

        public WorkerConstructorInjection(IFooService service)
        {
            _service = service;
        }

        public bool DoWork(FooDto fooDto)
        {
            throw new NotImplementedException();
        }

        private Foo Map(FooDto fooDto)
        {
            return new Foo { Id = fooDto.Id, Name = fooDto.Name };
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
