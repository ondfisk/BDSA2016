using BDSA2016.Lecture06.Lib.Animals;
using BDSA2016.Lecture07.Lib.Game;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace BDSA2016.Lecture07.App
{
    public class Program
    {
        static void Main(string[] args)
        {
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

        static void Game()
        {
            Console.Clear();

            var factory = new WeaponFactory();

            IWeapon weapon = null;

            do
            {
                Console.WriteLine("Please choose your weapon");

                foreach (var available in factory.Available())
                {
                    Console.WriteLine($"- {available}");
                }

                var input = Console.ReadLine();

                weapon = factory.Make(input);
            }
            while (weapon == null);

            Console.WriteLine("You have chosen wisely...");

            Console.WriteLine($"A {weapon.Name} with damage {weapon.Damage} and range {weapon.Range}");

            Console.WriteLine();

            Console.WriteLine("Try again [y/n]");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == 'y')
            {
                Game();
            }
        }
    }
}
