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
            var foo = Map(fooDto);

            var result = _service.Update(foo);

            return result;
        }

        private Foo Map(FooDto fooDto)
        {
            return new Foo { Id = fooDto.Id, Name = fooDto.Name };
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public FooDto Get(int id)
        {
            var foo = _service.Read(42);

            var dto = new FooDto { Id = foo.Id, Name = foo.Name };

            return dto;
        }
    }
}
