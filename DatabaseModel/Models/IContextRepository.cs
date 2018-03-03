
using EntityModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Models
{
    public interface IContextRepository
    {
        void AddSingers(IEnumerable<Singer> items);
        void AddSongs(IEnumerable<Song> items);
        void AddAlbums(IEnumerable<Album> items);

        void AddSinger(Singer item);
        void AddSong(Song item);
        void AddAlbum(Album item);
        void AddSimiliarMap(string simName, string singerName);
        void AddSimiliarMaps(List<Singer> simList, string singerName);

        Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20);
        Task<List<Singer>> GetSimiliarSingersAsync(string singerName);
        Task<Singer> GetSingerInfoAsync(string singerName);
        Task<Singer> GetFullSingerInfoAsync(string singerName);
        Task<string> GetSingerDescription(string singerName);

        Task<List<Album>> GetSingerAlbumsAsync(string singerName);
        Task<Album> GetAlbumInfoAsync(string singerName, string albumName);
        Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName);

        Task<List<Song>> GetTopSongsAsync(string singerName);
    }
}
