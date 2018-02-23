using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF.Lastfm.Core.Objects;
namespace MusicChart.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Singer> Artists { get; set; }
    }
}
