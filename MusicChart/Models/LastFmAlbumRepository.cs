using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class LastFmAlbumRepository : IAlbumRepository
    {
        private ILastAuth _lastAuth;
        public LastFmAlbumRepository()
        {
            _lastAuth = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
        }

        public async Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            LastResponse<LastAlbum> resp = await new AlbumApi(_lastAuth).GetAlbumInfoAsync(singerName, albumName);
            LastFmAlbumRepository repo = new LastFmAlbumRepository();
            ISingerRepository singerRepo = new LastFmSingerRepository();
            Album album = new Album
            {
                Name = resp.Content.Name,
                Songs = await repo.GetAlbumSongsAsync(singerName, albumName),
                Singer = await singerRepo.GetSingerInfoAsync(singerName),
                Image = resp.Content.Images.ExtraLarge
            };
            return album;
        }

        private async Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            LastResponse<LastAlbum> resp = await new AlbumApi(_lastAuth).GetAlbumInfoAsync(singerName, albumName);
            List<Song> albumSongs = new List<Song>();
            foreach (var song in resp.Content.Tracks)
            {
                albumSongs.Add(new Song
                {
                    Name = song.Name,
                }
                );
            }
            return albumSongs;
        }

        public async Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            PageResponse<LastAlbum> resp = await new ArtistApi(_lastAuth).GetTopAlbumsForArtistAsync(singerName);
            List<Album> albums = new List<Album>();
            foreach (var album in resp.Content)
            {
                albums.Add(new Album
                {
                    Name = album.Name,
                    Image = album.Images.ExtraLarge
                }
                );
            }
            return albums;
        }
    }
}
