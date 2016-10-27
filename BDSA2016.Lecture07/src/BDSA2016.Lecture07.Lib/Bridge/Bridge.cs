using System;
using System.Threading.Tasks;

namespace BDSA2016.Lecture07.Lib.Bridge
{
    public class Bridge //: IDisposable
    {
        private readonly ICharacterRepository _repository;

        public Bridge(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task PrintAll()
        {
            foreach (var character in await _repository.ReadAsync())
            {
                Console.WriteLine(character);
            }
        }
    }
}
