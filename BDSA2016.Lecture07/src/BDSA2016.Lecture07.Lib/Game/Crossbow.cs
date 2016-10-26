namespace BDSA2016.Lecture07.Lib.Game
{
    public class Crossbow : IWeapon
    {
        public string Name => nameof(Crossbow);

        public int Damage => 12;

        public int Range => 12;
    }
}
