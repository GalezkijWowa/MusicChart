using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models.ViewModels
{
    public class SingerViewModel
    {
        public Singer Singer { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}
