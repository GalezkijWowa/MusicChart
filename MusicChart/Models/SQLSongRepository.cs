using MusicChart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class SQLSongRepository : ISongRepository
    {
        private ApplicationDbContext _context;

        public SQLSongRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Song>> GetTopSongsAsync(string singerName)
        {
            return _context.Songs.Where(s => s.SingerId == singerName).ToList();
        }
    }
}
