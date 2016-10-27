using System.Collections.Generic;

namespace BDSA2016.Lecture07.Lib.Facade
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> All();
    }
}