using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using MusicChart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class LastFmAlbumRepository : IAlbumRepository
    {
        private IContextApi _contextApi;
        private ILastAuth _lastAuth;
        public LastFmAlbumRepository(ApplicationDbContext dbContext)
        {
            _contextApi = new SQLContextApi(dbContext);
            _lastAuth = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
        }

        public async Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            LastResponse<LastAlbum> resp = await new AlbumApi(_lastAuth).GetAlbumInfoAsync(singerName, albumName);       
            Album album = new Album
            {
                AlbumId = resp.Content.Name,
                Name = resp.Content.Name,
                Image = new Image
                (
                    resp.Content.Images.ExtraLarge
                ),
                SingerId = singerName
            };
            _contextApi.AddAlbums(album);
            return album;
        }
        public async Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            LastResponse<LastAlbum> resp = await new AlbumApi(_lastAuth).GetAlbumInfoAsync(singerName, albumName);
            List<Song> albumSongs = new List<Song>();
            Song songToAdd;
            foreach (var song in resp.Content.Tracks)
            {
                songToAdd = new Song
                {
                    SongId = song.Name,
                    Name = song.Name,
                    SingerId = song.ArtistName
                };
                albumSongs.Add(songToAdd);
                _contextApi.AddSongs(songToAdd);

            }
            return albumSongs;
        }


        public async Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            PageResponse<LastAlbum> resp = await new ArtistApi(_lastAuth).GetTopAlbumsForArtistAsync(singerName);
            List<Album> albums = new List<Album>();
            foreach (var album in resp.Content)
            {
                albums.Add(await GetAlbumInfoAsync(singerName, album.Name));
            }
            return albums;
        }
    }
}
