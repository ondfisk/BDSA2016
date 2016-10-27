using System.Collections.Generic;

namespace BDSA2016.Lecture07.Lib.Facade
{
    public interface INotifier
    {
        void Notify(Article article, IEnumerable<Person> people);
    }
}