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
        private ISongRepository _repository;
        private IContextRepository _dbRepository;
        

        public DbPathWriter(ApplicationDbContext context)
        {
            _repository = new SongRepository(context);
            _dbRepository = new SQLContextRepository(context);
        }

        public async Task AddPath(string singerName, string songName, string path)
        {
            if(_dbRepository.AddPath(singerName, songName, path))
            {
                return;
            }
            await _repository.GetSong(singerName, songName, path);
            Console.WriteLine("q");
        }
    }
}
