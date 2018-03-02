using EntityModel.Models;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models
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
            Song songToAdd;
            foreach (var song in resp.Content)
            {
                songToAdd = new Song
                {
                    SingerId = singerName,
                    Name = song.Name,
                    SongId = song.Name
                };
                songs.Add(songToAdd);
            }
            return songs;
        }
    }
}
