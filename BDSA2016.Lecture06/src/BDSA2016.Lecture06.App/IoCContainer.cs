using System;
using Microsoft.Extensions.DependencyInjection;
using BDSA2016.Lecture06.Lib.Animals;

namespace BDSA2016.Lecture06.App
{
    public class IoCContainer
    {
        private static readonly IServiceProvider _provider = ConfigureServices();

        public static void Run(string[] args)
        {
            var service = _provider.GetService<IAnimalService>();

            service.Speak();
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
