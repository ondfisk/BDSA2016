namespace BDSA2016.Lecture07.Lib.Game
{
    public class Sword : IWeapon
    {
        public string Name => nameof(Sword);

        public int Damage => 32;

        public int Range => 0;
    }
}
