using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}
