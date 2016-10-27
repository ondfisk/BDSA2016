using System.Collections.Generic;

namespace BDSA2016.Lecture07.Lib.Facade
{
    public class PeopleRepository : IPeopleRepository
    {
        public IEnumerable<Person> All()
        {
            return new Person[0];
        }
    }
}
