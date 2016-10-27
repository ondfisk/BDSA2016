using System;
using Microsoft.Extensions.DependencyInjection;
using BDSA2016.Lecture06.Lib.Animals;
using BDSA2016.Lecture07.Lib.Bridge;

namespace BDSA2016.Lecture07.App
{
    public class IoCContainer
    {
        public static IServiceProvider Provider { get; }

        static IoCContainer()
        {
            Provider = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IAnimalService, AnimalService>();
            serviceCollection.AddTransient<IAnimal, Wolf>();
            
            return serviceCollection.BuildServiceProvider();
        }
    }
}
