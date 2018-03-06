using BuisnessModel.Models;
using DatabaseModel.Data;
using DatabaseModel.Models;
using EntityModel.Models;
using System;
using System.Threading.Tasks;

namespace MusicChartConsole.Models
{
    public class DbPathWriter
    {
        private ISongRepository _songRepository;
        private IContextRepository _dbRepository;
        private ISingerRepository _singerRepository;

        public DbPathWriter(ApplicationDbContext context)
        {
            _songRepository = new SongRepository(context);
            _dbRepository = new SQLContextRepository(context);
            _singerRepository = new SingerRepository(context);
        }

        public async Task AddPath(string singerName, string songName, string path)
        {
            if(_dbRepository.AddPath(singerName, songName, path))
            {
                return;
            }
            try
            {
                Singer singer = await _singerRepository.GetSingerInfoAsync(singerName);
                _dbRepository.AddSinger(singer);
                Song song = await _songRepository.GetSong(singerName, songName, path);
                song.Path = path;
                _dbRepository.AddSong(song);
            }
            catch(NullReferenceException e)
            {
            }
        }
    }
}
