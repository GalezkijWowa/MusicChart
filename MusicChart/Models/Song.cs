using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Singer Singer { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
    }
}
