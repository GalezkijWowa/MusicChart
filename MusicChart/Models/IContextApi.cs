using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    interface IContextApi
    {
        void AddSingers(IEnumerable<Singer> items);
        void AddSongs(IEnumerable<Song> items);
        void AddAlbums(IEnumerable<Album> items);

        void AddSingers(Singer item);
        void AddSongs(Song item);
        void AddAlbums(Album item);
    }
}
