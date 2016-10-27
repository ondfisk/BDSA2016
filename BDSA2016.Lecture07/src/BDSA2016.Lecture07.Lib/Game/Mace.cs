using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture07.Lib.Game
{
    public class Mace : IWeapon
    {
        public int Damage => 64;

        public string Name => nameof(Mace);

        public int Range => 0;
    }
}
