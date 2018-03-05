using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public interface IRemoteSongRepository
    {
        Task<List<Song>> GetTopSongsAsync(string singerName);
        Task<Song> GetSong(string singerName, string songName);
    }
}
