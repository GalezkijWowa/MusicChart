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

        public async Task<IActionResult> Index()
        {
            LastAuth la = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
            ChartApi ch = new ChartApi(la);
            PageResponse<LastArtist> resp = await ch.GetTopArtistsAsync();

            List<Singer> singers = new List<Singer>();
            
            foreach (var artist in resp.Content)
            {
                singers.Add(_mapper.Map<Singer>(artist));
            }
            return View(new IndexViewModel {

                Artists = singers
            });
        }


        public IActionResult List() => View(new SongerListViewModel
        {
            SongList = _songRepository.SongList
        });

        public IActionResult Singer(string id) =>
            View(new SingerViewModel {
                Singer = _singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SongList = _songRepository.SongList.Where(s => s.SingerId == id)
        });
         
        public IActionResult SingerSongs(string id)=>
            View("Singer", new SingerViewModel
            {
                Singer = _singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SongList = _songRepository.SongList.Where(s => s.SingerId == id)
            });
        public IActionResult SimiliarSingers(string id) =>
            View(new SimiliarSingersViewModel
            {
                Singer = _singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SimiliarSingers = _singerRepository.Singers.Where(s=> s.Name.Contains("a") || s.Name.Contains("L"))
            });
    }
}