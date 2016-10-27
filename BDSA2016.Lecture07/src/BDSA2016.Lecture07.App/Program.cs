using BDSA2016.Lecture06.Lib.Animals;
using BDSA2016.Lecture07.Lib.Game;
using System;
using Microsoft.Extensions.DependencyInjection;
using BDSA2016.Lecture07.Lib.ChainOfResponsibility;
using BDSA2016.Lecture07.Lib.Strategy;
using BDSA2016.Lecture07.Lib.Bridge;
using System.Threading.Tasks;

namespace BDSA2016.Lecture07.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bridge().Wait();
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
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Futurama;Integrated Security=SSPI;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var bridge = new Bridge(new AdoNetCharacterRepository(connectionString));

            await bridge.PrintAll();
        }
    }
}
