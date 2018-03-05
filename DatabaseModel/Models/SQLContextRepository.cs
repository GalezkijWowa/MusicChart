using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseModel.Data;
using EntityModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModel.Models
{
    public class SQLContextRepository : IContextRepository
    {
        private ApplicationDbContext _context;
        public SQLContextRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddAlbums(IEnumerable<Album> items)
        {
            foreach (var item in items)
            {
                AddAlbum(item);
            }
            _context.SaveChanges();
        }

        public void AddAlbum(Album item)
        {
            Album albumFromDb = _context.Albums.Find(item.AlbumId);
            if (albumFromDb == null)
            {
                _context.Albums.Add(item);
            }
            _context.SaveChanges();
        }

        public void AddSimiliarMap(string simName, string singerName)
        {
            SimiliarMap map = new SimiliarMap
            {
                SimiliarSingerId = simName,
                SingerId = singerName
            };
            if (_context.SimiliarMaps.Where(m => m.SingerId == map.SingerId && m.SimiliarSingerId == map.SimiliarSingerId).ToList().Count() == 0)
            {
                _context.SimiliarMaps.Add(map);
            }
            _context.SaveChanges();
        }

        public void AddSingers(IEnumerable<Singer> items)
        {
            foreach (var item in items)
            {
                AddSinger(item);
            }
            _context.SaveChanges();
        }

        public void AddSinger(Singer item)
        {
            Singer singerFromDb = _context.Singers.Find(item.SingerId);
            if (singerFromDb == null)
            {
                _context.Singers.Add(item);
            }
            else
            {
                singerFromDb.Description = item.Description;
                _context.Singers.Update(singerFromDb);
            }
            _context.SaveChanges();
        }

        public void AddSongs(IEnumerable<Song> items)
        {
            foreach (var item in items)
            {
                AddSong(item);
            }
            _context.SaveChanges();
        }

        public void AddSong(Song item)
        {
            Song songFromDb = _context.Songs.Find(item.SongId);
            if (songFromDb == null)
            {
                _context.Songs.Add(item);
            }
            else
            {
                songFromDb.AlbumName = item.AlbumName;
                _context.Entry(songFromDb).State = EntityState.Modified;
                _context.Songs.Update(songFromDb);
            }
            _context.SaveChanges();
        }

        private Image GetSingerPhoto(string singerName)
        {
            return _context.Images.FirstOrDefault(p => p.ImageId == _context.Singers.FirstOrDefault(s => s.Name == singerName).ImageId);
        }

        private Image GetAlbumImage(string albumName)
        {
            return _context.Images.FirstOrDefault(p => p.ImageId == _context.Albums.FirstOrDefault(a => a.Name == albumName).ImageId);
        }
        
        public async Task<Album> GetAlbumInfoAsync(string singerName, string albumName)
        {
            return _context.Albums.FirstOrDefault(a => a.SingerId == singerName && a.Name == albumName);
        }

        public async Task<List<Song>> GetAlbumSongsAsync(string singerName, string albumName)
        {
            return _context.Songs.Where(s => s.SingerId == singerName && s.AlbumName == albumName).ToList();
        }

        public async Task<Singer> GetFullSingerInfoAsync(string singerName)
        {
            Singer singer = await GetSingerInfoAsync(singerName);
            singer.Description = await GetSingerDescription(singerName);
            return singer;
        }

        public async Task<List<Singer>> GetSimiliarSingersAsync(string singerName)
        {
            List<SimiliarMap> simMaps = _context.SimiliarMaps.Where(map => map.SingerId == singerName).ToList();
            List<Singer> singerList = new List<Singer>();
            foreach (SimiliarMap map in simMaps)
            {
                singerList.Add(await GetSingerInfoAsync(map.SimiliarSingerId));
            }
            return singerList;
        }

        public async Task<List<Album>> GetSingerAlbumsAsync(string singerName)
        {
            List<Album> albums = _context.Albums.Where(a => a.SingerId == singerName).ToList();
            albums.ForEach(a => a.Image = GetAlbumImage(a.Name));
            return albums;
        }

        public async Task<string> GetSingerDescription(string singerName)
        {
            return _context.Singers.FirstOrDefault(s => s.Name == singerName).Description;
        }

        public async Task<Singer> GetSingerInfoAsync(string singerName)
        {
            Singer singer = _context.Singers.FirstOrDefault(s => s.Name == singerName);
            singer.Photo = GetSingerPhoto(singer.SingerId);
            return singer;
        }

        public async Task<List<Singer>> GetSingersAsync(int pageSize = 1, int itemsPerPage = 20)
        {
            List<Singer> singers = _context.Singers.Where(s => s.IsTop == 1).Skip((pageSize - 1) * PageInfo.PageSize).Take(PageInfo.PageSize).ToList();
            singers.ForEach(s => s.Photo = GetSingerPhoto(s.Name));
            return singers;
        }

        public async Task<List<Song>> GetTopSongsAsync(string singerName)
        {
            return _context.Songs.Where(s => s.SingerId == singerName).ToList();
        }

        public void AddSimiliarMaps(List<Singer> simList, string singerName)
        {
            simList.ForEach(s => AddSimiliarMap(s.Name, singerName));
        }

        public async Task<Song> GetSong(string singerName, string songName)
        {
            return _context.Songs.FirstOrDefault(s => s.Name == songName && s.SingerId == singerName); 
        }

        public bool AddPath(string singerName, string songName, string path)
        {
            Song song = _context.Songs.FirstOrDefault(s => s.Name == songName && s.SingerId == singerName);

            if(song != null && (song.Path == null || song.Path != path))
            {
                Console.WriteLine("pass == null");
                song.Path = path;
                _context.Songs.Update(song);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}