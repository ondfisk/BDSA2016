using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture04.Lib
{
    public class CharacterContext //: DbContext, ICharacterContext
    {
        private readonly string _connectionString = @"Server=tcp:ondfisk.database.windows.net,1433;Initial Catalog=Futurama;Persist Security Info=False;User ID=futurama;Password=Futurama1999;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<Character> Characters { get; private set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //      optionsBuilder.UseSqlServer(_connectionString);
        // }
    }
}