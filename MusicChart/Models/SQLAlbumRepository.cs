using MusicChart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class SQLAlbumRepository : IAlbumRepository
    {
        private ApplicationDbContext _context;

        public SQLAlbumRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            return _context.Albums.FirstOrDefault(a => a.SingerId==singerName && a.Name == albumName);
        }

        public async Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            return _context.Songs.Where(s => s.SingerId == singerName).ToList();
        }

        public async Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            return _context.Albums.Where(a => a.SingerId == singerName).ToList();
        }
    }
}
