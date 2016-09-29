using System;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public class FoolishService
    {
        public bool Update(Foo foo)
        {
            throw new NotImplementedException();
        }
    }

    public class FoolishServiceAdapter : IFooService
    {
        private readonly FoolishService _service = new FoolishService();

        public bool Update(Foo foo)
        {
            return _service.Update(foo);
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
