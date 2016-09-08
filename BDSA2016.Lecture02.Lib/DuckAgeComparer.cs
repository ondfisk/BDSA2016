using System;
using System.Collections.Generic;

namespace BDSA2016.Lecture02
{
    public class DuckAgeComparer : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            throw new NotImplementedException();
        }

        public static Comparison<Duck> Comparison 
        {
            get
            {
                Comparison<Duck> comparison = delegate (Duck x, Duck y) 
                {
                    if (x.Age < y.Age)
                    {
                        return -1;
                    }
                    if (x.Age > y.Age)
                    {
                        return 1;
                    }
                    return 0;
                };

                return comparison;
            }
        }

        public static Comparison<Duck> Comparison2 => (x, y) => x.Age < y.Age ? -1 : x.Age > y.Age ? 1 : 0;
    }
}
