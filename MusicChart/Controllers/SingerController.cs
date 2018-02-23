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
        private ISingerRepository _singerRepository;
        private ISongRepository _songRepository;

        public SingerController(ISingerRepository singerRepo, ISongRepository songRepo, IMapper mapper)
        {
            _lastAuth = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
            _singerRepository = singerRepo;
            _songRepository = songRepo;
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
            Singer singer = new Singer
            {
                SingerId = id,
                Name = id
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
            Singer singer = new Singer
            {
                SingerId = id,
                Name=id
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
            Singer singer = new Singer
            {
                SingerId = id,
                Name = id
            };
            return View(new SingerSimiliarViewModel
            {
                SimiliarSingers = singers,
                Singer = singer
            });
        }
        //private async Singer MapSinger(string id)
        //{
        //    PageResponse<LastArtist> resp = await new ArtistApi(_lastAuth).GetArtistInfoAsync(id);
        //    return new Singer();
        //}
    }
}