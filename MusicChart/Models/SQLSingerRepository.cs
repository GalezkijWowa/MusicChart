using MusicChart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class SQLSingerRepository : ISingerRepository
    {
        private ApplicationDbContext _context;

        public SQLSingerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            return _context.Singers.FirstOrDefault(s => s.Name == singerName).SimilarSingers;
        }

        public async Task<Singer> GetSingerInfoAsync(string singerName)
        {
            return _context.Singers.FirstOrDefault(s => s.Name == singerName);
        }

        public async Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            return _context.Singers.Where(s => s.IsTop == 1).ToList();
        }
    }
}
