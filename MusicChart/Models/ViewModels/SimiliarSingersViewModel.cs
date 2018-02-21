using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicChart.Models.ViewModels
{
    public class SimiliarSingersViewModel
    {
        public Singer Singer { get; set; }
        public IEnumerable<Singer> SimiliarSingers { get; set; }
    }
}
