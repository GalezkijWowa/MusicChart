using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityModel.Models
{
    public class Album
    {
        [Key]
        public string AlbumId { get; set; }
        public string Name { get; set; }
        public string SingerId { get; set; }
        public Image Image { get; set; }
        public string ImageId { get; set; }

        public List<Song> Songs { get; set; }
    }
}
