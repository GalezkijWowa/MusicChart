using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetSingerAlbumsAsync(string singerName);
        Task<Album> GetAlbumInfoAsync(string singerName, string albumName);
        Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName);
    }
}
