using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models
{
    public class Singer
    {
        [Key]
        public string SingerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Photo { get; set; }
        public List<Song> Songs { get; set; }
        public List<Singer> Similar { get; set; }
    }
}
