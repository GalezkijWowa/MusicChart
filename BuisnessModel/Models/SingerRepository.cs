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
        public Task<Singer> GetFullSingerInfoAsync(string singerName)
        {
            return _lastSingerRepo.GetFullSingerInfoAsync(singerName);
        }

        public Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            return _lastSingerRepo.GetSimiliarSingersAsync(singerName);
        }

        public Task<string> GetSingerDescription(string singerName)
        {
            return _lastSingerRepo.GetSingerDescription(singerName);
        }

        public Task<Singer> GetSingerInfoAsync(string singerName)
        {
            return _lastSingerRepo.GetSingerInfoAsync(singerName);
        }

        public Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            return _lastSingerRepo.GetSingersAsync(pageSize, itemsPerPage);
        }
    }
}
