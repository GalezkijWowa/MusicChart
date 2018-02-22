using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicChart.Models;
using MusicChart.Models.ViewModels;

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


        public IActionResult List() => View(new SongerListViewModel
        {
            SongList = songRepository.SongList
        });

        public IActionResult Singer(string id) =>
            View("TestSinger", new SingerViewModel {
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
                SimiliarSingers = singerRepository.Singers.Where(s=> s.Name.Contains("a"))
            });
    }
}