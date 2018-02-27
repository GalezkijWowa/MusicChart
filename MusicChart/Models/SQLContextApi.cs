using MusicChart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class SQLContextApi : IContextApi
    {
        private ApplicationDbContext _context;

        public SQLContextApi(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddAlbums(IEnumerable<Album> items)
        {
            foreach (var item in items)
            {
                AddAlbums(item);
            }
            _context.SaveChanges();
        }

        public void AddSingers(IEnumerable<Singer> items)
        {
            foreach (var item in items)
            {
                AddSingers(item);
            }
            _context.SaveChanges();
        }

        public void AddSongs(IEnumerable<Song> items)
        {
            foreach (var item in items)
            {
                AddSongs(item);
            }
            _context.SaveChanges();
        }

        public void AddAlbums(Album item)
        {
            if (_context.Albums.Find(item.AlbumId) == null)
            {
                _context.Albums.Add(item);
            }
            _context.SaveChanges();
        }

        public void AddSingers(Singer item)
        {
            if (_context.Singers.Find(item.SingerId) == null)
            {
                _context.Singers.Add(item);
            }
            _context.SaveChanges();
        }

        public void AddSongs(Song item)
        {
            if (_context.Songs.Find(item.SongId) == null)
            {
                _context.Songs.Add(item);
            }
            _context.SaveChanges();
        }

        public void AddSimiliarMap(SimiliarMap map)
        {
            if (_context.SimiliarMaps.Where(m => m.SingerId == map.SingerId && m.SimiliarSingerId == map.SimiliarSingerId).ToList().Count() == 0)
            {
                _context.SimiliarMaps.Add(map);
            }
            _context.SaveChanges();
        }
    }
}
