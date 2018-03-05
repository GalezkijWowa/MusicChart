using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessModel.Models
{
    public interface IRemoteAlbumRepository
    {
        Task<List<Album>> GetSingerAlbumsAsync(string singerName);
        Task<Album> GetAlbumInfoAsync(string singerName, string albumName);
        Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName);
    }
}
