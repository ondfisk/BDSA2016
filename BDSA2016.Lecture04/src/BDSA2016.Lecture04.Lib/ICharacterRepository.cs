using System;
using System.Collections.Generic;

namespace BDSA2016.Lecture04.Lib
{
    public interface ICharacterRepository : IDisposable
    {
        int Create(Character character);

        Character Find(int id);

        IEnumerable<Character> Read();

        bool Update(Character character);

        void Delete(int id);
    }
}