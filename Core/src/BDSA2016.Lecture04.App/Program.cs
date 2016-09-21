using System;
using BDSA2016.Lecture04.Lib;

namespace BDSA2016.Lecture04.App
{
    public class Program
    {
        private readonly static string _connectionStringSqlServer = @"Server=tcp:ondfisk.database.windows.net,1433;Initial Catalog=Futurama;Persist Security Info=False;User ID=futurama;Password=Futurama1999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static void Main(string[] args)
        {           
            using (ICharacterRepository repository = new AdoNetCharacterRepository(_connectionStringSqlServer))
            {
                foreach (var character in repository.Read())
                {
                    Console.WriteLine(character);
                }
            }
        }
    }
}
