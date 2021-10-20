using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture04.Lib
{
    public class CharacterContext //: DbContext, ICharacterContext
    {
        public DbSet<Character> Characters { get; private set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //      optionsBuilder.UseSqlServer(_connectionString);
        // }
    }
}