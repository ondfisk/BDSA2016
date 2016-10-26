using System.Collections.Generic;

namespace BDSA2016.Lecture07.Lib.Facade
{
    public class PeopleRepository
    {
        public IEnumerable<Person> All()
        {
            return new Person[0];
        }
    }
}
