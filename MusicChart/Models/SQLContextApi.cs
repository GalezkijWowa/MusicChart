using MusicChart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class SQLContextApi : IContextApi
    {
        private ApplicationDbContext _context;

        public SQLContextApi(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddAlbums(IEnumerable<Album> items)
        {
            _context.Albums.AddRange(items);
        }

        public void AddAlbums(Album item)
        {
            _context.Albums.Add(item);
        }

        public void AddSingers(IEnumerable<Singer> items)
        {
            _context.Singers.AddRange(items);
        }

        public void AddSongs(IEnumerable<Song> items)
        {
            _context.Songs.AddRange(items);
        }

        public void AddSingers(Singer item)
        {
            _context.Singers.Add(item);
        }

        public void AddSongs(Song item)
        {
            _context.Songs.Add(item);
        }
    }
}
