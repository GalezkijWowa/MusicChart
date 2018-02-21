using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    interface ISongRepository
    {
        IEnumerable<Song> SongList { get; set; }
    }
}
