namespace BDSA2016.Lecture07.Lib.Game
{
    public interface IWeapon
    {
        string Name { get; }

        int Damage { get; }

        int Range { get; }
    }
}
