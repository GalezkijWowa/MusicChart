using DatabaseModel.Data;
using DatabaseModel.Models;
using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public class SongRepository : ISongRepository
    {
        private IContextRepository _dbRepo;
        private ISongRepository _lastSongRepo;

        public SongRepository(ApplicationDbContext dbContext)
        {
            _dbRepo = new SQLContextRepository(dbContext);
            _lastSongRepo = new LastFmSongRepository();
        }
        public Task<List<Song>> GetTopSongsAsync(string singerName)
        {
            return _lastSongRepo.GetTopSongsAsync(singerName);
        }
    }
}
