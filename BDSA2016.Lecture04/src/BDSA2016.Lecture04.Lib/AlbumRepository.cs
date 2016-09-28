using System;
using System.Linq;
using System.Collections.Generic;

namespace BDSA2016.Lecture04.Lib
{
    public class AlbumListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Artist { get; set; }

        public int? Year { get; set; }
    }

    public interface IAlbumRepository : IDisposable
    {
        IEnumerable<AlbumListDTO> Read();
    }

    public class AlbumRepository : IAlbumRepository
    {
        private readonly IMusicDbContext _context;

        public AlbumRepository(IMusicDbContext context)
        {
          _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<AlbumListDTO> Read()
        {
            var albums = from s in _context.Albums
                         select new AlbumListDTO { Id = s.Id, Title = s.Title, Artist = s.Artist.Name, Year = s.Year };
                
            return albums;
        }
    }
} 