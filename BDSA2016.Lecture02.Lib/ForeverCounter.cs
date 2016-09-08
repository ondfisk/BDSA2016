using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace BDSA2016.Lecture02
{
    public class ForeverCounter : IEnumerable<byte>
    {
        public IEnumerator<byte> GetEnumerator()
        {
            return new Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class Enumerator : IEnumerator<byte>
        {
            public bool MoveNext()
            {
                Current++;
                return true;
            }

            public void Reset()
            {
                Current = default(byte);
            }

            public byte Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        public static IEnumerable<long> Count()
        {
            var counter = default(long);

            while (true)
            {
                counter++;

                if (counter > 42)
                {
                    WriteLine("Never go above 42...");
                    yield break;
                }

                yield return counter;
            }
        }
    }
}
