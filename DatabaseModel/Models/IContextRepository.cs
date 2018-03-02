using BuisnessModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseModel.Models
{
    public interface IContextRepository : ISingerRepository, ISongRepository, IAlbumRepository
    {
        void AddSingers(IEnumerable<Singer> items);
        void AddSongs(IEnumerable<Song> items);
        void AddAlbums(IEnumerable<Album> items);

        void AddSinger(Singer item);
        void AddSong(Song item);
        void AddAlbum(Album item);
        void AddSimiliarMap(SimiliarMap map);

        void UpdateSingers(Singer item);
        void UpdateSongs(Song item);
        void UpdateAlbums(Album item);
    }
}
