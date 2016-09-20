using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BDSA2016.Lecture03.Lib.Models
{
    class Program
    {
        private static void Main(string[] args)
        {
            Hamlet();
        }

        private static void Hamlet()
        {
            using (var file = File.OpenText("Hamlet.txt"))
            {
                var text = file.ReadToEnd();

                var words = Regex.Split(text, @"\P{L}+");

                var histogram = from w in words
                                group w by w into h
                                let c = h.Count()
                                orderby c descending
                                select new { Word = h.Key, Count = c };

                histogram.Take(5).Print();
            }
        }
    }
}
