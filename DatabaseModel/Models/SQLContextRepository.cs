using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessModel.Models;
using DatabaseModel.Data;

namespace DatabaseModel.Models
{
    class SQLContextRepository : IContextRepository
    {
        private ApplicationDbContext _context;
        public SQLContextRepository(ApplicationDbContext dbContext)
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

        public void AddAlbums(Album item)
        {
            if (_context.Albums.Find(item.AlbumId) == null)
            {
                _context.Albums.Add(item);
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

        public void AddSingers(IEnumerable<Singer> items)
        {
            foreach (var item in items)
            {
                AddSingers(item);
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

        public void AddSongs(IEnumerable<Song> items)
        {
            foreach (var item in items)
            {
                AddSongs(item);
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

        public async Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            return _context.Albums.FirstOrDefault(a => a.SingerId==singerName && a.Name == albumName);
        }

        public async Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            return _context.Songs.Where(s => s.SingerId == singerName && s.AlbumName == albumName).ToList();
        }

        public async Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            List<SimiliarMap> simMaps = _context.SimiliarMaps.Where(map => map.SingerId == singerName).ToList();
            List<Singer> singerList = new List<Singer>();
            foreach (SimiliarMap map in simMaps)
            {
                singerList.Add(await GetSingerInfoAsync(map.SimiliarSingerId));
            }
            return singerList;
        }

        public async Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            return _context.Albums.Where(a => a.SingerId == singerName).ToList();
        }

        public async Task<Singer> GetSingerInfoAsync(string singerName)
        {
            return _context.Singers.FirstOrDefault(s => s.Name == singerName);
        }

        public async Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            return _context.Singers.Where(s => s.IsTop == 1).ToList();
        }

        public async Task<List<Song>> GetTopSongsAsync(string singerName)
        {
            return _context.Songs.Where(s => s.SingerId == singerName).ToList();
        }
    }
}
