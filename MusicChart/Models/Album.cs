using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class Album
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public string SingerId { get; set; }
        public Uri Image { get; set; }
    }
}
