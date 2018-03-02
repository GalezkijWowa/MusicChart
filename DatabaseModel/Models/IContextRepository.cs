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

        void AddSingers(Singer item);
        void AddSongs(Song item);
        void AddAlbums(Album item);
        void AddSimiliarMap(SimiliarMap map);
    }
}
