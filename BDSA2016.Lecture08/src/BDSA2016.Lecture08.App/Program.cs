using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BDSA2016.Lecture08.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new WebHostBuilder().UseKestrel()
                                              .UseContentRoot(Directory.GetCurrentDirectory())
                                              .UseStartup<Startup>()
                                              .Build();
            
            builder.Run();
        }
    }
}
