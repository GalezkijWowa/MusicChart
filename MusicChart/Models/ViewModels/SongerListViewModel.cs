using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models.ViewModels
{
    public class SongerListViewModel
    {
        public IEnumerable<Song> SongList { get; set; }
    }
}
