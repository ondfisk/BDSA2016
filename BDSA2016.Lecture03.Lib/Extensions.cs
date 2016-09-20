using System;
using System.Collections.Generic;

namespace BDSA2016.Lecture03.Lib
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items) 
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static int WordCount(this string str)
        {
            throw new NotImplementedException();
        }
    }
}
