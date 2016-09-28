using System.Collections.Generic;

namespace BDSA2016.Lecture05.Lib.DependencyInjection
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Foo> Children { get; private set; } = new HashSet<Foo>();
    }
}
