using System;
using BDSA2016.Lecture04.Lib;
using Microsoft.Extensions.Configuration;

namespace BDSA2016.Lecture04.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new MusicDbContext())
            using (var repository = new AlbumRepository(context))
            {
                foreach (var album in repository.Read())
                {
                    Console.WriteLine($"{album.Id}: {album.Title} by {album.Artist} ({album.Year})");

                }
            }
        }

        private static string GetSetting(string key)
        {
            //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            //var configuration = builder.Build();
            //var setting = configuration[key];

            return "setting";
        }
    }
}
