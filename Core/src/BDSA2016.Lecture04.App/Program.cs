using System;
using BDSA2016.Lecture04.Lib;
using Microsoft.Framework.Configuration;

namespace BDSA2016.Lecture04.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = GetSetting("ConnectionStrings:SqlServer");           
            using (ICharacterRepository repository = new AdoNetCharacterRepository(connectionString))
            {
                foreach (var character in repository.Read())
                {
                    Console.WriteLine(character);
                }
            }
        }

        private static string GetSetting(string key)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var setting = configuration[key];

            return setting;
        }
    }
}
