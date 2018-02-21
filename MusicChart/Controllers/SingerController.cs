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
        public IActionResult List() => View(new SingerListViewModel
        {
            SingerList = new FakeSingerRepository().Singers
        });

        public IActionResult Singer(string id) {
            return View(new SingerViewModel {
                Singer = new FakeSingerRepository().Singers.FirstOrDefault(s => s.SingerId == id),
                SongList = new FakeSongRepository().SongList.Where(s => s.SingerId == id)
        });
        }  
           
    }
}