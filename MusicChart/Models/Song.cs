using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class Song
    {
        public string SongId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SingerId { get; set; }
    }
}
