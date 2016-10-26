namespace BDSA2016.Lecture07.Lib.Game
{
    public class Grenade : IWeapon
    {
        public string Name => nameof(Grenade);

        public int Damage => 128;

        public int Range => 4;
    }
}
