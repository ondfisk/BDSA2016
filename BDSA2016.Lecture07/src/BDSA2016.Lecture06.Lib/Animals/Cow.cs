using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture06.Lib.Animals
{
    public class Cow : IAnimal
    {
        public void Hello()
        {
            Console.WriteLine("Mooh");
        }
    }
}
