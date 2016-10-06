using System;

namespace BDSA2016.Lecture06.Lib.Animals
{
    public interface IAnimalService : IDisposable
    {
        void Speak();
    }
}