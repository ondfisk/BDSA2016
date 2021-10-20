using BDSA2016.Lecture05.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BDSA2016.Lecture05.Lib.Tests
{
    public class Helpers
    {
        // https://docs.efproject.net/en/latest/miscellaneous/testing.html
        public static DbContextOptions<CourseBaseContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<CourseBaseContext>();
            //builder.UseInMemoryDatabase()
            //       .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
