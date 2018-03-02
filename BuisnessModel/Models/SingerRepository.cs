using DatabaseModel.Data;
using DatabaseModel.Models;
using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public class SingerRepository : ISingerRepository
    {
        private IContextRepository _dbRepo;
        private ISingerRepository _lastSingerRepo;

        public SingerRepository(ApplicationDbContext dbContext)
        {
            _dbRepo = new SQLContextRepository(dbContext);
            _lastSingerRepo = new LastFmSingerRepository();
        }
        public async Task<Singer> GetFullSingerInfoAsync(string singerName)
        {
            Singer singer = await _lastSingerRepo.GetFullSingerInfoAsync(singerName);
            _dbRepo.AddSinger(singer);
            return singer;
        }

        public async Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            List<Singer> singers = await _lastSingerRepo.GetSimiliarSingersAsync(singerName);
            _dbRepo.AddSingers(singers);
            return singers;
        }

        public Task<string> GetSingerDescription(string singerName)
        {
            return _lastSingerRepo.GetSingerDescription(singerName);
        }

        public async Task<Singer> GetSingerInfoAsync(string singerName)
        {
            Singer singer = await _lastSingerRepo.GetSingerInfoAsync(singerName);
            return singer;
        }

        public async Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            List<Singer> singers;
            singers = await _dbRepo.GetSingersAsync(pageSize, itemsPerPage);
            if(singers.Count == 0)
            {
                singers = await _lastSingerRepo.GetSingersAsync(pageSize, itemsPerPage);
                _dbRepo.AddSingers(singers);
            }
            return singers;
        }
    }
}
