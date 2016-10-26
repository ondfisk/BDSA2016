using System;

namespace BDSA2016.Lecture07.Lib.Adapter
{
    public class FooAdapter : IFooService
    {
        public bool Update(Foo foo)
        {
            try
            {
                FoolishService.Update(foo);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
