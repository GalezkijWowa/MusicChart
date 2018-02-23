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
        private readonly IMapper _mapper;
        private ISingerRepository _singerRepository;
        private ISongRepository _songRepository;

        public SingerController(ISingerRepository singerRepo, ISongRepository songRepo, IMapper mapper)
        {
            _singerRepository = singerRepo;
            _songRepository = songRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> SingerList()
        {
            LastAuth la = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
            ChartApi ch = new ChartApi(la);
            PageResponse<LastArtist> resp = await ch.GetTopArtistsAsync();
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
            LastAuth la = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
            ArtistApi artistApi = new ArtistApi(la);
            PageResponse<LastTrack> resp = await artistApi.GetTopTracksForArtistAsync(id);
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
            return View(new SingerViewModel
            {
               Singer = singer,
               SongList = songs
            });
        }
            

        public async Task<IActionResult> SingerAlbums(string id)
        {
            LastAuth la = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
            ArtistApi artistApi = new ArtistApi(la);
            PageResponse<LastAlbum> resp = await artistApi.GetTopAlbumsForArtistAsync(id);
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

        public IActionResult SingerSimiliar(string id) =>
            View(new SingerSimiliarViewModel
            {
                Singer = _singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SimiliarSingers = _singerRepository.Singers.Where(s => s.Name.Contains("a") || s.Name.Contains("L"))
            });
    }
}