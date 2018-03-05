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
        private IRemoteSingerRepository _lastSingerRepo;

        public SingerRepository(ApplicationDbContext dbContext)
        {
            _dbRepo = new SQLContextRepository(dbContext);
            _lastSingerRepo = new LastFmSingerRepository();
        }
        public async Task<Singer> GetFullSingerInfoAsync(string singerName)
        {
            Singer singer = await _dbRepo.GetFullSingerInfoAsync(singerName);
            if (singer == null || singer.Description == null)
            {
                singer = await _lastSingerRepo.GetFullSingerInfoAsync(singerName);
                _dbRepo.AddSinger(singer);
            }
            return singer;
        }

        public async Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            List<Singer> singers;
            singers = await _dbRepo.GetSimiliarSingersAsync(singerName);
            if(singers.Count == 0)
            {
                singers = await _lastSingerRepo.GetSimiliarSingersAsync(singerName);
                _dbRepo.AddSimiliarMaps(singers, singerName);
                _dbRepo.AddSingers(singers);
            }

            return singers;
        }

        public async Task<string> GetSingerDescription(string singerName)
        {
            string description;
            description = await _dbRepo.GetSingerDescription(singerName);
            if(description == null)
            {
                description = await _lastSingerRepo.GetSingerDescription(singerName);
            }
            return description;
        }

        public async Task<Singer> GetSingerInfoAsync(string singerName)
        {
            Singer singer;
            singer = await _dbRepo.GetSingerInfoAsync(singerName);
            if(singer == null)
            {
                singer = await _lastSingerRepo.GetSingerInfoAsync(singerName);
            }
            return singer;
        }

        public async Task<List<Singer>> GetSingersAsync(int page=1, int itemsPerPage=20)
        {
            List<Singer> singers;
            singers = await _dbRepo.GetSingersAsync(page, itemsPerPage);
            if (singers.Count == 0)
            {
                singers = await _lastSingerRepo.GetSingersAsync(page, itemsPerPage);
                _dbRepo.AddSingers(singers);
            }
            return singers;
        }
    }
}
