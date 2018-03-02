using DatabaseModel.Data;
using DatabaseModel.Models;
using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public class AlbumRepository : IAlbumRepository
    {
        private IContextRepository _dbRepo;
        private IAlbumRepository _lastAlbumRepo;

        public AlbumRepository(ApplicationDbContext dbContext)
        {
            _dbRepo = new SQLContextRepository(dbContext);
            _lastAlbumRepo = new LastFmAlbumRepository();
        }

        public Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            return _lastAlbumRepo.GetAlbumInfoAsync(singerName, albumName);
        }

        public Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            return _lastAlbumRepo.GetAlbumSongsAsync(singerName, albumName);
        }

        public Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            return _lastAlbumRepo.GetSingerAlbumsAsync(singerName);
        }
    }
}
