using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetSingerAlbumsAsync(string singerName);
        Task<Album> GetAlbumInfoAsync(string singerName, string albumName);
        Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName);
    }
}
