using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuisnessModel.Models;
using EntityModel.Models.ViewModels;
using DatabaseModel.Data;
using EntityModel.Models;

namespace MusicChart.Controllers
{
    public class SingerController : Controller
    {
        private IAlbumRepository _albumRepo;
        private ISongRepository _songRepo;
        private ISingerRepository _singerRepo;

        public SingerController(ApplicationDbContext dbContext)
        {
            _singerRepo = new SingerRepository(dbContext);
            _songRepo = new SongRepository(dbContext);
            _albumRepo = new AlbumRepository(dbContext);
        }

        public async Task<IActionResult> SingerList(int page = 1)
        {
            List<Singer> singers = await _singerRepo.GetSingersAsync(page, PageInfo.PageSize);
            return View(new SingerListViewModel
            {
                Singers = singers,
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageInfo.PageSize
                }
            });
        }

        public async Task<IActionResult> Singer(string id)
        {
            List<Song> songs = await _songRepo.GetTopSongsAsync(id);
            Singer singer = await _singerRepo.GetFullSingerInfoAsync(id);
            return View(new SingerSongsViewModel
            {
                Singer = singer,
                SongList = songs
            });
        }

        public async Task<IActionResult> SingerAlbums(string id)
        {
            List<Album> albums = await _albumRepo.GetSingerAlbumsAsync(id);
            Singer singer = await _singerRepo.GetSingerInfoAsync(id);
            return View(new SingerAlbumsViewModel
            {
                Albums = albums,
                Singer = singer
            });
        }

        public async Task<IActionResult> SingerSimiliar(string id)
        {
            List<Singer> singers = await _singerRepo.GetSimiliarSingersAsync(id);
            Singer singer = await _singerRepo.GetSingerInfoAsync(id);
            return View(new SingerSimiliarViewModel
            {
                SimiliarSingers = singers,
                Singer = singer
            });
        }

        [HttpGet]
        public IActionResult ChangeSize(int size)
        {
            PageInfo.PageSize = size;
            return Redirect("SingerList");
        }

        public async Task<IActionResult> Album(string id, string albumName)
        {
            Album album = await _albumRepo.GetAlbumInfoAsync(id, albumName);
            List<Song> songs = await _albumRepo.GetAlbumSongsAsync(id, album.Name);
            return View(new AlbumViewModel
            {
                Album = album,
                Songs = songs
            });
        }
    }
}