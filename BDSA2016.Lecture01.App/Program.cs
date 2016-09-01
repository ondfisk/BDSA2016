using static System.Console;

namespace BDSA2016.Lecture01.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var name = args == null || args.Length == 0 ?
                "World" :
                args[0];

            WriteLine($"Hello {name}!");
        }
    }
}
