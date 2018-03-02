using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessModel.Models.ViewModels
{
    public class SingerSimiliarViewModel
    {
        public Singer Singer { get; set; }
        public IEnumerable<Singer> SimiliarSingers { get; set; }
    }
}
