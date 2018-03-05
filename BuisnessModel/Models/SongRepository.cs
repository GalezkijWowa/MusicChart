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
        private IRemoteSongRepository _lastSongRepo;

        public SongRepository(ApplicationDbContext dbContext)
        {
            _dbRepo = new SQLContextRepository(dbContext);
            _lastSongRepo = new LastFmSongRepository();
        }

        public async Task GetSong(string singerName, string songName, string path)
        {
            Song song = await _lastSongRepo.GetSong(singerName, songName);
            Console.WriteLine("qwe");
            song.Path = path;
            _dbRepo.AddSong(song);
            Console.WriteLine("GetSong");
        }

        public async Task<List<Song>> GetTopSongsAsync(string singerName)
        {
            List<Song> songs;
            songs = await _dbRepo.GetTopSongsAsync(singerName);
            if(songs.Count == 0)
            {
                songs = await _lastSongRepo.GetTopSongsAsync(singerName);
                _dbRepo.AddSongs(songs);
            }
            return songs;
        }
    }
}
