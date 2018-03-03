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

        public async Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            Album album = await _lastAlbumRepo.GetAlbumInfoAsync(singerName, albumName);
            //_dbRepo.AddAlbum(album);
            return album;
        }

        public async Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            List<Song> songs;
            songs = await _dbRepo.GetAlbumSongsAsync(singerName, albumName);

            if(songs.Count == 0)
            {
                songs = await _lastAlbumRepo.GetAlbumSongsAsync(singerName, albumName);
                _dbRepo.AddSongs(songs);
            }
            return songs;
        }

        public async Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            List<Album> albums;
            albums = await _dbRepo.GetSingerAlbumsAsync(singerName);
            if(albums.Count == 0)
            {
                albums = await _lastAlbumRepo.GetSingerAlbumsAsync(singerName);
                _dbRepo.AddAlbums(albums);
            }
            return albums;
        }
    }
}
