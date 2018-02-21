using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class FakeSongRepository : ISongRepository
    {
        public IEnumerable<Song> SongList {
            get => new List<Song>()
            {
                new Song
                {
                    SongId="1",
                    Name="Tvoi glaza",
                    Description="Takie chistie kak nebo",
                    SingerId="1"
                },
                new Song
                {
                    SongId="2",
                    Name="Rap God",
                    Description="Fastest Song ever",
                    SingerId="2"
                },
                new Song
                {
                    SongId="3",
                    Name="Berzek",
                    Description="Release date 26/05/1999",
                    SingerId="2"
                },
                new Song
                {
                    SongId="4",
                    Name="Bad Romance",
                    Description="Most attractive LG song",
                    SingerId="3"
                },
                new Song
                {
                    SongId="5",
                    Name="Alejandroo",
                    Description="Song about Italian guy Alex",
                    SingerId="3"
                }
            };

            set => throw new NotImplementedException(); }
    }
}
