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

namespace MusicChart.Controllers
{
    public class SingerController : Controller
    {
        private ISingerRepository singerRepository;
        private ISongRepository songRepository;

        public SingerController(ISingerRepository singerRepo, ISongRepository songRepo)
        {
            singerRepository = singerRepo;
            songRepository = songRepo;
        }

        //public async IActionResult Index()
        //{
        //    LastAuth la = new LastAuth("96d047d302a8707f3a7410873466dbfd", "3afdcf3ccad058a82202544549cb141b");
        //    ChartApi ch = new ChartApi(la);
        //    PageResponse<LastArtist> resp = await ch.GetTopArtistsAsync();
        //}


        public IActionResult List() => View(new SongerListViewModel
        {
            SongList = songRepository.SongList
        });

        public IActionResult Singer(string id) =>
            View(new SingerViewModel {
                Singer = singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SongList = songRepository.SongList.Where(s => s.SingerId == id)
        });
         
        public IActionResult SingerSongs(string id)=>
            View("Singer", new SingerViewModel
            {
                Singer = singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SongList = songRepository.SongList.Where(s => s.SingerId == id)
            });
        public IActionResult SimiliarSingers(string id) =>
            View(new SimiliarSingersViewModel
            {
                Singer = singerRepository.Singers.FirstOrDefault(s => s.SingerId == id),
                SimiliarSingers = singerRepository.Singers.Where(s=> s.Name.Contains("a") || s.Name.Contains("L"))
            });
    }
}