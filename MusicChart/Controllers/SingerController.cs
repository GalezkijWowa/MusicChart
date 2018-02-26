using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicChart.Models;
using MusicChart.Models.ViewModels;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Api.Helpers;
using IF.Lastfm.Core.Objects;
using AutoMapper;

namespace MusicChart.Controllers
{
    public class SingerController : Controller
    {
        private ILastAuth _lastAuth;
        private readonly IMapper _mapper;

        public SingerController(IMapper mapper)
        {
            _lastAuth = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
            _mapper = mapper;
        }

        public async Task<IActionResult> SingerList()
        {
            PageResponse<LastArtist> resp = await new ChartApi(_lastAuth).GetTopArtistsAsync();
            List<Singer> singers = new List<Singer>();

            foreach (var artist in resp.Content)
            {
                singers.Add(new Singer
                {
                    Name = artist.Name,
                    Photo = artist.MainImage.ExtraLarge
                }
                );
            }
            return View(new SingerListViewModel
            {
                Singers = singers
            });
        }

        public async Task<IActionResult> Singer(string id)
        {
            PageResponse<LastTrack> resp = await new ArtistApi(_lastAuth).GetTopTracksForArtistAsync(id);
            List<Song> songs = new List<Song>();
            LastResponse<LastArtist> singerResp = await new ArtistApi(_lastAuth).GetArtistInfoAsync(id);
            Singer singer = new Singer
            {
                SingerId = singerResp.Content.Name,
                Name = singerResp.Content.Name,
                Photo = singerResp.Content.MainImage.ExtraLarge,
                Description=singerResp.Content.Bio.Summary
            };
            foreach (var song in resp.Content)
            {
                songs.Add(new Song
                {
                    Name = song.Name,
                    Image = song.Images.ExtraLarge
                }
                );
            }
            return View(new SingerSongsViewModel
            {
                Singer = singer,
                SongList = songs
            });
        }

        public async Task<IActionResult> SingerAlbums(string id)
        {
            PageResponse<LastAlbum> resp = await new ArtistApi(_lastAuth).GetTopAlbumsForArtistAsync(id);
            List<Album> albums = new List<Album>();
            LastResponse<LastArtist> singerResp = await new ArtistApi(_lastAuth).GetArtistInfoAsync(id);
            Singer singer = new Singer
            {
                SingerId = singerResp.Content.Name,
                Name = singerResp.Content.Name,
                Photo = singerResp.Content.MainImage.ExtraLarge,
                Description = singerResp.Content.Bio.Summary
            };
            foreach (var album in resp.Content)
            {
                albums.Add(new Album
                {
                    Name = album.Name,
                    Image = album.Images.ExtraLarge
                }
                );
            }
            return View(new SingerAlbumsViewModel
            {
                Albums = albums,
                Singer = singer
            });
        }

        public async Task<IActionResult> SingerSimiliar(string id)
        {
            PageResponse<LastArtist> resp = await new ArtistApi(_lastAuth).GetSimilarArtistsAsync(id);
            List<Singer> singers = new List<Singer>();

            foreach (var artist in resp.Content)
            {
                singers.Add(new Singer
                {
                    Name = artist.Name,
                    Photo = artist.MainImage.ExtraLarge
                }
                );
            }
            LastResponse<LastArtist> singerResp = await new ArtistApi(_lastAuth).GetArtistInfoAsync(id);
            Singer singer = new Singer
            {
                SingerId = singerResp.Content.Name,
                Name = singerResp.Content.Name,
                Photo = singerResp.Content.MainImage.ExtraLarge,
                Description = singerResp.Content.Bio.Summary
            };
            return View(new SingerSimiliarViewModel
            {
                SimiliarSingers = singers,
                Singer = singer
            });
        }


        public async Task<IActionResult> Album(string id, string albumName)
        {
            LastResponse<LastAlbum> resp = await new AlbumApi(_lastAuth).GetAlbumInfoAsync(id, albumName);
            List<Song> albumSongs = new List<Song>();
            LastResponse<LastArtist> singerResp = await new ArtistApi(_lastAuth).GetArtistInfoAsync(id);
            Singer singer = new Singer
            {
                SingerId = singerResp.Content.Name,
                Name = singerResp.Content.Name,
                Photo = singerResp.Content.MainImage.ExtraLarge,
                Description = singerResp.Content.Bio.Summary
            };
            foreach (var song in resp.Content.Tracks)
            {
                albumSongs.Add(new Song
                {
                    Name = song.Name,
                    //Image = song.Images.ExtraLarge
                }
                );
            }

            Album album = new Album
            {
                Name = resp.Content.Name,
                Songs = albumSongs,
                Singer = singer,
                Image = resp.Content.Images.ExtraLarge
            };
            return View(new AlbumViewModel
            {
               Album= album
            });
        }
    }
}