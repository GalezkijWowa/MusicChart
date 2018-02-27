using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class LastFmSongRepository : ISongRepository
    {
        private ILastAuth _lastAuth;
        public LastFmSongRepository()
        {
            _lastAuth = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
        }

        public async Task<List<Song>> GetTopSongsAsync(string singerName)
        {
            PageResponse<LastTrack> resp = await new ArtistApi(_lastAuth).GetTopTracksForArtistAsync(singerName);
            List<Song> songs = new List<Song>();
            foreach (var song in resp.Content)
            {
                songs.Add(new Song
                {
                    SingerId = singerName,
                    Name = song.Name,
                    Image = song.Images.ExtraLarge,
                    SongId = song.Name,
                    AlbumId = song.AlbumName
                }
                );
            }
            return songs;
        }
    }
}
