using BDSA2016.Lecture06.Lib.Animals;
using BDSA2016.Lecture07.Lib.Game;
using System;
using Microsoft.Extensions.DependencyInjection;
using BDSA2016.Lecture07.Lib.ChainOfResponsibility;
using BDSA2016.Lecture07.Lib.Strategy;
using BDSA2016.Lecture07.Lib.Bridge;
using System.Threading.Tasks;
using BDSA2016.Lecture07.Lib.Singleton;
using BDSA2016.Lecture07.Lib.Facade;

namespace BDSA2016.Lecture07.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChainOfResponsibility.Run();
        }

        static void IoC()
        {
            var service = IoCContainer.Provider.GetService<IAnimalService>();

            service.Speak();
        }

        static void Config()
        {
            throw new NotImplementedException();
        }

        static async Task Bridge()
        {
            var bridge = IoCContainer.Provider.GetService<Bridge>();

            await bridge.PrintAll();
        }
    }
}
